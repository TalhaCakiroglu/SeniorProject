using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Used to check if a mission has been accomplished
/// </summary>
interface IMissionCheck
{
    bool MissionStatus();
}

/// <summary>
/// A singleton that persists across scenes
/// </summary>
public class MissionHandler : MonoBehaviour
{
    #region // General Settings
    [Header("How many concurrent missions?")]
    /// <summary>
    /// How many missions that can be active at once
    /// </summary>
    [Tooltip("How many missions can be active at a time?")]
    [SerializeField]
    private int maxActiveMissions = 3;

    [Header("Between games...")]
    /// <summary>
    /// Should we save which missions that are active?
    /// </summary>
    [Tooltip("Should we save data about which missions are active between games?")]
    [SerializeField]
    private bool saveActiveMissions = true;

    /// <summary>
    /// Should we save which missions have been accomplished?
    /// </summary>
    [Tooltip("Should we save data about which missions that has been accomplished between games?")]
    [SerializeField]
    private bool saveAccomplishedMissions = true;
    #endregion

    #region // Color Settings
    [Header("Color Indicators")]
    /// <summary>
    /// Which color to use for finished missions
    /// </summary>
    [Tooltip("The background color for missions that has been accomplished")]
    [SerializeField]
    private Color finished = Color.green;

    /// <summary>
    /// Which color to use for unfinished missions
    /// </summary>
    [Tooltip("The background color for missions that hasn't been accomplished")]
    [SerializeField]
    private Color unfinished = Color.gray;
    #endregion

    #region // Internal variables
    /// <summary>
    /// A list of all missions
    /// </summary>
    private List<Mission> allMissions;

    /// <summary>
    /// A list of the missions that are currently active
    /// </summary>
    private List<Mission> activeMissions = new List<Mission>();

    /// <summary>
    /// The canvas used for mission information
    /// </summary>
    private GameObject missionCanvas;

    /// <summary>
    /// Used to keep track of the singleton
    /// </summary>
    [HideInInspector]
    static MissionHandler missionHandler = null;

    /// <summary>
    /// Only the singleton instance need to clean up after itself
    /// </summary>
    private bool cleanUp = false;
    #endregion

    private void Start()
    {
        #region // Singleton stuff
        // We should only have one instance of the handler
        if (missionHandler != null)
        {
            Destroy(gameObject);

            return;
        }

        // This is the singleton
        missionHandler = this;

        cleanUp = true;

        // It should persist across scenes
        DontDestroyOnLoad(gameObject);
        #endregion

        #region // Set up canvas
        // The canvas used to display mission information
        missionCanvas = GetComponent<RectTransform>().Find("MissionCanvas").gameObject;

        // Disable canvas until it's time to show the missions
        missionCanvas.SetActive(true);
        #endregion

        // Get all missions available
        allMissions = new List<Mission>(missionCanvas.gameObject.GetComponentsInChildren<Mission>(true));

        // Inactivate all missions at start
        TurnOffAll();

        RemoveAccomplished();

        ReactivateOld();
    }

    /// <summary>
    /// Don't show any of the missions
    /// </summary>
    private void TurnOffAll()
    {
        for (int i = 0; i < allMissions.Count; i++)
        {
            allMissions[i].gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Remove missions that are accomplished
    /// </summary>
    public void CullAccomplished()
    {
        for (int i = 0; i < activeMissions.Count; i++)
        {
            if (activeMissions[i].accomplished)
            {
                activeMissions[i].gameObject.SetActive(false);

                if (!activeMissions[i].recurring)
                {
                    for (int j = 0; j < allMissions.Count; j++)
                    {
                        if (allMissions[j].name == activeMissions[i].name)
                        {
                            allMissions.RemoveAt(j);

                            break;
                        }
                    }
                }
                else
                {
                    activeMissions[i].accomplished = false;
                }

                activeMissions.RemoveAt(i--);
            }
        }
    }

    /// <summary>
    /// Check if any of the missions have been accomplished
    /// </summary>
    public void CheckMissions()
    {
        for (int i = 0; i < activeMissions.Count; i++)
        {
            IMissionCheck imc = activeMissions[i].GetComponent<IMissionCheck>();

            activeMissions[i].accomplished = imc != null && imc.MissionStatus();

            activeMissions[i].GetComponent<Image>().color =
                activeMissions[i].accomplished ? finished : unfinished;
        }
    }

    /// <summary>
    /// Randomly select a number of missions and set them as active
    /// </summary>
    public void RandomizeMissions()
    {
        // If we have fewer available missions than we are supposed
        // to show, just show the available ones
        if (allMissions.Count < maxActiveMissions)
        {
            #region // Show all available missions
            // Remove any old active missions
            activeMissions.Clear();

            // Copy allMissions to activeMissions
            for (int i = 0; i < allMissions.Count; i++)
            {
                allMissions[i].gameObject.SetActive(true);

                activeMissions.Add(allMissions[i]);
            }
            #endregion
        }
        else // We have more missions than we can activate
        {
            #region // Randomly select missions from the available ones
            // If we already have missions in activeMissions
            // then they should be included and we only need
            // to fill the list to its capacity

            // Select random missions to fill up activeMissions
            while (activeMissions.Count < maxActiveMissions)
            {
                bool found;
                int m;

                do
                {
                    found = false;

                    m = Random.RandomRange(0, allMissions.Count);

                    found = allMissions[m].gameObject.activeSelf;
                }
                while (found);

                allMissions[m].gameObject.SetActive(true);

                activeMissions.Add(allMissions[m]);
            }
            #endregion
        }
    }

    /// <summary>
    /// Resets all missions completely
    /// </summary>
    public void ResetMissions()
    {
        PlayerPrefs.DeleteKey("ActiveMissions");
        PlayerPrefs.DeleteKey("Accomplished");
        PlayerPrefs.Save();

        // Get all missions available
        allMissions = new List<Mission>(missionCanvas.gameObject.GetComponentsInChildren<Mission>(true));

        // Inactivate all missions at start
        TurnOffAll();

        // We have no active missions
        activeMissions.Clear();
    }

    /// <summary>
    /// Displays information about the active missions
    /// </summary>
    public void ShowMissions()
    {
        missionCanvas.SetActive(true);
    }

    /// <summary>
    /// Hides the canvas with the missions
    /// </summary>
    public void HideMissions()
    {
        missionCanvas.SetActive(false);
    }

    #region // Save/restore missions across games
    /// <summary>
    /// Save accomplished missions
    /// </summary>
    private void SaveAccomplishedMissions()
    {
        // Should we save the nonrecurring missions that have been accomplished?
        if (saveAccomplishedMissions)
        {
            string t = "";
            string comma = "";

            List<Mission> ms = new List<Mission>(missionCanvas.gameObject.GetComponentsInChildren<Mission>(true));

            for (int i = 0; i < ms.Count; i++)
            {
                if (ms[i].accomplished && !ms[i].recurring)
                {
                    t += comma + ms[i].name;
                }
            }

            PlayerPrefs.SetString("Accomplished", t);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Remove missions that have been accomplished in previous games
    /// </summary>
    private void RemoveAccomplished()
    {
        if (saveAccomplishedMissions)
        {
            // Remove old accomplished missions
            string t = PlayerPrefs.GetString("Accomplished");
            string[] oldAccomplished = t.Split(',');

            if (oldAccomplished[0] == "")
            {
                return;
            }

            for (int i = 0; i < oldAccomplished.Length; i++)
            {
                for (int j = 0; j < allMissions.Count; j++)
                {
                    if (allMissions[j].name == oldAccomplished[i])
                    {
                        allMissions.RemoveAt(j);

                        break;
                    }
                }
            }
        }
    }
    #endregion

    #region // Save/restore active missions across games
    /// <summary>
    /// Save active missons
    /// </summary>
    private void SaveActiveMissions()
    {
        // Should we save the active missions?
        if (saveActiveMissions)
        {
            string t = "";
            string comma = "";

            for (int i = 0; i < activeMissions.Count; i++)
            {
                // Only save those that haven't been accomplished
                if (!activeMissions[i].accomplished)
                {
                    t += comma + activeMissions[i].name;

                    comma = ",";
                }
            }

            PlayerPrefs.SetString("ActiveMissions", t);
            PlayerPrefs.Save();
        }
    }

    /// <summary>
    /// Re-activate the missions that were active last game
    /// </summary>
    private void ReactivateOld()
    {
        activeMissions.Clear();

        // Re-activate old missions
        if (saveActiveMissions)
        {
            string t = PlayerPrefs.GetString("ActiveMissions");
            string[] oldActiveMissions = t.Split(',');

            if (oldActiveMissions[0] == "")
            {
                return;
            }

            for (int i = 0; i < oldActiveMissions.Length; i++)
            {
                for (int j = 0; j < allMissions.Count; j++)
                {
                    if (allMissions[j].name == oldActiveMissions[i])
                    {
                        activeMissions.Add(allMissions[j]);
                        allMissions[j].gameObject.SetActive(true);

                        break;
                    }
                }
            }
        }
    }
    #endregion

    /// <summary>
    /// Clean up the missions once the game ends
    /// </summary>
    void OnDestroy()
    {
        // Only clean up if this was the actual singleton instance
        if (!cleanUp)
        {
            return;
        }

        // Cull, so that accomplished missions that aren't recurring
        // are updated correctly
        CullAccomplished();

        SaveActiveMissions();

        SaveAccomplishedMissions();
    }
}
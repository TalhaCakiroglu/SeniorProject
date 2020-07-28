using UnityEngine;

/// <summary>
/// Holds the extra information needed for each mission
/// </summary>
public class Mission : MonoBehaviour
{
    /// <summary>
    /// Is this a mission that can be accomplished several times?
    /// </summary>
    [Tooltip("Can this mission be done several times?")]
    public bool recurring = false;

    /// <summary>
    /// Has this mission been completed?
    /// </summary>
    [HideInInspector]
    public bool accomplished = false;
}
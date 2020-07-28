using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class exit : MonoBehaviour
{
    public GameObject exitPanel;
    // Start is called before the first frame update
    void Start()
    {
        exitPanel.SetActive(false);
    }

    public  void butons(int deger)
    {
        if (deger == 1)
        {
            exitPanel.SetActive(true);
        }
        else if(deger == 0)
        {
            exitPanel.SetActive(false);
        }
        else if(deger==-1 )
        {
            Application.Quit();
        }
    }
}

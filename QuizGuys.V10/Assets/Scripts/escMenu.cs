using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class escMenu : MonoBehaviour
{
    public GameObject Genelpanel;
    public GameObject escPanel;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Genelpanel.SetActive(false);
            escPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Genelpanel.SetActive(true);
            escPanel.SetActive(false);
        }
           
    }
}

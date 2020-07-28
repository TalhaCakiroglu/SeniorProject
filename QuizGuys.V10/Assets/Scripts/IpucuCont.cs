using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IpucuCont : MonoBehaviour
{
    public GameObject ipucuPanel;
    public GameObject ipucuAc;
    public GameObject ipucuKapat;

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            ipucuPanel.SetActive(true);
            ipucuAc.SetActive(false);
            ipucuKapat.SetActive(true);
        }
        else if (Input.GetKeyDown("o"))
        {
            ipucuPanel.SetActive(false);
            ipucuAc.SetActive(true);
            ipucuKapat.SetActive(false);
        }
       
        

        
    }






}

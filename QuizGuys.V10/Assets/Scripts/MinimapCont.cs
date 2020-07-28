using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapCont : MonoBehaviour
{
    public GameObject miniMap;
    public GameObject npcName1;
    public GameObject npcName2;
    public GameObject npcName3;
    public GameObject npcName4;
    public GameObject npcName5;
    public GameObject npcName6;
    public GameObject npcName7;
    public Camera mMap;
    public GameObject canvas;
    public GameObject ipucuKapat;


    public void LateUpdate()
    {

        if (Input.GetKeyDown("m"))
        {
            ipucuKapat.SetActive(false);
            npcName1.SetActive(true);
            npcName2.SetActive(true);
            npcName3.SetActive(true);
            npcName4.SetActive(true);
            npcName5.SetActive(true);
            npcName6.SetActive(true);
            npcName7.SetActive(true);
            RectTransform rt = canvas.GetComponent<RectTransform>();
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 750);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 600);
            mMap.orthographicSize = 20;

        }
        else if (Input.GetKeyDown("n"))
        {
            ipucuKapat.SetActive(true);
            npcName1.SetActive(false);
            npcName2.SetActive(false);
            npcName3.SetActive(false);
            npcName4.SetActive(false);
            npcName5.SetActive(false);
            npcName6.SetActive(false);
            npcName7.SetActive(false);
            RectTransform rt = canvas.GetComponent<RectTransform>();
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 225);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 204);
            mMap.orthographicSize = 10;
        }
    }

   
}

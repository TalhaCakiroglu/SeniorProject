using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;
using TMPro;


public class DiyalogKontrol : MonoBehaviour
{

    
    public GameObject gorevCanvas;
    public InputField cevap;
    public TextMeshProUGUI tebrik;
    public TextMeshProUGUI kayip;
    public string soru;
    private int count = 3;
    public Text npcName;
    public GameObject player;

  
   
    
    public void gorev()
    {

/*
       soru = "soru";
        if (cevap.text == soru)
        {
            gorevCanvas.SetActive(false);
            tebrik.text = "TEBRİKLER";
            Debug.Log("tebrikler");

        }
        */
    }
    public void kapat()
    {
        gorevCanvas.SetActive(false);
    }



    private void Start()
    {
        // gorev();
        //gorevCanvas.SetActive(true);
               
    }

    private void Update()
    {
       
    }
    public void LateUpdate()
    {
       // gorevBaslat();
    }
    /*
    void DiyalogBaslat(VIDE_Assign npcDiyalog)
    {
        if (!VD.isActive)
        {

            gorevCanvas.SetActive(true);
            npcName.text = npcDiyalog.alias;
            Debug.Log("Etkilesimm");
        }
        
    }*/

    public void gorevBaslat()
    {
        
   
    }
   
   
}   
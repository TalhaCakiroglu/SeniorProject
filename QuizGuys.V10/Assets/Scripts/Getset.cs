using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Getset : MonoBehaviour
{
        
    public Text[] cevapL;//ilk 5 text
    public Text[] soruL;
    public int i = 0;

    public void getSett()
    {

    }


    public void ButonAta()
    {
        for (int i = 0; i <=4; i++)
        {
            if (cevapL[i].text != null)
            {
                cevapL[i].text = soruL[i].text;
            }
        }
       
        
                
           
        
    }

    /*
    public void ButonAta2()
    {

            cevapL.text = soruL.text;
        

    }

    public void ButonAta3()
    {

            cevapL.text = soruL.text;
       

    }
    public void ButonAta4()
    {

        
            cevapL.text = soruL.text;
        

    }*/
}

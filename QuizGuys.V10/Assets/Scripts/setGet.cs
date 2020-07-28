using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class setGet : MonoBehaviour
{
    public InputField cevap;
    public InputField soru;
    public GameObject gorevC;
    public TextMeshProUGUI tebrik;
    public GameObject tebrikCanvas;
    public GameObject kayipkCanvas;
    public GameObject player;
    public AudioSource ses;
    public AudioSource ses2;
    public GameObject Gorev1Complete;
    public GameObject Gorev1Fail;

    int skor, hskor;
    public Text skorT, hskorT;
    public int count = 3;


    private void Start()
    {
        Load();
    }

    private void Load()
    {
        hskor = PlayerPrefs.GetInt("hskor");
        hskorT.text = hskor.ToString();
    }

    public void setGett()
    {
       
        tebrik = GetComponent<TextMeshProUGUI>();
        soru.text = "aylaya gıt";
       
        for (int i = 0; i < count; i++)
        {
            
            if (cevap.text == soru.text)
            {

                skorYap();
                Debug.Log("tebrikler");
                gorevC.SetActive(false);
                tebrikCanvas.SetActive(true);
                Gorev1Fail.SetActive(false);
                Gorev1Complete.SetActive(true);
                Invoke("DestroyTebrik",5.0f);
                
               
            }
            else
            {
                
                gorevC.SetActive(false);
                kayipkCanvas.SetActive(true);
                Invoke("DestroyKayip", 5.0f);
                skorDus();

                
            }
        }
        

        Debug.Log("hakkınız bitti");
        gorevC.SetActive(false);

    }

    private void skorDus()
    {
        skor -= 10;
        skorT.text = skor.ToString();
    }

    private void skorYap()
    {
        skor += 10;
        skorT.text = skor.ToString();

        if (skor>hskor)
        {
            hskor = skor;
            hskorT.text = hskor.ToString();
            Save(hskor);
        }
    }

    private void Save(int h)
    {
        PlayerPrefs.SetInt("hskor", h);
    }

    private void DestroyTebrik()
    {
        tebrikCanvas.SetActive(false);
       
    }


    private void DestroyKayip()
    {
       kayipkCanvas.SetActive(false);

    }
}

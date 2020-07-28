using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorevIkiControl : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject gorevComplete;
    public GameObject gorevFailed;


    public InputField inp1;
    public InputField inp2;
    public InputField inp3;
    public InputField inp4;
    public InputField inp5;
    public InputField inp6;

    public InputField inp7;
    public InputField inp8;
    public InputField inp9;
    public InputField inp10;
    public InputField inp11;
    public InputField inp12;


    int skor, hskor;
    public Text skorT, hskorT;

    private void Start()
    {
        Load();
    }

    private void Load()
    {
        hskor = PlayerPrefs.GetInt("hskor");
        hskorT.text = hskor.ToString();
    }


    public void ButonGec()
    {
        panel.SetActive(false);
        panel2.SetActive(true);
    }

    public void ButonCont()
    {
        if (inp1.text =="a" && inp2.text == "ad" && inp3.text == "adf" && inp4.text == "adfc" && inp5.text== "adfce" && inp6.text == "adfceb")
        {
            panel2.SetActive(false);
            panel3.SetActive(true);
            skorYap();
        }
     
      
    }

    public void bfsCont()
    {
        if (inp7.text == "a" && inp8.text == "ab" && inp9.text == "abc" && inp10.text == "abcd" && inp11.text == "abcde" && inp12.text == "abcdef")
        {
            panel5.SetActive(false);
            panel6.SetActive(true);
            Invoke("destroyGorev", 5);
            skorYap();
        }
        

    }

    public void destroyGorev()
    {
        gorevFailed.SetActive(false);
        gorevComplete.SetActive(true);
        Destroy(panel6);
    }
    public void butonDevam()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }

    public void bfsDevam()
    {
        panel4.SetActive(false);
        panel5.SetActive(true);
    }

    private void skorYap()
    {
        skor += 10;
        skorT.text = skor.ToString();

        if (skor > hskor)
        {
            hskor = skor;
            hskorT.text = hskor.ToString();
            Save(hskor);
        }
    }

    private void skorDus()
    {
        skor -= 10;
        skorT.text = skor.ToString();
    }

    private void Save(int h)
    {
        PlayerPrefs.SetInt("hskor", h);
    }

}

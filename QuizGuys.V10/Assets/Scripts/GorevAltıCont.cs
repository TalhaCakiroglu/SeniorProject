using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GorevAltıCont : MonoBehaviour
{
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject panel6;
    public GameObject gorevComplete;
    public GameObject gorevFailed;

    public InputField in1;
    public InputField in2;
    public InputField in3;
    public InputField in4;
    public InputField in5;
    public InputField in6;

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


    public void GrammerGec()
    {
        panel.SetActive(false);
        panel2.SetActive(true);
    }

    public void GrammerCont()
    {
        if (in1.text=="0s1" && in2.text=="0011" && in3.text=="0s1" && in4.text =="00s11" && in5.text=="000111")
        {
            panel2.SetActive(false);
            panel3.SetActive(true);
            skorYap();
        }


    }

    public void CFGCont()
    {
        if (in6.text =="1")
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
    public void GrammerTebrikDevam()
    {
        panel3.SetActive(false);
        panel4.SetActive(true);
    }

    public void CFGDevam()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gorev5Control : MonoBehaviour
{
    public GameObject infixPanelT;
    public GameObject infixPanelS;
    public GameObject postfixPanelT;
    public GameObject postfixPanelS;
    public GameObject prefixPanelT;
    public GameObject prefixPanelS;

    public GameObject infixPanelTeb;
    public GameObject postfixPanelTeb;
    public GameObject prefixPanelTeb;

    public GameObject gorevComp;
    public GameObject gorevFail;

    public InputField infixIn;
    public InputField postfixIn;
    public InputField prefixIn;

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


    public void InfixDevamB()
    {
        infixPanelT.SetActive(false);
        infixPanelS.SetActive(true);
    }

    public void PostfixDevamB()
    {
        postfixPanelT.SetActive(false);
        postfixPanelS.SetActive(true);
    }

    public void PrefixDevamB()
    {
        prefixPanelT.SetActive(false);
        prefixPanelS.SetActive(true);
    }

    public void InfixTebGec()
    {
        infixPanelTeb.SetActive(false);
        postfixPanelT.SetActive(true);
    }

    public void PostfixTebGec()
    {
        postfixPanelTeb.SetActive(false);
        prefixPanelT.SetActive(true);
    }

    public void DestroyTeb()
    {
        gorevFail.SetActive(false);
        gorevComp.SetActive(true);
        Destroy(prefixPanelTeb);
    }

    public void InfixCont()
    {
        if (infixIn.text =="33")
        {
            infixPanelS.SetActive(false);
            infixPanelTeb.SetActive(true);
            skorYap();
        }
    }

    public void PostfixCont()
    {
        if (postfixIn.text=="56")
        {
            postfixPanelS.SetActive(false);
            postfixPanelTeb.SetActive(true);
            skorYap();
        }
    }

    public void PrefixCont()
    {
        if (prefixIn.text=="44")
        {
            prefixPanelS.SetActive(false);
            prefixPanelTeb.SetActive(true);
            Invoke("DestroyTeb", 3);
            skorYap();
        }
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

        if (skor > hskor)
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

}

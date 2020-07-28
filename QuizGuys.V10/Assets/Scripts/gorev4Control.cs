using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gorev4Control : MonoBehaviour
{
    public GameObject preorderPanelT;
    public GameObject preorderPanelS;
    public GameObject postorderPanelT;
    public GameObject postorderPanelS;
    public GameObject inorderPanelT;
    public GameObject inorderPanelS;
    public GameObject preorderTebrik;
    public GameObject postorderTebrik;
    public GameObject inorderTebrik;

    public GameObject GorevComp;
    public GameObject GorevFail;

    public InputField inputPre;
    public InputField inputPost;
    public InputField inputIn;

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

    public void preorderGecTan()
    {
        preorderPanelT.SetActive(false);
        preorderPanelS.SetActive(true);
    }

    public void preorderGecTeb()
    {
        preorderTebrik.SetActive(false);
        postorderPanelT.SetActive(true);
    }

    public void postorderGecTan()
    {
        postorderPanelT.SetActive(false);
        postorderPanelS.SetActive(true);
    }

    public void postorderGecTeb()
    {
        postorderTebrik.SetActive(false);
        inorderPanelT.SetActive(true);
    }

    public void inorderGecTan()
    {
        inorderPanelT.SetActive(false);
        inorderPanelS.SetActive(true);
    }

    public void destroyInorder()
    {
        GorevFail.SetActive(false);
        GorevComp.SetActive(true);
        Destroy(inorderTebrik);
    }


    public void preorderCont()
    {
        if (inputPre.text=="15-8-3-13-20-17-16-19-21")
        {
           preorderPanelS.SetActive(false);
           preorderTebrik.SetActive(true);
            skorYap();

        }
    }

    public void postorderCont()
    {
        if (inputPost.text=="5-7-10-8-9-17-24-23-14")
        {
            postorderPanelS.SetActive(false);
            postorderTebrik.SetActive(true);
            skorYap();
        }
    }

    public void inorderCont()
    {
        if (inputIn.text == "1-5-7-13-14-16-18-23-24")
        {
            inorderPanelS.SetActive(false);
            inorderTebrik.SetActive(true);
            
            Invoke("destroyInorder", 5);
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

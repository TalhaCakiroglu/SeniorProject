using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;

public class DiyalogKontrol2 : MonoBehaviour
{
    public GameObject cam;
    public GameObject diyalogUI;
    public GameObject playerUI;

    public GameObject Gorev1Onay;
    public GameObject Gorev2Onay;
    public GameObject Gorev3Onay;
    public GameObject Gorev4Onay;
    public GameObject Gorev5Onay;
    public GameObject Gorev6Onay;


    public Text npcMessage;
    public Text npcName;

    public Text[] diyalogSecenekleri;

    AudioSource ses;

    private void OnEnable()
    {
        Npc.npcDiyalog += DiyalogBaslat;
    }

    private void OnDisable()
    {
        Npc.npcDiyalog -= DiyalogBaslat;

        if (diyalogUI != null)
        {
            DiyalogBitir(null);
        }
    }


    private void Start()
    {
        Gorev1Onay.SetActive(false);
        Gorev2Onay.SetActive(false);
        Gorev3Onay.SetActive(false);
        Gorev4Onay.SetActive(false);
        Gorev5Onay.SetActive(false);
        Gorev6Onay.SetActive(false);
        diyalogUI.SetActive(false);
        ses = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (VD.isActive)
        {
            if (Input.anyKeyDown && !VD.nodeData.isPlayer)
            {
                VD.Next();
            }
        }
    }

    void DiyalogBaslat(VIDE_Assign npcDiyalog)
    {
        if (!VD.isActive)
        {
            VD.OnNodeChange += UIGuncelle;
            VD.OnEnd += DiyalogBitir;
            VD.BeginDialogue(npcDiyalog);
            npcName.text = npcDiyalog.alias;
            diyalogUI.SetActive(true);
            
        }

    }

    

    void UIGuncelle(VD.NodeData data)
    {
        if (data.isPlayer)
        {

            foreach (Transform button in playerUI.transform)
            {
                button.gameObject.GetComponent<Button>().interactable = true;
            }



            for (int i = 0; i < diyalogSecenekleri.Length; i++)
            {
                if (i < data.comments.Length)
                {
                    diyalogSecenekleri[i].transform.parent.gameObject.SetActive(true);
                    diyalogSecenekleri[i].text = data.comments[i];
                }
                else
                {
                    diyalogSecenekleri[i].transform.parent.gameObject.SetActive(false);

                }
            }
        }
        else
        {
            if (data.audios[data.commentIndex] != null)
            {
                ses.clip = data.audios[data.commentIndex];
                ses.Play();
            }

            foreach (Transform button in playerUI.transform)
            {
                button.gameObject.GetComponent<Button>().interactable = false;
            }

            npcMessage.text = data.comments[data.commentIndex];
        }
    }

    void DiyalogBitir(VD.NodeData data)
    {
        VD.OnNodeChange -= UIGuncelle;
        VD.OnEnd -= DiyalogBitir;
        VD.EndDialogue();
        Gorev1Onay.SetActive(true);
        Gorev2Onay.SetActive(true);
        Gorev3Onay.SetActive(true);
        Gorev4Onay.SetActive(true);
        Gorev5Onay.SetActive(true);
        Gorev6Onay.SetActive(true);
        diyalogUI.SetActive(false);

    }

    public void PlayerSecenegi(int secenek)
    {
        VD.nodeData.commentIndex = secenek;
        if (Input.GetMouseButtonUp(0))
        {
            if (VD.nodeData.audios[VD.nodeData.commentIndex] != null)
            {
                ses.clip = VD.nodeData.audios[VD.nodeData.commentIndex];
                ses.Play();
            }

            VD.Next();
        }
    }

}  
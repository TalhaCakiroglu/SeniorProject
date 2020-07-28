using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4 : MonoBehaviour, IEtkilesim
{/*
    public delegate void NpcEvent(VIDE_Assign diyalog);
    public static NpcEvent npcDiyalog;*/
    




    [SerializeField]
    string Npc_name;

    

    public string getName()
    {
        return Npc_name;

    }

    public void etkilesim()
    {
       // npcDiyalog(GetComponent<VIDE_Assign>());
    }
}
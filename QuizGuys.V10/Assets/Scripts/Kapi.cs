using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapi : MonoBehaviour
{
    public Transform sp;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider nesne)
    {
        if (nesne.gameObject.tag == "Player")
        {
            nesne.gameObject.transform.position = sp.position;
        }
    }
}

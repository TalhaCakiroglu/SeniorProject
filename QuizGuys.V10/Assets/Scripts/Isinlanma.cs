using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Isinlanma : MonoBehaviour
{
    public Transform cikis;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = cikis.position;
            other.gameObject.transform.rotation = cikis.rotation;
        }
    }
}

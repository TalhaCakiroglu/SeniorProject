using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplanabilir : MonoBehaviour, IEtkilesim
{
    [SerializeField]
    TemelItem item;
    

    public void etkilesim()
    {
        Debug.Log(getName());
        Destroy(gameObject);
    }





    void Update()
    {
       
    }

    public string getName()
    {
        return item.itemIsmi;
    }


}

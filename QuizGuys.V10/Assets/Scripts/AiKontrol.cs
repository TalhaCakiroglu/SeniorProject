using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKontrol : MonoBehaviour {

    public bool dustumu;
	
	void Start () {
        dustumu = false; //ilk başata nesne false yani düşmedi
	}
	
	void OnCollisionEnter(Collision dustu)
    {
        if (dustu.gameObject.name == "SM_Env_Beach_39") //nesne terrain adlı gameobject e collision u değdiği ise
        {
           
            dustumu = true; //dusme durumunu onayla ve true yap
        }
    }
}

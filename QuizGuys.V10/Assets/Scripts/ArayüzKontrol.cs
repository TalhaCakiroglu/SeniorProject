using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArayüzKontrol : MonoBehaviour
{
    [SerializeField]
    Text etkilesimYazisi;

    private void OnEnable()
    {
        KameraEtkilesimi.itemToplanabilir += EtkilesimeGec;
    }

    private void OnDisable()
    {
        KameraEtkilesimi.itemToplanabilir -= EtkilesimeGec;

    }

    private void Start()
    {
        etkilesimYazisi.gameObject.SetActive(false);
    }

    void EtkilesimeGec(string itemIsmi, bool etkilesim)
    {
        etkilesimYazisi.text = itemIsmi + " ile etkileşime geçmek için E tuşuna bas";
        etkilesimYazisi.gameObject.SetActive(etkilesim);
                
    }

   

}

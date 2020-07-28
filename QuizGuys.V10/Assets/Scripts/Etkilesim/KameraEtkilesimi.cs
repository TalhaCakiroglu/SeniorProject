using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraEtkilesimi : MonoBehaviour
{
    public delegate void KameraEtkileri(string itemIsmi, bool etkilesim);
    public static KameraEtkileri itemToplanabilir;
   
    public GameObject diyalogCanvas;
    public GameObject gorevCanvas;
    public GameObject gorev2Canvas;
    public GameObject gorev3Canvas;
    public GameObject gorev4Canvas;
    public GameObject gorev5Canvas;
    public GameObject gorev6Canvas;
    public GameObject kapi1;
    public GameObject kapi2;
    public GameObject player;
    RaycastHit hit;
    [SerializeField]
    LayerMask etkilesimKatmani;

    [SerializeField]
    float IsinMesafesi;

    IEtkilesim anlikItem;

    

    private void Update()
    {
        if (anlikItem != null && Input.GetKeyDown(KeyCode.E))
        {
            gorevCanvas.SetActive(false);
                diyalogCanvas.SetActive(true);       
                IEtkilesim gecici = anlikItem;
                anlikItem = null;
                gecici.etkilesim();

            if (transform.name == "kapi1")
            {
               player.transform.position = kapi2.transform.position;
            }

            if (transform.name == "kapi2")
            {
               player.transform.position = kapi1.transform.position;
            }


        }
        else
        {
            
            Debug.DrawRay(transform.position, transform.forward * IsinMesafesi, Color.red);

            if (Physics.Raycast(transform.position,transform.forward, out hit, IsinMesafesi, etkilesimKatmani))
            {
                if (hit.transform.name == "charr6")
                {   
                    gorevCanvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "charr5")
                {
                    gorev2Canvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "charr2")
                {
                    gorev3Canvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "charr3")
                {
                    gorev4Canvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "charr1")
                {
                    gorev5Canvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "NPC4")
                {
                    gorev6Canvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "charr4")
                {
                    gorev6Canvas.SetActive(true);
                    diyalogCanvas.SetActive(false);
                }

                if (hit.transform.name == "kapi1")
                {
                    
                    transform.position = new Vector3(kapi2.transform.position.x-5,1,kapi2.transform.position.z-5);
                   
                }

                if (hit.transform.name == "kapi2")
                {
                   transform.position = new Vector3(kapi1.transform.position.x-5,1,kapi1.transform.position.z-5);
                    
                }
                

                IEtkilesim geciciItem = hit.transform.gameObject.GetComponent<IEtkilesim>();
                if (geciciItem != null)
                {
                    anlikItem = geciciItem;
                    itemToplanabilir(anlikItem.getName(), true);
                }
                else
                {
                    anlikItem = null;
                    itemToplanabilir("", false);
                }
            }
        }
    }

}

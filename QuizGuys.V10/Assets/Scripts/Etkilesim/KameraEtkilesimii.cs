using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KameraEtkilesimii : MonoBehaviour
{
    public delegate void KameraEtkileri(string itemIsmi, bool etkilesim);
    public static KameraEtkileri itemToplanabilirr;
    public GameObject diyalogCanvas;
    public GameObject missionCanvas;

    [SerializeField]
    LayerMask etkilesimKatmanii;

    [SerializeField]
    float IsinMesafesii;

    IEtkilesim anlikItemm;

    private void Update()
    {
        if (anlikItemm != null && Input.GetKeyDown(KeyCode.E))
        {
            missionCanvas.SetActive(false);
            diyalogCanvas.SetActive(true);
            IEtkilesim gecicii = anlikItemm;
            anlikItemm = null;
            gecicii.etkilesim();


        }
        else
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * IsinMesafesii, Color.red);

            if (Physics.Raycast(transform.position, transform.forward, out hit, IsinMesafesii, etkilesimKatmanii))
            {
                IEtkilesim geciciItem = hit.transform.gameObject.GetComponent<IEtkilesim>();
                if (geciciItem != null)
                {
                    anlikItemm = geciciItem;
                    itemToplanabilirr(anlikItemm.getName(), true);
                }
                else
                {
                    anlikItemm = null;
                    itemToplanabilirr("", false);
                }
            }
        }
    }
}

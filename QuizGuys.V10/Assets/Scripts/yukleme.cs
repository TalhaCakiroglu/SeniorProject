using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class yukleme : MonoBehaviour
{

    public float sayi;
    public Text sayiyazi;
    public GameObject bar, ekran, fps, silinecekCam;
    void Start()
    {
        ekran.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (sayi < 100)
        {
            sayi += Time.deltaTime * 30;
        }
        if (sayi >= 100)
        {
            sayi = 100;
            ekran.SetActive(false);
            silinecekCam.SetActive(false);
            fps.SetActive(true);


        }
        sayiyazi.text = "%" + (int)sayi;
        bar.transform.localScale = new Vector3(sayi / 100, 1, 1);
    }

}

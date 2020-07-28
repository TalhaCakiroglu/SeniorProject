using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiKarakterKontrol : MonoBehaviour {

    public Transform hedef; //ana karakter
    public float hiz, mesafe, sagSol, yukariAsagi; //yapay zekanın yürüme hızı ve ana karakterle olan mesafesi, sagsolyukarıasağı yazının pozisyonu için
    public bool dialog, haraket; //diyalog işlemleri
    public string y1, y2, y3; // diyaloglar
    GUIStyle yaziOzellik = new GUIStyle(); //yazının fontu rengi
    Animator animatorController;


    AiKontrol AiScp; //yapayzekanın etkinsini alacağı nesnenin preefabı, nesnenin posisyon özelliklerini çekme
    public GameObject Etki; //unitydeki küp


    void Start () {
        animatorController = GetComponent<Animator>();
        AiScp = Etki.GetComponent<AiKontrol>(); //Etkiyi başlatma
	}
	
	
	void Update () {
        mesafe = Vector3.Distance(transform.position, hedef.position); //ana karaker ile yapay zeka arasındaki mesafe tanımı
        Vector3 takip = new Vector3(hedef.position.x, transform.position.y, hedef.position.z); //yapay zekanınn ana karakeri takip mesafesi
        if (mesafe < 15) 
        {
            setIdleAnimation();
            haraket = true;  //kovalayacak 
            dialog = false;
        }
        if(mesafe < 10 && haraket == true && AiScp.dustumu==true)
        {
            setWalkingAnimation();
            transform.position = Vector3.MoveTowards(transform.position, hedef.position, hiz * Time.deltaTime);  // nesne düştü karakterimi kovalayacak
            transform.LookAt(takip);//karakterimizin pozisyonuna göre yönelecek
        }
        if (mesafe < 5 && AiScp.dustumu == true)
        {
            setWalkingAnimation();
            haraket = false;  // haraketi durdur
            dialog = true;
        }
	}

    void OnGUI() //yazının ekranda çıkma komutu
    {
        if(mesafe < 5 && haraket == true && AiScp.dustumu == false) //yazı1
        {
            setIdleAnimation();
            yaziOzellik.fontSize = 20; //yazının boyutu 
            yaziOzellik.normal.textColor = Color.black;//yazının rengi
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(sagSol, yukariAsagi, 0f);//yazının kamerada görünmesi + pozisyonu
            GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 30), y1, yaziOzellik);// yazıyı label olarak özelliği ile çağırma
        }

        if (dialog=false && AiScp.dustumu == true)//yazı2
        {
            setWalkingAnimation();
            yaziOzellik.fontSize = 20;//yazının boyutu
            yaziOzellik.normal.textColor = Color.black;//yazının rengi
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(sagSol, yukariAsagi, 0f);//yazının kamerada görünmesi + pozisyonu
            GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 30), y2, yaziOzellik);// yazıyı label olarak özelliği ile çağırma
        }

        if (dialog = true && AiScp.dustumu == true)//yazı3
        {
            setWalkingAnimation();
            yaziOzellik.fontSize = 20;//yazının boyutu
            yaziOzellik.normal.textColor = Color.black;//yazının rengi
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(sagSol, yukariAsagi, 0f); //yazının kamerada görünmesi + pozisyonu
            GUI.Label(new Rect(pos.x, Screen.height - pos.y, 100, 30), y3, yaziOzellik); // yazıyı label olarak özelliği ile çağırma
        }
    }

    public void setIdleAnimation()
    {
        animatorController.SetTrigger("Idle");
    }


    public void setWalkingAnimation()
    {
        animatorController.SetTrigger("Walking");
    }
}

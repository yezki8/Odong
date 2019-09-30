using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Halte : MonoBehaviour {
    public MoveOnPath OdongIPA;
    public float waktuTunggu;      //Odong menunggu di halte selama 3 detik
    public float orangNaik;         //nbanyaknya penumpang yang turun
    public float turun;             //jumlah orang naik odong
    public bool berhenti = false;      // bool status dimana odong berhenti atau tidak
    public float penunggu = 0;
    public Text IPenunggu;          //text ukuran penunggu di halte
    public float kepadatan;         //pertumbuhan penumpang di suatu halte
    public float waktuTenggang;     //Waktu untuk penampilan emoji sad
    
    public GameObject SadEmoji;
    //time button
    public float t;         //waktu referensi untuk 3 tombol dibawah
    public Button Play, Pause, Fast;

    // Use this for initialization
    void Start (){

        //deklarasi fungsi void 3 tombol
        Play.onClick.AddListener(PlayOnClick);
        Pause.onClick.AddListener(PauseOnClick);
        Fast.onClick.AddListener(FastOnClick);

        waktuTunggu = 1;
        kepadatan = 0.5f;
        t = 0;
        //waktuTenggang = 0;
        SadEmoji.SetActive(false);
    }	
	// Update is called once per frame
	void Update (){
        
        //update detik per frame
        if(penunggu < 25)
        {
            penunggu += (Time.deltaTime * kepadatan * t);
            SadEmoji.SetActive(false);
            Debug.Log("tidak sedihhhh");
        }
        else {
            penunggu = 25;
            SadEmoji.SetActive(true);
            Debug.Log("sedihhhh");
        }
        
        //waktuTenggang += Time.deltaTime * t;
        //konvert i penunggu ke angka

        if (IPenunggu != null){
            IPenunggu.text = penunggu.ToString("F0");
        }
        //sistemasi waktu berhenti odong
        if (berhenti == true){
            waktuTunggu = waktuTunggu - (Time.deltaTime * t);
        }
        //odong mulai jalan setelah waktu berhenti selesai
        if (berhenti == true && waktuTunggu <= 0){
            OdongIPA.speed = 0.5f * t;
            berhenti = false;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "odong"){
            turun = Random.Range(0, OdongIPA.penumpang);
            berhenti = true;
            //print("berhenti");
            OdongIPA.speed = 0;
            SadEmoji.SetActive(false);
            //OdongIPA.penumpang = OdongIPA.penumpang - 5;
            //cek kapasitas per halte
            //penunggu = penunggu - (20 - OdongIPA.penumpang);
            //OdongIPA.sisaKursi = 20 - OdongIPA.penumpang;      //sisa kursi = kapasitas - isi

            if (OdongIPA.penumpang != 0)
            {
                OdongIPA.penumpang -= turun;
                OdongIPA.sisaKursi = 20 - OdongIPA.penumpang;
            }
            if (OdongIPA.sisaKursi >= penunggu) {
                orangNaik = penunggu;
                OdongIPA.penumpang += orangNaik;
                OdongIPA.sisaKursi = 20 - OdongIPA.penumpang;
                penunggu = 0;
            }
            else if (OdongIPA.sisaKursi < penunggu)               // jika penunggu lebis banyak dari sisa kursi
            {
                orangNaik = OdongIPA.sisaKursi;
                penunggu = penunggu - OdongIPA.sisaKursi;           //Jika sisa kursi lebih sedikit dari penunggu di halte
                OdongIPA.penumpang += orangNaik;
                OdongIPA.sisaKursi = 20 - OdongIPA.penumpang;       //Sisa kursi disesuaikan dengan penumpang
            }
            waktuTunggu = waktuTunggu + orangNaik + turun;
            
        }
    }

    public void PlayOnClick()
    {
        this.t = 1;
    }

    public void PauseOnClick()
    {
        this.t = 0;
    }

    public void FastOnClick()
    {
        this.t = 5.66f;
    }

    void SetActiveEmojiSad(GameObject SadEmoji)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveOnPath : MonoBehaviour {
    public Path pathToFollow;
    private int currentWayPointID = 0;                               //harus private
    public float speed;             //kecepatan jalan Odong          //harus public
    private float reachDistance = 0.001f;
    public float rotationSpeed = 5.0f;      //kecepatan rotasi odong
    public string pathName;                 //nama jalur
    public float penumpang;                 //jumlah penumpang       //harus public
    public Text kapasitasText;                  
    public float sisaKursi = 20;
    public bool activeCol = true;
    Vector2 lastPosition;
    Vector2 currentPosition;

    public Halte halte;
    //time button
    float t;
    public Button Play, Pause, Fast;
    public float waktuTenggang;     //waktu non aktifnya collider

    // Use this for initialization
    void Start () {
        Play.onClick.AddListener(PlayOnClick);
        Pause.onClick.AddListener(PauseOnClick);
        Fast.onClick.AddListener(FastOnClick);
        this.speed = 0;
        lastPosition = transform.position;
        penumpang = 0;
    }	
	// Update is called once per frame
	void Update () {
        if (kapasitasText != null){
            kapasitasText.text = this.penumpang.ToString("F0");
        }

        float distance = Vector2.Distance(pathToFollow.nodes[currentWayPointID].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, pathToFollow.nodes[currentWayPointID].position, Time.deltaTime * this.speed);

        var rotation = Quaternion.LookRotation(pathToFollow.nodes[currentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if (distance <= reachDistance)        {
            currentWayPointID++;
        }
        if (currentWayPointID >= pathToFollow.nodes.Count){
            currentWayPointID = 0;
        }
        
        //fungs non atifkan collider bus biar nggak nabrak terus
        if (this.speed <= 0)                                             //bila bus berhenti
        {                                                       
            if ( waktuTenggang > 0)                                 //dan waktu tenggang lebih besar dari 0
            {
                GetComponent<Collider>().enabled = false;           //maka collider bus non aktif
            }
        }
        else if(this.speed > 0)                                          //Bila bus sedang jalan
        {
            waktuTenggang = waktuTenggang - (Time.deltaTime * t);   //maka waktu tenggang berkurang per detik (sesuai alur waktunya)
            if (waktuTenggang <= 0)                                 //jika waktu tenggang dibawah nol
            {
                GetComponent<Collider>().enabled = true;            //maka collider bus akan menyala
                activeCol = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {        
        //Setiap bus kena collider halte, naka waktu tenggang menjadi 2
        if (other.transform.tag == "halte")
        {
            activeCol = false;
            this.waktuTenggang = 2;
        }
    }

    public void PlayOnClick(){
        this.speed = 0.53f;  // karena bila speed = 3 maka odong akan memutar unpad selama 70 detik tanpa berhenti, sedangkan pada realtime dibutuhkan 390 detik untuk 1 lap tanpa odong berhenti. Perbandingan = 1:5.5
        this.t = 1;
    }

    public void PauseOnClick(){
        this.speed = 0;
        this.t = 0;
    }

    public void FastOnClick(){
        this.speed = 3;
        this.t = 5.66f;
    }
}

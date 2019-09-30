using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waktu : MonoBehaviour {
    public float detik, menit, jam;    
    bool sore = false;
    public Text txtDetik, txtMenit, txtJam;

    //time button
    float t;
    public Button Play, Pause, Fast;

    // Use this for initialization
    void Start (){
        Play.onClick.AddListener(PlayOnClick);
        Pause.onClick.AddListener(PauseOnClick);
        Fast.onClick.AddListener(FastOnClick);
        t = 0;
        detik = 0;
        menit = 0;
        txtDetik.text = detik.ToString("F0");
        txtMenit.text = menit.ToString("F0");

        if (sore == false){            
            jam = 7;
            txtJam.text = jam.ToString("F0");
        }
        else{
            jam = 12;
            txtJam.text = jam.ToString("f0");
        }
	}
	
	// Update is called once per frame
	void Update () {
        t = this.t;
        detik += Time.deltaTime * t;
        if (detik < 60){
            txtDetik.text = detik.ToString("F0");
        }
        else {
            menit += 1;
            detik = 0;
            if(menit < 60)
            {
                txtMenit.text = menit.ToString("f0");
            }
            else
            {
                jam += 1;
                menit = 0;
                txtJam.text = jam.ToString("f0");
            }            
        }		
	}
    public void PlayOnClick(){
        this.t = 1;
    }

    public void PauseOnClick(){
        this.t = 0;
    }

    public void FastOnClick(){
        this.t = 5.66f;    //3 : 0.54
    }
}

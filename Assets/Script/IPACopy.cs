using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPACopy : MonoBehaviour {
    public GameObject busIPA;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Copy()
    {
        Instantiate(busIPA, new Vector3(0.8287673f, -0.2305253f, -0.1471569f), transform.rotation);
        busIPA.transform.parent = transform;
    }
}

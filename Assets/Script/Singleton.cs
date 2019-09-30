using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    public static Singleton instance = null;
    public int currentWayPointID = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

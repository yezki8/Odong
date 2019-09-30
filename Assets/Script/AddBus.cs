using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBus : MonoBehaviour {

    MoveOnPath odong;
    public GameObject OriOdong;
    public GameObject ParOdong;
    GameObject CloneOdong;

    GameObject SetClone;
    int point;
    int nomor = 1;

	public void addClone()
    {
        nomor += 1;
        CloneOdong = Instantiate(OriOdong, transform.position, transform.rotation) as GameObject;
        CloneOdong.transform.parent = transform;
        CloneOdong.transform.localScale = new Vector3(0.1989334f, 0.1989334f, 0.1989334f);
        CloneOdong.name = "ipa_" + nomor.ToString();

        //SetClone = GameObject.Find("ipa_" + nomor.ToString());
        //SetClone.GetComponent < currentWayPointID > = 0;
        //point = 0;
        //this.odong.currentWayPointID = point;
    }
}

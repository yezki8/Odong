using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBus : MonoBehaviour {

    MoveOnPath odong;
    public GameObject OriOdong;
    public GameObject ParOdong;
    public GameObject SpawnerLocation;
    GameObject CloneOdong;
    public int wayPoint = 0;

    GameObject SetClone;
    int point;
    int nomor = 1;

	public void addClone()
    {
        nomor += 1;
        CloneOdong = Instantiate(OriOdong, transform.position, transform.rotation) as GameObject;
        CloneOdong.transform.parent = ParOdong.transform;
        CloneOdong.transform.position = new Vector3(29.86314f, 1.4603f, 0);
        CloneOdong.transform.localScale = new Vector3(1, 1, 1);
        CloneOdong.name = "bus_" + nomor.ToString();

        //SetClone = GameObject.Find("ipa_" + nomor.ToString());
        //SetClone.GetComponent < currentWayPointID > = 0;
        //point = 0;
        //this.odong.currentWayPointID = point;
    }
}

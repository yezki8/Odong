using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBus : MonoBehaviour {

    MoveOnPath odong;
    public GameObject IpaOdong;
    public GameObject IpsOdong;
    public GameObject ParOdong;
    public GameObject SpawnerLocation;
    GameObject CloneOdong;
    public int wayPoint = 0;

    GameObject SetClone;
    int point;
    int nomor = 1;

	public void addCloneIpa()
    {
        nomor += 1;
        CloneOdong = Instantiate(IpaOdong, transform.position, transform.rotation) as GameObject;
        CloneOdong.transform.parent = ParOdong.transform;
        CloneOdong.transform.position = SpawnerLocation.transform.position;
        CloneOdong.transform.localScale = IpaOdong.transform.localScale;
        CloneOdong.name = "Bus_" + nomor.ToString();

        //SetClone = GameObject.Find("ipa_" + nomor.ToString());
        //SetClone.GetComponent < currentWayPointID > = 0;
        //point = 0;
        //this.odong.currentWayPointID = point;
    }

    public void addCloneIps()
    {
        nomor += 1;
        CloneOdong = Instantiate(IpsOdong, transform.position, transform.rotation) as GameObject;
        CloneOdong.transform.parent = ParOdong.transform;
        CloneOdong.transform.position = SpawnerLocation.transform.position;
        CloneOdong.transform.localScale = IpsOdong.transform.localScale;
        CloneOdong.name = "Bus_" + nomor.ToString();

        //SetClone = GameObject.Find("ipa_" + nomor.ToString());
        //SetClone.GetComponent < currentWayPointID > = 0;
        //point = 0;
        //this.odong.currentWayPointID = point;
    }
}

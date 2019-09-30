using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public Color lineColor;     //deklarasi warna jalur

    public List<Transform> nodes = new List<Transform>();       //deklarasi list titik/node

    void OnDrawGizmosSelected()
    {
        Gizmos.color = lineColor;       //untuk memberi warna jalur

        Transform[] pathTransforms = GetComponentsInChildren<Transform>();      //mengambil komponen children
        nodes = new List<Transform>();          //membuat list titik yang nanti akan membentuk jalur

        //memasukkan setiap titik(node) yang ada ke dalam list
        for(int i=0; i<pathTransforms.Length; i++)      
        {
            if (pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        //membuat garis antar titik(node)
        for (int i=0; i<nodes.Count; i++)
        {
            Vector2 currentNode = nodes[i].position;        //titik saat ini
            Vector2 previousNode = Vector2.zero;            //titik sebelumnya

            //penentuan titi sebelumnya jika i>0
            if (i > 0)
            {
                previousNode = nodes[i - 1].position;
            }
            //penentuan titi sebelumnya jika i == 0 dan nodes.Count > 1
            else if (i == 0 && nodes.Count > 1)
            {
                previousNode = nodes[nodes.Count - 1].position;
            }

            Gizmos.DrawLine(previousNode, currentNode);     // membuat garis antara titik saat ini dan titik sebelumnya
            Gizmos.DrawWireSphere(currentNode, 0.05f);      //membuat wire sphere pada titik saat ini
        }
    }
}

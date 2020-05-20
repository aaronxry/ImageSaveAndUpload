using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINIMap : MonoBehaviour {
    public Transform t1; //红
    public Transform t2; //黄
    public Transform t3; //蓝  
    public Transform dot; //绿

    // Update is called once per frame
    void Start () {
        SetPos (1524, 1);
    }

    //x和6坐标，输入坐标。更新在小地图上的位置
    public void SetPos (int x, int y) {
        Vector3 vecX = t2.position - t1.position;
        Vector3 vecY = t3.position - t1.position;
        Vector3 endPos = t1.position + vecX * x / 1524 + vecY * y / 1524;
        dot.position = endPos;
    }
}
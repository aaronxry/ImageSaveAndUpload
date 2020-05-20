using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcollertest : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // void OnTriggerEnter2D (Collider2D collider) {
    //     Debug.Log ("开始接触");
    //     Debug.Log (collider.name);
    // }

    // void OnTriggerExit2D (Collider2D collider) {　
    //     if (collider != null) {　　
    //         Debug.Log ("接触结束");　
    //         Debug.Log (collider.name);
    //     }
    // }

    // Update is called once per frame
    void Update () {
         if (Input.GetMouseButton (0)) {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll (ray.origin, ray.direction);
            RaycastHit hit;
            if (Physics.Raycast (ray, out hit)) {
                Debug.Log ("move" + hit.transform.position);
            }else{
                Debug.Log("no");
            }
        }
        // if (Input.GetMouseButtonDown (0)) {
        //     Vector3 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     RaycastHit2D hitInfo = Physics2D.Raycast(new Vector2(v.x, v.y), new Vector2(v.x, v.y),0.1f);//射线碰撞
        //     if (Physics2D.Raycast(new Vector2(v.x, v.y), new Vector2(v.x, v.y), 0.1f))
        //     {  
        //         //Destroy(redpoint);//销毁上一个点
        //         // Debug.DrawLine(new Vector2(v.x, v.y), hitInfo.point);//绘制射线
        //         //  gameObj = hitInfo.collider.gameObject;
        //         Debug.Log(hitInfo);
        //     }
        // }
        // if (Input.GetMouseButtonDown (0)) {
        //     Collider2D[] col = Physics2D.OverlapPointAll (Camera.main.ScreenToWorldPoint (Input.mousePosition));

        //     if (col.Length > 0) {
        //         foreach (Collider2D c in col) {
        //           Debug.Log("bb"+c);
        //         }
        //     }
        // }

        // if (Input.GetMouseButtonDown (0)) {
        //     Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast (ray, out hit)) {
        //         GameObject selectedGmObj = hit.collider.gameObject; //获得点击的物体
        //         Debug.Log (hit.point);
        //     } else {
        //         Debug.Log ("nohit");
        //     }
        // }
        // if (Input.GetMouseButton (0)) {
        //     //   Debug.Log("mmmm");
        //     Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast (ray, out hit)) {
        //         GameObject selectedGmObj = hit.collider.gameObject; //获得点击的物体
        //         Debug.Log (hit.point);
        //     } else {
        //         Debug.Log ("nohit");
        //     }
        // }
    }
    // void OnGUI () {
    // if (Input.GetMouseButton (0)) {
    //     Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    //     RaycastHit hit;
    //     if (Physics.Raycast (ray, out hit)) {
    //         GameObject selectedGmObj = hit.collider.gameObject; //获得点击的物体
    //         if (selectedGmObj.name.Contains ("Face")) {
    //             Debug.Log ("Face");
    //         } else if (selectedGmObj.name.Contains ("Hair")) {
    //             Debug.Log ("Hair");
    //         } else if (selectedGmObj.name.Contains ("Clothes")) {
    //             Debug.Log ("Clothes");
    //         } else {
    //             Debug.Log ("Accessory");
    //         }
    //     } else {
    //         Debug.Log ("a");
    //     }
    // }
    // }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXTools : MonoBehaviour {
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch ();    

    // Update is called once per frame
    void Update ()    {       
        if (Input.GetKeyDown (KeyCode.G)) {           
            StartExeTime ();       
            EndExeTime();
        }   
    } 

      
    void StartExeTime ()    {       
           
        stopwatch.Start (); //  开始监视代码运行时间       
         
    }   

    void EndExeTime()
    {
        stopwatch.Stop (); //  停止监视    
        System.TimeSpan timespan = stopwatch.Elapsed;        //   double hours = timespan.TotalHours; // 总小时    
        double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数     
        Debug.Log ("耗时毫秒："+milliseconds);
    }
      
}
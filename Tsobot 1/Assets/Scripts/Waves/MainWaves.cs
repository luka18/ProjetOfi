using UnityEngine;
using System.Collections;

public class MainWaves : MonoBehaviour {
    private int numbofchild;
    private float timetowait = 2f;
    private float timebuffer;
    private int i = 0;

	// Use this for initialization
	void Start () {
        numbofchild = transform.childCount;
      
	}
	
	// Update is called once per frame
	void Update () {

        if(timebuffer>timetowait && i<numbofchild)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            i++;
            if(i ==4)
            {
                timetowait = 3;
            }
            if(i==5)
            {
                timetowait = 1;
                print(transform.GetChild(i - 1));
            }
            if(i==6)
            {
                timetowait = 3f;
                
            }
            if(i==7)
            {
                timetowait = 0.6f;
            }
            if(i==20)
            {
                timetowait = 1.5f;
            }
           



            timebuffer = 0;
        }
        timebuffer += Time.deltaTime;


    }
}

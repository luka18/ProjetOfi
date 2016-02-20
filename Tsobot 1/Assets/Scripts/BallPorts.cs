using UnityEngine;
using System.Collections;

public class BallPorts : MonoBehaviour {
    [SerializeField] ButtonsColor bt;


    void OnCollisionEnter(Collision col)
    {

        if(col.transform.tag == "Ball")
        {
            bt.NextLevel();
        }
    }

}

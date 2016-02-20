using UnityEngine;
using System.Collections;

public class BallTrigger : MonoBehaviour {
    [SerializeField] ButtonsColor bt;

    void OnTriggerEnter(Collider col)
    {
        print("trigered");
        bt.NextLevel();

    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class OnStartDisable : MonoBehaviour {

	void Start()
    {
        print(transform.name);
        print(transform.childCount);
        foreach(NetworkTransform k in transform.gameObject.GetComponentsInChildren<NetworkTransform>())
        {
            print("passed");
            k.enabled = false;
        }
    }

}

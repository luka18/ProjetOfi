using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TestNet : NetworkBehaviour {
	// Update is called once per frame

	void Update () {
        print(transform.name);
	
	}
}

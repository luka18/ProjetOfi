using UnityEngine;
using System.Collections;

public class OnStartDisable : MonoBehaviour {

	void Start()
    {
        transform.gameObject.SetActive(false);
    }
}

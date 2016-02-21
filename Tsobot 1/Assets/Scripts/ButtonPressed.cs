using UnityEngine;
using System.Collections;

public class ButtonPressed : MonoBehaviour {

    [SerializeField] private Material colo;

    public void press()
    {
        
        transform.localScale = new Vector3(0.4f, 0.4f, 0.1f);
        transform.GetComponent<MeshRenderer>().material = colo;
    }


}

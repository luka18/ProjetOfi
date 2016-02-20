using UnityEngine;
using System.Collections;

public class BackToFront : MonoBehaviour {
    public int speed = 3;
    private float go;
    void Update()
    {
        go = speed * Time.deltaTime;
        transform.Translate(0, 0, go);
        if (transform.position.z > 25)
        {
            gameObject.SetActive(false);
        }
    }
}

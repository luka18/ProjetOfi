using UnityEngine;
using System.Collections;

public class UpToDown : MonoBehaviour {

    public int speed = 3;
    private float go;
    void Update()
    {
        go = speed * Time.deltaTime;
        transform.Translate(0, -go, 0);
        if (transform.position.y < -10.25)
        {
            gameObject.SetActive(false);
        }
    }
}
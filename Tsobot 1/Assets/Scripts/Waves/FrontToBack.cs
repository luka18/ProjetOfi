using UnityEngine;
using System.Collections;

public class FrontToBack : MonoBehaviour {
    public int speed = 5;
    private float go;

    void Update()
    {
        go = speed * Time.deltaTime;

        transform.Translate(0, 0, -go);

        if (transform.position.z < 4.5f)
        {
            gameObject.SetActive(false);
        }


    }
}
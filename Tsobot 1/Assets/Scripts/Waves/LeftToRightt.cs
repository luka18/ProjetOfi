using UnityEngine;
using System.Collections;

public class LeftToRightt : MonoBehaviour
{
    
    public int speed = 3;
    private float go;
    void Update()
    {
        go = speed * Time.deltaTime;
        transform.Translate(go, 0, 0);
        if (transform.position.x > 38)
        {
            gameObject.SetActive(false);
        }
    }

}


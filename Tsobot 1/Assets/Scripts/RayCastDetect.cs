using UnityEngine;
using System.Collections;

public class RayCastDetect : MonoBehaviour {
    private Transform cam;

    void Start()
    {
        cam = transform.FindChild("Camera");
    }

    public ButtonsColor btc;

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("draw");
            RaycastHit hit;
            Debug.DrawRay(transform.position + new Vector3(0, 2.0f, 0), cam.transform.forward * 3, Color.black, 1.0f);
            if ((Physics.Raycast(transform.position + new Vector3(0, 2.0f, 0), cam.transform.forward, out hit, 3.0f)))
            {
                if (hit.transform.tag == "Button")
                {
                    switch (hit.transform.name)
                    {
                        case "1Batton":
                            Batonnets.gethowmany = 1;
                            break;
                        case "2Batton":
                            Batonnets.gethowmany = 2;
                            break;
                        case "3Batton":
                            Batonnets.gethowmany = 3;
                            break;
                        case "Bouton bleu":
                            btc.dropball(1);
                            hit.transform.GetComponent<ButtonPressed>().press();
                            break;
                        case "Bouton violet":
                            btc.dropball(2);
                            hit.transform.GetComponent<ButtonPressed>().press();
                            break;
                        case "Bouton vert":
                            btc.dropball(3);
                            hit.transform.GetComponent<ButtonPressed>().press();
                            break;
                        case "Bouton rouge":
                            btc.dropball(4);
                            hit.transform.GetComponent<ButtonPressed>().press();
                            break;
                        case "BoutonRed":
                            hit.transform.GetComponent<ButtonPressedOnce>().press();
                            break;
                        case "BoutonBleu":
                            hit.transform.GetComponent<ButtonPressedOnce>().press();
                            break;
                        case "BoutonVert":
                            hit.transform.GetComponent<ButtonPressedOnce>().press();
                            break;
                        case "BoutonViolet":
                            hit.transform.GetComponent<ButtonPressedOnce>().press();
                            break;
                        case "BoutonGreen":
                            hit.transform.GetComponent<ButtonPressed>().press();
                            hit.transform.GetComponent<StartWaves>().go();
                            break;
                        

                    }
                }


            }


        }

    }
}

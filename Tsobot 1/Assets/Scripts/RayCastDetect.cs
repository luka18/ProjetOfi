using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RayCastDetect : NetworkBehaviour {
    private Transform cam;
    [SyncVar]
    private NetworkIdentity objNetId;

    public ButtonsColor btc;

    void Start()
    {
        cam = transform.FindChild("Camera");
    }
    //------------------------------------------RPC-----------------------------------------
    [ClientRpc]
    void RpcDrop(GameObject obj, int typeball)
    {
        obj.GetComponentInParent<ButtonsColor>().dropball(typeball);
    }

    [ClientRpc]
    void RpcPressOnce(GameObject obj)
    {
        obj.GetComponent<ButtonPressedOnce>().press();
    }

    [ClientRpc]
    void RpcPress(GameObject obj)
    {
        obj.GetComponent<ButtonPressed>().press();
    }
    [ClientRpc]
    void RpcBaton(GameObject obj, int i)
    {
        obj.transform.GetComponentInParent<Batonnets>().Plays(i);
    }
    [ClientRpc]
    void RpcWaves(GameObject obj)
    {
        obj.GetComponent<StartWaves>().go();
    }
    // ----------------------------------------------------- COMMAND---------------------------------------------
    [Command]
    void CmdPress(GameObject obj, int k)
    {
        objNetId = obj.GetComponent<NetworkIdentity>();
        objNetId.AssignClientAuthority(connectionToClient);
        switch (k)
        {
            case 1:
                RpcPressOnce(obj);
                break;
            case 2:
                RpcPress(obj);
                break;
        }
        objNetId.RemoveClientAuthority(connectionToClient);
    }
    [Command]
    void CmdDrop(GameObject obj, int typeball)
    {
        RpcDrop(obj, typeball);
    }
    [Command]
    void CmdBaton(GameObject obj, int i)
    {
        RpcBaton(obj, i);
    }
    [Command]
    void CmdWaves(GameObject obj)
    {
        RpcWaves(obj);
    }



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
                            CmdBaton(hit.transform.gameObject, 1);
                            break;
                        case "2Batton":
                            CmdBaton(hit.transform.gameObject, 2);
                            break;
                        case "3Batton":
                            CmdBaton(hit.transform.gameObject, 3);
                            break;
                        case "Bouton bleu":
                            CmdPress(hit.transform.gameObject, 2);
                            CmdDrop(hit.transform.gameObject, 1);
                            break;
                        case "Bouton violet":
                            CmdPress(hit.transform.gameObject, 2);
                            CmdDrop(hit.transform.gameObject, 2);
                            break;
                        case "Bouton vert":
                            CmdPress(hit.transform.gameObject, 2);
                            CmdDrop(hit.transform.gameObject, 3);
                            break;
                        case "Bouton rouge":
                            CmdPress(hit.transform.gameObject, 2);
                            CmdDrop(hit.transform.gameObject, 4);
                            break;
                        case "BoutonRed":
                            CmdPress(hit.transform.gameObject,1);
                            break;
                        case "BoutonBleu":
                            //hit.transform.GetComponent<ButtonPressedOnce>().press();
                            CmdPress(hit.transform.gameObject,1);
                            break;
                        case "BoutonVert":
                            CmdPress(hit.transform.gameObject,1);// 2 = any time you want 1 = one time
                            break;
                        case "BoutonViolet":
                            CmdPress(hit.transform.gameObject,1);
                            break;
                        case "BoutonGreen":
                            CmdPress(hit.transform.gameObject, 2);
                            CmdWaves(hit.transform.gameObject);
                            break;
                        

                    }
                }


            }


        }

    }
}

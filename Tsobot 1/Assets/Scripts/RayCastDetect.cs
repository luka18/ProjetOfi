﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RayCastDetect : NetworkBehaviour {
    private Transform cam;
    [SyncVar]
    private NetworkIdentity objNetId;

    NetworkInstanceId  ViewID;
    
    public ButtonsColor btc;
    private bool carrying = false;
    private Quaternion rot;
    private GameObject OldParent;
    private NetworkIdentity ObjCarry;

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
    void RpcPressOnce(GameObject obj, int num)
    {
        obj.GetComponent<ButtonPressedOnce>().press();
        obj.GetComponent<CallMeColors>().call(num);
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
    [ClientRpc]
    void RpcCarry(NetworkIdentity obj)
    {
        Carry(obj);
    }
    [ClientRpc]
    void RpcUnCarry(NetworkIdentity obj)
    {
        UnCarry(obj);
    }
    // ----------------------------------------------------- COMMAND---------------------------------------------
    [Command]
    void CmdPress(GameObject obj)
    {
        objNetId = obj.GetComponent<NetworkIdentity>();
        objNetId.AssignClientAuthority(connectionToClient);
        RpcPress(obj);
        objNetId.RemoveClientAuthority(connectionToClient);
    }

    [Command]
    void CmdPressOnce(GameObject obj, int k)
    {
        RpcPressOnce(obj, k);
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
    [Command]
    void CmdCarry(NetworkIdentity obj)
    {
        RpcCarry(obj);
    }
    [Command]
    void CmdUnCarry(NetworkIdentity obj )
    {
       
        RpcUnCarry(obj);
    }


    //-----------------NO NETWORK FROM HERE-------------------

    void UnCarry(NetworkIdentity NetID)
    {
        GameObject car = NetID.gameObject;
        car.GetComponent<NetworkTransform>().enabled = true;
        car.transform.localPosition = new Vector3(0, 2, 2f);
        car.transform.SetParent(OldParent.transform);
        car.GetComponent<Rigidbody>().isKinematic = false;
        car.transform.rotation = rot;
        carrying = false;
        car.transform.tag = "Portal";

    }
    
    void Carry(NetworkIdentity NetID)
    {
        
        GameObject car = NetID.gameObject;
        car.tag = "Untagged"; 
        OldParent = car.transform.parent.gameObject;
        car.GetComponent<Rigidbody>().isKinematic = true;
        car.transform.SetParent(transform);
        car.transform.localPosition = new Vector3(0, 3f, 0);
        car.GetComponent<NetworkTransform>().enabled = false;
        carrying = true;
        rot = car.transform.rotation;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position + new Vector3(0, 2.0f, 0), cam.transform.forward * 3, Color.black, 1.0f);
            if (carrying)
            {
                Debug.DrawRay(transform.position , transform.forward, Color.black, 1.0f);
                if (!Physics.Raycast(transform.position+new Vector3(0,1,0), transform.forward, out hit, 3.0f))
                {

                    CmdUnCarry(ObjCarry);
                }
            }


            
            else if ((Physics.Raycast(transform.position + new Vector3(0, 2.0f, 0), cam.transform.forward, out hit, 3.0f)))
            {
                if(hit.transform.tag == "Portal")
                {
                    
                    ObjCarry = hit.transform.GetComponent<NetworkIdentity>();
                    CmdCarry(hit.transform.GetComponent<NetworkIdentity>());
                    
                }
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
                            CmdPress(hit.transform.gameObject);
                            CmdDrop(hit.transform.gameObject, 1);
                            break;
                        case "Bouton violet":
                            CmdPress(hit.transform.gameObject);
                            CmdDrop(hit.transform.gameObject, 2);
                            break;
                        case "Bouton vert":
                            CmdPress(hit.transform.gameObject);
                            CmdDrop(hit.transform.gameObject, 3);
                            break;
                        case "Bouton rouge":
                            CmdPress(hit.transform.gameObject);
                            CmdDrop(hit.transform.gameObject, 4);
                            break;
                        case "BoutonRed":
                            CmdPressOnce(hit.transform.gameObject,3);
                            break;
                        case "BoutonBleu":
                            //hit.transform.GetComponent<ButtonPressedOnce>().press();
                            CmdPressOnce(hit.transform.gameObject,1);
                            break;
                        case "BoutonVert":
                            CmdPressOnce(hit.transform.gameObject,2);// 2 = any time you want 1 = one time
                            break;
                        case "BoutonViolet":
                            CmdPressOnce(hit.transform.gameObject,0);
                            break;
                        case "BoutonGreen":
                            CmdPress(hit.transform.gameObject);
                            CmdWaves(hit.transform.gameObject);
                            break;
                    }
                }


            }


        }

    }
}

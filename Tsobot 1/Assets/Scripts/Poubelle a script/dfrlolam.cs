using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class dfrlolam : NetworkBehaviour
{

    public GameObject lol;
    // Use this for initialization
    void Start()
    {
        print("onstartgo");
        Cmdmdr(lol);
    }
    [Command]
    void Cmdmdr(GameObject wow)
    {
        print("ezpz");

        Rpclol(wow);
        print("wtf happened");
    }
    [ClientRpc]
    void Rpclol(GameObject wow)
    {
        print("whattdefgeza");
        setact(wow);
    }

    void setact(GameObject wow)
    {
        print("lllllllllllllllllllllllllllllllllllllllllllllllll");
        wow.SetActive(true);
    }
        
	


}

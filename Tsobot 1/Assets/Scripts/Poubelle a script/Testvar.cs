using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class Testvar : NetworkBehaviour
{

    [SyncVar]
    private int num;



    public void press()
    {
        num += 1;
        print(num);
    }

}


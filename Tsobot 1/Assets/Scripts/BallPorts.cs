using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BallPorts : NetworkBehaviour {
    [SerializeField] ButtonsColor bt;
    [SerializeField] SpawnRedRoom Spawnred;

    [ClientRpc]
    private void RpcGoNext()
    {
        bt.NextLevel();
        Spawnred.NextLevel();
    }

    [Command]
    private void CmdGoNext()
    {
        RpcGoNext();
    }

    void OnCollisionEnter(Collision col)
    {

        if(col.transform.tag == "Ball")
        {
            if(isServer)
            {
                bt.NextLevel();
                Spawnred.NextLevel();
            }
            //CmdGoNext();
        }
    }

}

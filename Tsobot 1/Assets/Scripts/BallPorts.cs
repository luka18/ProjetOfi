using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class BallPorts : NetworkBehaviour {
    [SerializeField] ButtonsColor bt;

    [ClientRpc]
    private void RpcGoNext()
    {
        bt.NextLevel();
    }

    [Command]
    private void CmdGoNext()
    {
        bt.NextLevel();
    }

    void OnCollisionEnter(Collision col)
    {

        if(col.transform.tag == "Ball")
        {
            CmdGoNext();
        }
    }

}

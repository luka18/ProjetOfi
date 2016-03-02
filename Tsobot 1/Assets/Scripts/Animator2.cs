using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Animator2 : NetworkBehaviour
{
    [SerializeField] private Animator anim;
    private bool jumping = false;
    private bool carrying = false;


    //-----------------------RPC----------------------------
    [ClientRpc]
    void RpcPush(NetworkIdentity ID)
    {
        Push(ID);
    }
    [ClientRpc]
    void RpcJump(NetworkIdentity ID)
    {
        Jump(ID);
    }
    [ClientRpc]
    void RpcLand(NetworkIdentity ID)
    {
        Land(ID);
    }
    [ClientRpc]
    void RpcCarry(NetworkIdentity ID)
    {
        Carry(ID);
    }







    //-------------------------COMMAND--------------------
    [Command]
     public void CmdPush(NetworkIdentity ID)
    {
        RpcPush(ID);
    }
    [Command]
    public void CmdJump(NetworkIdentity ID)
    {
        RpcJump(ID);
    }
    [Command]
    public void CmdLand(NetworkIdentity ID)
    {
        RpcLand(ID);
    }
    [Command]
    public void CmdCarry(NetworkIdentity ID)
    {
        RpcCarry(ID);
    }




    void Land(NetworkIdentity ID)
    {
        ID.gameObject.GetComponent<Animator2>().anim.Play("Land");
    }
    void Jump(NetworkIdentity ID)
    {
        ID.gameObject.GetComponent<Animator2>().anim.Play("Jump");
    }

    void Push(NetworkIdentity ID)
    {
        ID.gameObject.GetComponent<Animator2>().anim.Play("Push");
    }
    void Carry(NetworkIdentity ID)
    {
        print("playedcarry");
        ID.gameObject.GetComponent<Animator2>().anim.Play("Carry");
    }

/*   // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (jumping && grounded)
        {
            anim.Play("Landing");
            jumping = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.Play("Jump");
            jumping = true;
        }
        
        /*if (Input.GetMouseButtonDown(1))
        {

                if (carrying)
                {
                    anim.Play("Throwit");
                    carrying = false;
                }
                else
                {
                    anim.Play("Gotit");
                    carrying = true;
                }
            
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Push");
        }
        if (Input.GetButtonDown("Crouch"))
        {
            anim.Play("Crouching");
        }
        if (Input.GetButtonUp("Crouch"))
        {
            anim.Play("Getup");
        }



        
    }
    */
}
    
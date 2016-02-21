using UnityEngine;
using System.Collections;

public class Batonnets : MonoBehaviour {

    private static int howmany;
    private int advanced = 0;
    public Material blu;
    public Material red;
    public Material grey;
    private int redplays;
    private int i = 0;
    private float wait = 0;
    private bool stop = true;

    [SerializeField] GameObject button;
    

	// Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
        if(howmany !=0)
        {
            if (stop)
            {
                for (int i = 0; i < howmany; i++)
                {
                    print("le i : " + i);
                    MeshRenderer render = transform.GetChild(advanced).GetComponent<MeshRenderer>();

                    render.material = blu;
                    advanced++;
                    print("add: "+advanced);
                    
                }
                if(advanced==10)//win
                {
                    print("win");
                    howmany = 0;
                    stop = false;
                    button.SetActive(true);


                }
                if (advanced >= 7)// lose 
                {
                    redplays = (10 - advanced);
                }

                redplays = (10-advanced) % 4;
                if (redplays == 0)
                    redplays = 1;
                stop = false;
                print("redplays: "+ redplays);
            }
            latency();
            

        }
	}
    private void latency()
    {
        if(i<redplays && wait >1)
        {
            MeshRenderer render2 = transform.GetChild(advanced).GetComponent<MeshRenderer>();
            render2.material = red;
            advanced++;
            wait = 0;
            i++;
        }
        if(i == redplays && wait>1)
        {
            howmany = 0;
            wait = 0;
            i = 0;
            stop = true;
            if(advanced ==10)
            {
                print("lost");
                for(int k = 0; k<10; k++)
                {
                    transform.GetChild(k).GetComponent<MeshRenderer>().material = grey;
                    advanced = 0;
                }
            }
        }
        wait += Time.deltaTime;

    }

     public static int gethowmany
    {
        get { return howmany; }
        set { howmany = value; }
    }

}

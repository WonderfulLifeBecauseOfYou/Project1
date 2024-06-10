using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public int links = 20;
    public IronBall ball;
    // Start is called before the first frame update
    void Start()
    {
        RopeLink();
    }


    

    public void RopeLink()
    {
        Rigidbody2D previousRB = hook;
        for(int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if(i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                ball.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
            
        }
    }
}

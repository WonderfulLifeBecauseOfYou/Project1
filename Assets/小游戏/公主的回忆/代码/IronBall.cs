using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBall : MonoBehaviour
{
    public float chainEnd = 0.15f;
    
    

    public void ConnectRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, chainEnd);
    }

}

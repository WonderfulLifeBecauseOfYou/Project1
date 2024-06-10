using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallGameMonster2 : MonoBehaviour
{
    public Transform point;
    private Vector3 v;
    private float speed = 0.2f;
    private float Time = 2f;
    public Vector3 世界坐标;
    private Vector3 P;

    private float scalex;
    private float scaley;
    private float scalez;
    private bool yep = false;
    private SkeletonAnimation _skeletonAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _skeletonAnimation = transform.GetComponent<SkeletonAnimation>();
        scalex = transform.localScale.x / 1000;
        scaley = transform.localScale.y / 1000;
        scalez = transform.localScale.z / 1000;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        世界坐标 = transform.TransformPoint(new Vector3(0, 0, 0));
        P = point.TransformPoint(new Vector3(0, 0, 0));
        if (yep)
        {
            moveaway();
        }

    }
    public void asd()
    {
        yep = true;
    }

    public void moveaway()
    {
        transform.position = Vector3.SmoothDamp(世界坐标, P, ref v, Time, speed);
        transform.localScale -= new Vector3(scalex, scaley, scalez);
        
    }
    public void startAnim()
    {
        _skeletonAnimation.AnimationState.SetAnimation(1, "Walk", true);
        Destroy(gameObject, 10f);
    }
}

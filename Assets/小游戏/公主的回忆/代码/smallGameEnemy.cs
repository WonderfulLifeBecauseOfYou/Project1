using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallGameEnemy : MonoBehaviour
{
    public GameObject open1;
    private SkeletonAnimation _skeletonAnimation;
    // Start is called before the first frame update
    void Start()
    {
        _skeletonAnimation = transform.GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            _skeletonAnimation.AnimationState.SetAnimation(1, "Dead", false);
            open1.SetActive(true);
        }
    }
    
}

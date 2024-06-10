using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ÉËº¦ÏÝÚå
/// </summary>
public class dangerT0 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        MovingT0 pc = other.GetComponent<MovingT0>();
        if(pc != null )
        {
            pc.changeHealth(-1);
        }
    }
}

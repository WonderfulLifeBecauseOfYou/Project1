using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeCutter : MonoBehaviour
{
    public Camera camear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(camear.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null)
            {
                Destroy(hit.collider.gameObject);
                int count = hit.transform.parent.childCount;
                for(int i = 1; i<count; i++)
                {
                    Destroy(hit.transform.parent.GetChild(i).gameObject, 2f);
                }
            }
        }
    }
}

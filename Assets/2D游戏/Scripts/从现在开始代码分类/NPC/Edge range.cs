using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Edgerange : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        npcmoving np = collision.GetComponent<npcmoving>();
        if(np != null)
        {
            np.Touch();
        }
    }
}

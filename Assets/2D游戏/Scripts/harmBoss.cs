using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harmBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy_behaviour ec = other.GetComponent<Enemy_behaviour>();
        if (ec != null)
        {
            print(1);
            ec.BosschangeHealth(-20);
        }
    }
}

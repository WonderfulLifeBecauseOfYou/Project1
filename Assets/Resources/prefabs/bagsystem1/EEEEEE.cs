using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEEEEE : MonoBehaviour
{
    public GameObject R;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Slot s = R.GetComponent<Slot>();
            s.UseDrug();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plot : MonoBehaviour
{
    public GameObject[] plotbox;
    public int a = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Next();
        }
    }

    public void Next()
    {
        if (a > transform.childCount - 1) return;
        plotbox[a].SetActive(true);
        a ++;

    }
}

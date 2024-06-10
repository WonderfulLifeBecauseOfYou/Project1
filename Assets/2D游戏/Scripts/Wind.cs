using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public GameObject kaiguan;
    public bool open = true;
    float time = 0.5f;
    float timer = 0f;
    private void Start()
    {
        kaiguan.SetActive(true);
    
    }

    private void Update()
    {

        if(timer <= time)
        {
            timer += Time.deltaTime;
            if(timer >= time)
            {
                open = !open;
                kaiguan.SetActive(open);
                timer = 0f;
            }
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGO : MonoBehaviour
{
    public GameObject a1;

    // Start is called before the first frame update
    void Start()
    {
        open1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void open1()
    {
        a1.SetActive(true);
        Invoke("Destroya1", 5f);
    }
    private void Destroya1()
    {
        Destroy(a1);
    }

}

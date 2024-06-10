using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public static Role Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void SwitchGender(int gender)
    {
        transform.GetChild(gender).gameObject.SetActive(true);
        transform.GetChild(1-gender).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

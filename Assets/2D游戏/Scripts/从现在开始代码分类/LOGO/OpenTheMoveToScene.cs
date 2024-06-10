using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheMoveToScene : MonoBehaviour
{
    private bool istrue;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && istrue == true)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            istrue = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            istrue = false;

        }
    }

    public void GotoHomeSys()
    {
        istrue = true;
    }
}


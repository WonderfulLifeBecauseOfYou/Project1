using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private bool istrue;
    public GameObject UI;
    public GameObject B;
    public GameObject C1;
    public GameObject C2;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && istrue == true)
        {
            B.SetActive(true);
            C1.SetActive(true);
            C2.SetActive(false);
            UI.SetActive(false);
        }
    }


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
            B.SetActive(false);
            C1.SetActive(false);
            C2.SetActive(true);
            UI.SetActive(true);
        }
    }
}

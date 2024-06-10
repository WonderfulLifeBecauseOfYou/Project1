using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class makeMagic : MonoBehaviour
{
    public GameObject Magic;
    private Vector3 mousePos;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy == true)
        {
            mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Instantiate(Magic);
            Magic.transform.position = mousePos;
            Destroy(Magic, 2f);
        }

    }
}

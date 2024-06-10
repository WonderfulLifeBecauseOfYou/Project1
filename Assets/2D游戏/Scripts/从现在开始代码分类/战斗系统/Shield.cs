using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Shield : MonoBehaviour
{
    public GameObject player;
    private bool cooling = true;

    [Header("∂‹≈∆√‚…À¬ ")]
    public float ax;

    [Header("∂‹≈∆µ÷µ≤¥Œ ˝")]
    public int count;

    [Header("∂‹≈∆Àªµ∫Û¿‰»¥ ±º‰")]
    public float time;

    private Camera cam;
    private Vector3 mousePos;

    private float timer = 0f;
    private bool isBroken = false;

    public int Count = 0;
    private GameObject Dun;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        Dun = gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 rotation = gameObject.transform.GetChild(0).eulerAngles;
        if (mousePos.x >= transform.position.x)
        {
            rotation.y = 0f;

        }
        if (mousePos.x < transform.position.x)
        {
            rotation.y = 180f;

        }
        gameObject.transform.GetChild(0).eulerAngles = rotation;
        if (Input.GetMouseButton(1))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }


        if(Count >= count)
        {
            isBroken = true;
            Count = 0;
            timer += Time.deltaTime;
            if(timer >= time)
            {
                timer = 0f;
                isBroken = false;
            }
        }
    }



    public float Defense()
    {
        if (isBroken == false)
        {
            if (Dun.activeInHierarchy == true)
            {
                return ax;
            }
            else
            {
                return 0;

            }
        }
        else
        {
            return 0;
        }
        
    }

    public void changeCounts()
    {
        if(isBroken == false)
        {
            Count++;
        }
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class going2D : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject start;
    public bool open;
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        appearance(open);
    }

    public void appearance(bool open)
    {
        if(open == true)
        {
            start.SetActive(true);
        }
    }
    public void goto2d()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

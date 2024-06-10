using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BOSSdoor : MonoBehaviour
{
    public Transform task1;
    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MovingT0 pc = other.GetComponent<MovingT0>();
        if (pc != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
            Player.position = task1.position;
        }
    }
}

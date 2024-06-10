using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playgame1 : MonoBehaviour
{
    private GameObject player;
    private GameObject UI;
    public GameObject gardenEventsystem;
    public GameObject shotandrun;
    public GameObject smallgames;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    

    public void openRunandShot()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("UI");
        gardenEventsystem.SetActive(false);
        smallgames.SetActive(true);
        shotandrun.SetActive(true);
        player.SetActive(false);
        UI.SetActive(false);
        
    }
}

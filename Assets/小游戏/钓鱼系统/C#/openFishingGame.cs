using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openFishingGame : MonoBehaviour
{
    private GameObject player;
    private GameObject UI;
    public GameObject gardenEventSystem;
    public GameObject FishGame;
    public GameObject smallgames;


    // Update is called once per frame
    void Update()
    {
        
    }

    //¿ªµö!
    public void openFishGame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("UI");
        gardenEventSystem.SetActive(false);
        smallgames.SetActive(true);
        FishGame.SetActive(true);
        player.SetActive(false);
        UI.SetActive(false);

    }
}


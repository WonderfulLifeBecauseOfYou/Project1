using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutMemory : MonoBehaviour
{
    public GameObject garden;
    public GameObject FishGame;
    public GameObject smallGames;
    private GameObject player;
    private GameObject UI;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("UI");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exitfishing();
        }
    }

    public void Exitfishing()
    {
        FishGame.SetActive(false);
        player.SetActive(true);
        garden.SetActive(true);
        smallGames.SetActive(false);
        Invoke("openUI", 0.1f);
    }
    private void openUI()
    {
        UI.SetActive(true);
    }
}

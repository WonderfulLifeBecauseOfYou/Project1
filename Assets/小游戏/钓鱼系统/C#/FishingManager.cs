using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public GameObject garden;
    public GameObject FishGame;
    public GameObject smallGames;
    private GameObject player;
    private GameObject UI;
    private bool open = false;
    public GameObject fishstore;
    public GameObject introductionBox;
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            openfishstore();
        }
    }

    public void openfishstore()
    {
        if(open == false)
        {
            fishstore.SetActive(true);
            open = true;
        }
        else
        {
            introductionBox.SetActive(false);
            fishstore.SetActive(false);
            open = false;
        }
        
    }
    public void Exitfishstore()
    {
        introductionBox.SetActive(false);
        fishstore.SetActive(false);
        open = false;
    }




    //ÍË³öµöÓã
    public void Exitfishing()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("NPC");
        foreach(GameObject s in enemies)
        {
            Destroy(s);
        }
        introductionBox.SetActive(false);
        fishstore.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect3Buff : MonoBehaviour
{
    [Header("Buff持续时间")]
    public float time1 = 1f;
    public float time2 = 1f;
    public float time3 = 1f;
    public float time4 = 1f;
    public float time5 = 1f;

    public GameObject buff1;
    public GameObject buff2;
    public GameObject buff3;
    public GameObject buff4;
    public GameObject buff5;


    private GameObject player;
    private MovingT0 playercontroller;

    private GameObject b1;
    private GameObject b2;
    private GameObject b3;
    private GameObject b4;
    private GameObject b5;


    private float a;
    private float b;
    private float bb;
    private float c;
    private float cc;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
        playercontroller = player.gameObject.GetComponent<MovingT0>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Addbuff1()
    {
        b1 = Instantiate(buff1);
        playercontroller.currentHealth = Mathf.Clamp(playercontroller.currentHealth + playercontroller.maxHealth * 0.3f, 0, playercontroller.maxHealth);
        b1.transform.SetParent(gameObject.transform);
        b1.transform.position = gameObject.transform.position;
        Destroy(b1, time1);
    }
    public void Addbuff2()
    {
        b2 = Instantiate(buff2);
        a = playercontroller.speed * 0.2f;
        float Startspeed = playercontroller.speed;
        playercontroller.speed = Mathf.Clamp(Startspeed + a, Startspeed, Startspeed * 1.5f);
        b2.transform.SetParent(gameObject.transform);
        b2.transform.position = gameObject.transform.position;
        Invoke("D2", time2);
    }
    public void Addbuff3()
    {
        b3 = Instantiate(buff3);
        b = playercontroller.atk1 * 0.15f;
        bb = playercontroller.atk2 * 0.15f;
        float Startatk1 = playercontroller.atk1;
        float Startatk2 = playercontroller.atk2;
        playercontroller.atk1 = Mathf.Clamp(playercontroller.atk1 + b, Startatk1, (playercontroller.level * 10f + 40f) * 1.4f);
        playercontroller.atk2 = Mathf.Clamp(playercontroller.atk2 + bb, Startatk2, (playercontroller.level * 10f + 40f) * 1.4f);
        b3.transform.SetParent(gameObject.transform);
        b3.transform.position = gameObject.transform.position;
        Invoke("D3", time3);
    }
    public void Addbuff4()
    {
        b4 = Instantiate(buff4);
        c = playercontroller.def1 * 0.15f;
        cc = playercontroller.def2 * 0.15f;
        float Startadef1 = playercontroller.def1;
        float Startadef2 = playercontroller.def2;
        playercontroller.def1 = Mathf.Clamp(playercontroller.def1 + c, Startadef1, ((((11-playercontroller.level) + 10) * playercontroller.level)/2f + 10f) * 1.4f);
        playercontroller.def2 = Mathf.Clamp(playercontroller.def2 + cc, Startadef2, ((((11 - playercontroller.level) + 10) * playercontroller.level) / 2f + 10f) * 1.4f);
        b4.transform.SetParent(gameObject.transform);
        b4.transform.position = gameObject.transform.position;
        Invoke("D4", time4);
    }
    public void Addbuff5()
    {
        b5 = Instantiate(buff5);
        playercontroller.state = "正常";
        b5.transform.SetParent(gameObject.transform);
        b5.transform.position = gameObject.transform.position;
        Destroy(b5, time5);
    }

    private void D2()
    {
        Destroy(b2);
        playercontroller.speed -= a;
        player.transform.GetChild(7).GetChild(1).gameObject.SetActive(false);
    }
    private void D3()
    {
        Destroy(b3);
        playercontroller.atk1 -= b;
        playercontroller.atk2 -= bb;
        player.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
    }
    private void D4()
    {
        Destroy(b4);
        playercontroller.def1 -= c;
        playercontroller.def2 -= cc;
        player.transform.GetChild(7).GetChild(3).gameObject.SetActive(false);
    }
}

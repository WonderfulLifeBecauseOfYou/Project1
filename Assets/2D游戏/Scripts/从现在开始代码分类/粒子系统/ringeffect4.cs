using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringeffect4 : MonoBehaviour
{
    public int a=0;

    private GameObject player;
    private MovingT0 playercontroller;
    //≥ı º÷µ
    private float startMaxH;
    private float startCurH;
    private float startMagicV;
    private float startEnduranceV;
    private float startAtk1;
    private float startAtk2;
    private float startAttackT;
    private float startBulletT;
    private float startSkillT;
    private float startDef1;
    private float startDef2;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playercontroller = player.gameObject.GetComponent<MovingT0>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (a == 1)
        {
            startAtk1 = playercontroller.atk1;
            startAtk2 = playercontroller.atk2;
            startAttackT = playercontroller.attackTime;
            playercontroller.atk1 = Mathf.Clamp(playercontroller.atk1 + startAtk1 * 0.15f, startAtk1, (playercontroller.level * 10f + 40f) * 1.4f);
            playercontroller.atk2 = Mathf.Clamp(playercontroller.atk2 + startAtk2 * 0.15f, startAtk2, (playercontroller.level * 10f + 40f) * 1.4f);
            playercontroller.attackTime = Mathf.Clamp(playercontroller.attackTime + 0.15f, startAttackT, 0.35f);
        }
        if (a ==2)
        {
            startDef1 = playercontroller.def1;
            startDef2 = playercontroller.def2;
            startBulletT = playercontroller.bulletTime;
            startSkillT = playercontroller.skillTime;
            playercontroller.def1 = Mathf.Clamp(playercontroller.def1 + startDef1 * 0.15f, startDef1, ((((11 - playercontroller.level) + 10) * playercontroller.level) / 2f + 10f) * 1.4f);
            playercontroller.def2 = Mathf.Clamp(playercontroller.def2 + startDef2 * 0.15f, startDef2, ((((11 - playercontroller.level) + 10) * playercontroller.level) / 2f + 10f) * 1.4f);
            playercontroller.bulletTime = Mathf.Clamp(playercontroller.bulletTime + 0.15f, startBulletT, 0.35f);
            playercontroller.skillTime = Mathf.Clamp(playercontroller.skillTime + 0.15f, startSkillT, 0.35f);
        }
        if (a == 3)
        {
            startMaxH = playercontroller.maxHealth;
            startCurH = playercontroller.currentHealth;
            startMagicV = playercontroller.magicValues;
            startEnduranceV = playercontroller.EnduranceValues;
            playercontroller.maxHealth += startMaxH * 0.15f;
            playercontroller.currentHealth = Mathf.Clamp(startCurH + startMaxH * 0.15f, 0, playercontroller.maxHealth);
            playercontroller.magicValues += startMagicV * 0.25f;
            playercontroller.EnduranceValues += startEnduranceV * 0.25f;
        }

    }
    private void OnDisable()
    {
        if (a == 1)
        {
            playercontroller.atk1 = startAtk1;
            playercontroller.atk2 = startAtk2;
            playercontroller.attackTime = startAttackT;
        }
        if (a == 2)
        {
            playercontroller.def1 = startDef1;
            playercontroller.def2 = startDef2;
            playercontroller.skillTime = startSkillT;
            playercontroller.bulletTime = startBulletT;
        }
        if (a ==3)
        {
            playercontroller.maxHealth = startMaxH;
            playercontroller.currentHealth = startCurH;
            playercontroller.magicValues = startMagicV;
            playercontroller.EnduranceValues = startEnduranceV;
        }
    }
}

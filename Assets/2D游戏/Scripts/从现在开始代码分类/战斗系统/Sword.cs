using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class Sword : MonoBehaviour
{
    public GameObject Player;

    private bool cooling = true;
    [Header("攻击持续时间")]
    public float time = 1f;
    [Header("攻击间隔时间")]
    public float AttackTime = 5f;
    [Header("攻击力")]
    public float Attackharm;

    private float angle;
    private Camera cam;
    private Vector2 Direction;
    private Vector3 mousePos;

    private float attacktime;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        MovingT0 pc = Player.GetComponent<MovingT0>();
        attacktime = Mathf.Clamp(pc.attackTime, 0, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Direction = (mousePos - transform.position).normalized;
        angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
        gameObject.transform.GetChild(0).gameObject.transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetKeyDown(KeyCode.Mouse0)&&cooling == true)
        {
            cooling = false;
            Attack();
        }
    }

    private void attackstop()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        Invoke("changeCooling", AttackTime * (1 - attacktime * 0.01f));
    }

    private void Attack()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("attackstop", time);
    }

    private void changeCooling()
    {
        cooling = true;
    }
}

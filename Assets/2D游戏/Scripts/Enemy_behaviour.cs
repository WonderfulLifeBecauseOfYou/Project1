using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy_behaviour : MonoBehaviour
{

    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public int maxHealth;//生命值上限
    public int currentHealth;//当前生命值
    public float dietime;
    public float timer;
    public GameObject door;
    public GameObject winobject;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private bool isdie;
    private bool x;
    #endregion
    Rigidbody2D rbody;


    private GameObject player;
    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (isdie) return;
        if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) > rayCastLength)
        {
            inRange = false;

        }
        else
        {
            inRange = true;
        }
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength);
            RaycastDebugger();
            if (hit.collider != null)
            {
                EnemyLogic();
            }

        }
        else
        {
            anim.SetBool("canWalk", false);
            StopAttack();
        }

    }


    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Flip();
        if(currentHealth == maxHealth / 2 && x==false)
        {
            Skill();
            moveSpeed = 1.7f;
            intTimer = 0;
            x = true;
        }

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }

    void Move()
    {
        anim.SetBool("canWalk", true);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("攻击"))
        {
            Vector2 targetPosition = new Vector2(player.transform.position.x, player.transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > player.transform.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }

    public void BosschangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //UImanager.instance.UpdatahealthBarofBoss(currentHealth, maxHealth);
        if (currentHealth <= 0)
        {
            isdie = true;
            anim.SetTrigger("Die");
            rbody.simulated = false;
            SpriteRenderer[] srs = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer sr in srs)
            {
                sr.sortingLayerName = "Default";
            }
            Invoke("killed",dietime);
            door.SetActive(true);
            winobject.SetActive(true);

        }
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    void killed()
    {
       // Destroy(gameObject);
    }

    void Skill()
    {
        anim.SetTrigger("skill");
    }
    public void BOSSover()
    {
        InteractionT0 death = GameObject.FindGameObjectWithTag("NPC").transform.GetComponent<InteractionT0>();
        death.IfBOOSDied();
    }
}

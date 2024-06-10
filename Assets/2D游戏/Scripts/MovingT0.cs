using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///玩家角色信息
/// </summary>
public class MovingT0 : MonoBehaviour
{
    [Header("玩家属性")]
    [Tooltip("持有金币")]
    public float Coins = 0;//等级
    [Tooltip("等级")]
    public int level = 1;//等级
    [Tooltip("状态")]
    public string state = "正常";//状态
    [Tooltip("最大生命值")]
    public float maxHealth = 5;//生命值上限
    [Tooltip("当前生命值")]
    public float currentHealth = 5;//当前生命值
    [Tooltip("移动速度")]
    public float speed = 5f;//移速
    [Tooltip("子弹冷却时间")]
    public float bulletTime;//子弹冷却时间
    [Tooltip("技能冷却时间")]
    public float skillTime;//技能冷却时间
    [Tooltip("攻击冷却时间")]
    public float attackTime;//近战攻击冷却时间
    [Tooltip("物理攻击力")]
    public float atk1;//物理攻击力
    [Tooltip("魔法攻击力")]
    public float atk2;//魔法攻击力
    [Tooltip("物理防御力")]
    public float def1;//物理防御力
    [Tooltip("魔法防御力")]
    public float def2;//魔法防御力
    [Tooltip("魔力值")]
    public float magicValues;//魔力值
    [Tooltip("耐力值")]
    public float EnduranceValues;//耐力值
    [Tooltip("智力")]
    public float smart;//智力
    [Tooltip("信仰")]
    public float belief;//信仰

    [Header("其他")]
    public string currentSceneName;
    public Transform playerposition;
    Vector2 movement;
    private float invincibleTime = 1.5f;//受到伤害无敌时间为1。
    private float invincibleTimer;//无敌计时器
    private bool ifinvincible;//是否处于无敌状态
    private Vector2 lookdirection = new Vector2(0, -1);//默认朝下
    public GameObject bulletobject;//子弹
    public static MovingT0 Instance;
    public GameObject Bag;
    public GameObject Died;
    bool isopenbag;
    private Renderer myRender;//1
    public int blinks;
    private float times =0.1f;//受伤闪烁时间
    private bool openbuttle = true;//是否发射子弹
    private float buttleTimer;


    Animator animator;
    // Start is called before the first frame update
    Rigidbody2D rbody;//刚体组件
    void Start()
    {
        Instance = this;
        currentSceneName = SceneManager.GetActiveScene().name;
        playerposition = gameObject.transform;
        invincibleTimer = 0;
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myRender = GetComponent<Renderer>();
        
        buttleTimer = bulletTime;
    }

    // Update is called once per frame
    void Update()
    {
        
        openBag();//打开背包

        //============无敌===============
        if (ifinvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0 )
            {
                ifinvincible = false;
            }
        }

        //===========按下E键进行交互=============
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(rbody.position, lookdirection, 2f, LayerMask.GetMask("NPC"));
            if(hit.collider != null)
            {
                InteractionT0 npc = hit.collider.GetComponent<InteractionT0>();
                if (npc != null)
                {
                    npc.ShowDialog();//显示对话框
                }
            }
        }

        //===========按下左shift键发射子弹============
        if(Input.GetKeyDown(KeyCode.LeftShift)&& openbuttle == true)
        {
            GameObject bullet = Instantiate(bulletobject, rbody.position + Vector2.down * 0.5f, Quaternion.identity);
            BulletController bc = bullet.GetComponent<BulletController>();
            if (bc != null)
            {
                openbuttle = false;
                bc.Move(lookdirection, 500);
            }
        }
        if(openbuttle == false)
        {
            buttleTimer -= Time.deltaTime;
            if (buttleTimer < 0)
            {
                openbuttle = true;
                buttleTimer = bulletTime;
            }
        }



        if (currentHealth == 0)
        {
            openDied();
            Destroy(gameObject);

        }



        UImanager.instance.UpdatahealthBar((int)currentHealth, (int)maxHealth);
    }

    private void FixedUpdate()
    {
        //============移动==============
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Vector2 moveVector = new Vector2(movement.x, movement.y);
        moveVector.Normalize();

        if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookdirection = moveVector;
        }
        animator.SetFloat("Look X", lookdirection.x);
        animator.SetFloat("Look Y", lookdirection.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        rbody.MovePosition(rbody.position + moveVector * speed * Time.fixedDeltaTime);
    }

    //受到伤害
    public void changeHealth(float amount)
    {
        if (amount < 0)
        {
            if(ifinvincible)
            {
                return;
            }
            ifinvincible = true;
            invincibleTimer = invincibleTime;
            //1
            BlinkPlayer(blinks, times);
        }
        //把生命值约束在一定区间
        currentHealth = Mathf.Clamp(currentHealth+amount, 0, maxHealth);
        Shield sh = gameObject.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Shield>();
        sh.changeCounts();
    }

    void BlinkPlayer(int numBlinks, float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    IEnumerator DoBlinks(int numBlinks, float seconds)
    {
        for(int i = 0; i < numBlinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }

    //=============背包系统===============
    private void openBag()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isopenbag = !isopenbag;
            Bag.SetActive(isopenbag);
        }
    }

    private void openDied()
    {
        Died.SetActive(true);
    }


    //碰到敌人扣血(圆形触发器)
    private void OnTriggerStay2D(Collider2D collision)
    {
        Shield sh = gameObject.transform.GetChild(6).GetChild(0).gameObject.GetComponent<Shield>();
        if (collision.tag == "EnemyAttack")
        {
            HarmSystem harmsystem = collision.gameObject.transform.parent.gameObject.GetComponent<HarmSystem>();
            float a = harmsystem.atk1 * (1 - (def1 / 100) * 0.7f) + harmsystem.atk2 * (1 - (def2 / 100) * 0.7f);
            a = a - a * sh.Defense()* 0.01f;
            changeHealth(-a);
        }
        if (collision.tag == "Enemy")
        {
            HarmSystem harmsystem = collision.gameObject.GetComponent<HarmSystem>();
            float a = harmsystem.atk1 * (1 - (def1 / 100) * 0.7f) + harmsystem.atk2 * (1 - (def2 / 100) * 0.7f);
            a = a - a * sh.Defense() * 0.01f;
            changeHealth(-a);
        }
    }
}

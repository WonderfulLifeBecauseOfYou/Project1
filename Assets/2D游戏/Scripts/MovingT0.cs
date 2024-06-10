using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///��ҽ�ɫ��Ϣ
/// </summary>
public class MovingT0 : MonoBehaviour
{
    [Header("�������")]
    [Tooltip("���н��")]
    public float Coins = 0;//�ȼ�
    [Tooltip("�ȼ�")]
    public int level = 1;//�ȼ�
    [Tooltip("״̬")]
    public string state = "����";//״̬
    [Tooltip("�������ֵ")]
    public float maxHealth = 5;//����ֵ����
    [Tooltip("��ǰ����ֵ")]
    public float currentHealth = 5;//��ǰ����ֵ
    [Tooltip("�ƶ��ٶ�")]
    public float speed = 5f;//����
    [Tooltip("�ӵ���ȴʱ��")]
    public float bulletTime;//�ӵ���ȴʱ��
    [Tooltip("������ȴʱ��")]
    public float skillTime;//������ȴʱ��
    [Tooltip("������ȴʱ��")]
    public float attackTime;//��ս������ȴʱ��
    [Tooltip("��������")]
    public float atk1;//��������
    [Tooltip("ħ��������")]
    public float atk2;//ħ��������
    [Tooltip("���������")]
    public float def1;//���������
    [Tooltip("ħ��������")]
    public float def2;//ħ��������
    [Tooltip("ħ��ֵ")]
    public float magicValues;//ħ��ֵ
    [Tooltip("����ֵ")]
    public float EnduranceValues;//����ֵ
    [Tooltip("����")]
    public float smart;//����
    [Tooltip("����")]
    public float belief;//����

    [Header("����")]
    public string currentSceneName;
    public Transform playerposition;
    Vector2 movement;
    private float invincibleTime = 1.5f;//�ܵ��˺��޵�ʱ��Ϊ1��
    private float invincibleTimer;//�޵м�ʱ��
    private bool ifinvincible;//�Ƿ����޵�״̬
    private Vector2 lookdirection = new Vector2(0, -1);//Ĭ�ϳ���
    public GameObject bulletobject;//�ӵ�
    public static MovingT0 Instance;
    public GameObject Bag;
    public GameObject Died;
    bool isopenbag;
    private Renderer myRender;//1
    public int blinks;
    private float times =0.1f;//������˸ʱ��
    private bool openbuttle = true;//�Ƿ����ӵ�
    private float buttleTimer;


    Animator animator;
    // Start is called before the first frame update
    Rigidbody2D rbody;//�������
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
        
        openBag();//�򿪱���

        //============�޵�===============
        if (ifinvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0 )
            {
                ifinvincible = false;
            }
        }

        //===========����E�����н���=============
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hit = Physics2D.Raycast(rbody.position, lookdirection, 2f, LayerMask.GetMask("NPC"));
            if(hit.collider != null)
            {
                InteractionT0 npc = hit.collider.GetComponent<InteractionT0>();
                if (npc != null)
                {
                    npc.ShowDialog();//��ʾ�Ի���
                }
            }
        }

        //===========������shift�������ӵ�============
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
        //============�ƶ�==============
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

    //�ܵ��˺�
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
        //������ֵԼ����һ������
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

    //=============����ϵͳ===============
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


    //�������˿�Ѫ(Բ�δ�����)
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

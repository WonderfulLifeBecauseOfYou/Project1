using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem.iOS;

public class HarmSystem : MonoBehaviour
{
    [Header("敌人属性")]
    [Tooltip("最大生命值")]
    public float maxHealth;//生命值上限
    [Tooltip("当前生命值")]
    public float currentHealth;//当前生命值
    [Tooltip("物理攻击力")]
    public float atk1;//物理攻击力
    [Tooltip("魔法攻击力")]
    public float atk2;//魔法攻击力
    [Tooltip("物理防御力")]
    public float def1;//物理防御力
    [Tooltip("魔法防御力")]
    public float def2;//魔法防御力
    private GameObject 攻击触发器;
    private Rigidbody2D rb;
    private SkeletonAnimation _skeletonAnimation;
    public bool isdie = false;
    // Start is called before the first frame update
    void Start()
    {
        _skeletonAnimation = transform.GetComponent<SkeletonAnimation>();
        //currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        攻击触发器 = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_skeletonAnimation.state.ToString() == "Attack")
        {
            //TurnoffAttackmode();
            攻击触发器.SetActive(true);
        }
        else
        {
            攻击触发器.SetActive(false);
        }
    }


    public void GetFight(float a)
    {
        currentHealth = Mathf.Clamp(currentHealth - a, 0, maxHealth);
        if (currentHealth <= 0)
        {
            isdie = true;
            rb.simulated = false;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            _skeletonAnimation.AnimationState.SetAnimation(1, "Dead", false);
        }
    }


    //================触发攻击====================
    private void OnParticleCollision(GameObject other)
    {
        if (isdie) return;
        if (other.tag == "Attack")
        {
            GameObject attack = other.transform.parent.parent.parent.gameObject;
            HarmTest harmtest = attack.GetComponent<HarmTest>();
            //print(harmtest.HARM);
            GetFight(harmtest.HARM1 * (1 - (def1/100)*0.7f) + harmtest.HARM2 * (1 - (def2 / 100) * 0.7f));
        }
        

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isdie) return;
        if (other.tag == "Attack")
        {
            GameObject attack = other.transform.parent.parent.gameObject;
            HarmTest harmtest = attack.GetComponent<HarmTest>();
            //print(harmtest.HARM1);
            GetFight(harmtest.HARM1 * (1 - (def1 / 100) * 0.7f) + harmtest.HARM2 * (1 - (def2 / 100) * 0.7f));
        }
        if (other.tag == "Skills")
        {
            GameObject skill = other.transform.parent.parent.gameObject;
            effect1 harmtest = skill.GetComponent<effect1>();
            //print(harmtest.Attackharm);
            GetFight(harmtest.Attackharm * (1 - (def1 / 100) * 0.7f) + harmtest.Attackharm * (1 - (def2 / 100) * 0.7f));

        }
        if (other.tag == "Magics")
        {
            GameObject magic = other.transform.parent.gameObject;
            HarmTest harmtest = magic.GetComponent<HarmTest>();
            if (magic.name == "风暴魔法")
            {
                GetFight(harmtest.HARM1 * (1 - (def1 / 100) * 0.7f) + harmtest.HARM2 * (1 - (def2 / 100) * 0.7f));
            }
            else
            {
                GetFight(harmtest.HARM1 * (1 - (def1 / 100) * 0.7f) + harmtest.HARM2 * (1 - (def2 / 100) * 0.7f));
            }
        }
    }
    //================触发攻击====================

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isdie) return;
        if (collision.transform.tag == "buttle")
        {
            Destroy(collision.gameObject);
            GetFight(5);
        }
    }

    /*
    private void OpenAttackmode()
    {
        攻击触发器.SetActive(true);
        Invoke("TurnoffAttackmode", 0.1f);
    }
    private void TurnoffAttackmode()
    {
        攻击触发器.SetActive(false);
        Invoke("OpenAttackmode", 0.5f);
    }
    */
}

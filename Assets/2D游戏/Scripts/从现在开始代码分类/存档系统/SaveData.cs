using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    
}




//玩家
public class PlayerData
{
    //速度
    public float speed;
    //当前生命值
    public float Health;
    //玩家位置
    public float playerX;
    public float playerY;
    public float playerZ;
    //当前场景名
    public string dataName;
    public string saveTime;
    public string addr;

    //其他属性
    public int level;//等级
    public string state;//状态
    public float Coins;
    public float maxHealth;//生命值上限
    public float bulletTime;//子弹冷却时间
    public float skillTime;//技能冷却时间
    public float attackTime;//近战攻击冷却时间
    public float atk1;//物理攻击力
    public float atk2;//魔法攻击力
    public float def1;//物理防御力
    public float def2;//魔法防御力
    public float magicValues;//魔力值
    public float EnduranceValues;//耐力值
    public float smart;//智力
    public float belief;//信仰
}

//时间
public class TimeSystem
{
    
}


//npc




//其他
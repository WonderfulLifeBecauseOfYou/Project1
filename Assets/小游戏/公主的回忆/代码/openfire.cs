using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openfire : MonoBehaviour
{
    public GameObject open2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer == LayerMask.NameToLayer("sign"))
        {
            Destroy(collision.gameObject);
            
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            SmallGameMonster2 playerController = GameObject.FindGameObjectWithTag("NPC").GetComponent<SmallGameMonster2>();
            playerController.startAnim();
            playerController.asd();

            SmallGameMonster2 playerController1 = GameObject.FindGameObjectWithTag("Finish").GetComponent<SmallGameMonster2>();
            playerController1.startAnim();
            playerController1.asd();

            SmallGameMonster2 playerController2 = GameObject.FindGameObjectWithTag("Respawn").GetComponent<SmallGameMonster2>();
            playerController2.startAnim();
            playerController2.asd();

            open2.SetActive(true);
        }
    }

}

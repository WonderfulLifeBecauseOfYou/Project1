using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class rotation : MonoBehaviour
{
    public GameObject fishhook;
    public GameObject judage1;
    public RectTransform pointerStart;
    public float speed;
    public float minAngle;
    public float maxAngle;
    private bool R = true;//对就转，错就停
    public GameObject s1;
    public GameObject f1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Time.timeScale = 0.0f;
        R = true;
    }
    private void OnDisable()
    {
        Time.timeScale = 1.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (R)
            {
                float angle = GetComponent<RectTransform>().eulerAngles.z;
                if (angle >= minAngle && angle <= maxAngle)//钓到了
                {
                    fishohhkMoving playerController = fishhook.GetComponent<fishohhkMoving>();
                    playerController.PutMonsters();
                    GameObject a = Instantiate(s1, GameObject.FindGameObjectWithTag("Finish").transform.GetChild(3).GetChild(2).position, Quaternion.identity);
                    a.transform.SetParent(GameObject.FindGameObjectWithTag("Finish").transform);
                }
                else//没钓到
                {
                    fishohhkMoving playerController = fishhook.GetComponent<fishohhkMoving>();
                    playerController.NotPutMonsters();
                    GameObject a = Instantiate(f1, GameObject.FindGameObjectWithTag("Finish").transform.GetChild(3).GetChild(2).position, Quaternion.identity);
                    a.transform.SetParent(GameObject.FindGameObjectWithTag("Finish").transform);
                }
            }
            R = false;
            judage1.SetActive(false);
        }
        if (R)
        {
            Rotation();
        }
    }


    public void Rotation()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.RotateAround(pointerStart.position, Vector3.forward, speed);

    }
}

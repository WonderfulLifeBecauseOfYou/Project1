using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanZoom : MonoBehaviour
{
    //WSAD相机移动速度
    public float moveSpeed = 1.0f;
    //相机当前移动方向
    private Vector3 moveDirection;

    //QE相机的目标高度
    //private float upDistance;
    //public float upSpeed = 0.2f;

    //鼠标右键控制旋转
    //private float rotateX, rotateY;
    //public float sensitivity = 0.5f;
    //控制鼠标在Y方向上的限值
    //public float minAngle = -90f;
    //public float maxAngle = 90f;
    //记录之前的欧拉角，避免跳屏
    //private Vector3 currentRotation, lastPosition;



    //camera scroll limits
    public float minX = -10f; // 左边界
    public float maxX = 10f; // 右边界
    public float minY = -10f; // 下边界
    public float maxY = 10f; // 上边界

    //鼠标滚轮控制缩放
    public float zoomSpeed = 1f; // 缩放速度
    public float minZoom = 1f; // 最小缩放值
    public float maxZoom = 5f; // 最大缩放值

    private CinemachineVirtualCamera cam;
    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        //currentRotation = transform.eulerAngles;
    }
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // 计算移动量
        Vector3 move = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // 计算新的位置
        Vector3 newPosition = transform.position + move;

        // 限制移动范围
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // 更新相机位置
        transform.position = newPosition;


        /*
        //使用QE控制相机的上下,使用unDown参数进行单位变化
        {
            if (Input.GetKey(KeyCode.Q))
            {
                upDistance -= upSpeed * Time.deltaTime;
                transform.Translate(transform.up * upDistance, Space.World);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                upDistance = 0;
            }
            if (Input.GetKey(KeyCode.E))
            {
                upDistance += upSpeed * Time.deltaTime;
                transform.Translate(transform.up * upDistance, Space.World);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                upDistance = 0;
            }
        }

        //使用鼠标右键来控制相机旋转
        //Mouse X，向右移动返回正值，Mouse Y，向上移动鼠标为正值
        {
            if (Input.GetMouseButtonDown(1))
            {
                // 记录当前的欧拉角
                //currentRotation = transform.eulerAngles;
                //记录鼠标位置
                lastPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(1))
            {
                //设置偏移量
                Vector3 offset = Input.mousePosition - lastPosition;
                rotateX += offset.x * sensitivity;
                rotateY -= offset.y * sensitivity;

                //给Y方向的旋转加上限值函数
                rotateY = Mathf.Clamp(rotateY, minAngle, maxAngle);
                //改变当前的欧拉角
                transform.eulerAngles = new Vector3(rotateY, rotateX, 0f);

                // 将保存的欧拉角重新赋值回去
                transform.eulerAngles += currentRotation;
                lastPosition = Input.mousePosition;
            }
        }



        //使用滚轮来控制物体的缩放3D
        {
            //获取滚轮的滚动幅度和方向
            zoomDistance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            //使用限值函数来限定缩放的范围
            zoomDistance = Mathf.Clamp(zoomDistance, -10f, 10f);
            //最后定位
            transform.position = transform.position + transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }

        */
        //缩放
        float zoom = cam.m_Lens.OrthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        cam.m_Lens.OrthographicSize = Mathf.Clamp(zoom, minZoom, maxZoom);
    }
}

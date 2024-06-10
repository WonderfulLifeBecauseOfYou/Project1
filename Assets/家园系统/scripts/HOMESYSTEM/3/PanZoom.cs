using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanZoom : MonoBehaviour
{
    //WSAD����ƶ��ٶ�
    public float moveSpeed = 1.0f;
    //�����ǰ�ƶ�����
    private Vector3 moveDirection;

    //QE�����Ŀ��߶�
    //private float upDistance;
    //public float upSpeed = 0.2f;

    //����Ҽ�������ת
    //private float rotateX, rotateY;
    //public float sensitivity = 0.5f;
    //���������Y�����ϵ���ֵ
    //public float minAngle = -90f;
    //public float maxAngle = 90f;
    //��¼֮ǰ��ŷ���ǣ���������
    //private Vector3 currentRotation, lastPosition;



    //camera scroll limits
    public float minX = -10f; // ��߽�
    public float maxX = 10f; // �ұ߽�
    public float minY = -10f; // �±߽�
    public float maxY = 10f; // �ϱ߽�

    //�����ֿ�������
    public float zoomSpeed = 1f; // �����ٶ�
    public float minZoom = 1f; // ��С����ֵ
    public float maxZoom = 5f; // �������ֵ

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

        // �����ƶ���
        Vector3 move = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

        // �����µ�λ��
        Vector3 newPosition = transform.position + move;

        // �����ƶ���Χ
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // �������λ��
        transform.position = newPosition;


        /*
        //ʹ��QE�������������,ʹ��unDown�������е�λ�仯
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

        //ʹ������Ҽ������������ת
        //Mouse X�������ƶ�������ֵ��Mouse Y�������ƶ����Ϊ��ֵ
        {
            if (Input.GetMouseButtonDown(1))
            {
                // ��¼��ǰ��ŷ����
                //currentRotation = transform.eulerAngles;
                //��¼���λ��
                lastPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(1))
            {
                //����ƫ����
                Vector3 offset = Input.mousePosition - lastPosition;
                rotateX += offset.x * sensitivity;
                rotateY -= offset.y * sensitivity;

                //��Y�������ת������ֵ����
                rotateY = Mathf.Clamp(rotateY, minAngle, maxAngle);
                //�ı䵱ǰ��ŷ����
                transform.eulerAngles = new Vector3(rotateY, rotateX, 0f);

                // �������ŷ�������¸�ֵ��ȥ
                transform.eulerAngles += currentRotation;
                lastPosition = Input.mousePosition;
            }
        }



        //ʹ�ù������������������3D
        {
            //��ȡ���ֵĹ������Ⱥͷ���
            zoomDistance += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            //ʹ����ֵ�������޶����ŵķ�Χ
            zoomDistance = Mathf.Clamp(zoomDistance, -10f, 10f);
            //���λ
            transform.position = transform.position + transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        }

        */
        //����
        float zoom = cam.m_Lens.OrthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        cam.m_Lens.OrthographicSize = Mathf.Clamp(zoom, minZoom, maxZoom);
    }
}

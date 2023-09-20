using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraControl : MonoBehaviour
{
    // GameObject parent;
    public GameObject target;
    Vector3 defPosition;
    Quaternion defRotation; 
    float defZoom;
    // Start is called before the first frame update
    void Start()
    {
        // parent = transform.parent.gameObject; // �θ��� transform�� gameobject�� ������

        // �⺻ ��ġ ����
        defPosition = target.transform.position;
        defRotation = target.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) // ���콺 ���� ��ư Ŭ�� �̺�Ʈ ó�� - �巡�׷� ī�޶� �̵�
        {
            target.transform.Translate(-    Input.GetAxis("Mouse X") / 10, Input.GetAxis("Mouse Y") / 10, 0); 
            // camera.main - gameobject ������ ���� �������ص� main camera�� ã�� / Mouse X - ���콺 X�� ��ȭ, Mouse Y - ���콺 Y�� ��ȭ
        }

        if(Input.GetMouseButton(1)) // ���콺 ������ ��ư Ŭ�� �̺�Ʈ ó�� - �巡�׷� ī�޶� ȸ��(unitychan�� �������� ��)
        {
            target.transform.Rotate(-Input.GetAxis("Mouse Y") * 10, -Input.GetAxis("Mouse X") * 10, 0);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0) // ���콺 �� ȸ������ Ȯ�� / ���
        {
            Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));

            if(Camera.main.fieldOfView < 10) // �Ѱ� ����
            {
                Camera.main.fieldOfView = 10;
            }
            else if(Camera.main.fieldOfView > 100)
            {
                Camera.main.fieldOfView = 100;
            }
        }

        if(Input.GetMouseButton(2)) // �� Ŭ���� ���� �ʱ�ȭ
        {
            target.transform.position = defPosition;
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}

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
        // parent = transform.parent.gameObject; // 부모의 transform의 gameobject를 가져옴

        // 기본 위치 저장
        defPosition = target.transform.position;
        defRotation = target.transform.rotation;
        defZoom = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)) // 마우스 왼쪽 버튼 클릭 이벤트 처리 - 드래그로 카메라 이동
        {
            target.transform.Translate(-    Input.GetAxis("Mouse X") / 10, Input.GetAxis("Mouse Y") / 10, 0); 
            // camera.main - gameobject 변수를 딱히 생성안해도 main camera를 찾음 / Mouse X - 마우스 X값 변화, Mouse Y - 마우스 Y값 변화
        }

        if(Input.GetMouseButton(1)) // 마우스 오른쪽 버튼 클릭 이벤트 처리 - 드래그로 카메라 회전(unitychan을 기준으로 둠)
        {
            target.transform.Rotate(-Input.GetAxis("Mouse Y") * 10, -Input.GetAxis("Mouse X") * 10, 0);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0) // 마우스 휠 회전으로 확대 / 축소
        {
            Camera.main.fieldOfView += (20 * Input.GetAxis("Mouse ScrollWheel"));

            if(Camera.main.fieldOfView < 10) // 한계 제한
            {
                Camera.main.fieldOfView = 10;
            }
            else if(Camera.main.fieldOfView > 100)
            {
                Camera.main.fieldOfView = 100;
            }
        }

        if(Input.GetMouseButton(2)) // 휠 클릭시 설정 초기화
        {
            target.transform.position = defPosition;
            target.transform.rotation = defRotation;
            Camera.main.fieldOfView = defZoom;
        }
    }
}

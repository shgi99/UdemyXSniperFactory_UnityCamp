using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerTransform; // 플레이어의 Transform을 할당할 public 변수입니다.
    public Vector3 offset = new Vector3(0f, 5f, -10f); // 카메라 위치를 조정할 오프셋(Vector3)입니다.

    private void Update()
    {
        if (playerTransform == null)
        {
            // 플레이어 Transform이 할당되지 않았을 경우 아무것도 하지 않습니다.
            return;
        }

        // 카메라의 위치를 플레이어의 위치에 오프셋을 더한 값으로 설정합니다.
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = targetPosition;
    }
}

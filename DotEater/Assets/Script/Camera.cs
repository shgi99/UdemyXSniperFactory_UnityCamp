using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾��� Transform�� �Ҵ��� public �����Դϴ�.
    public Vector3 offset = new Vector3(0f, 5f, -10f); // ī�޶� ��ġ�� ������ ������(Vector3)�Դϴ�.

    private void Update()
    {
        if (playerTransform == null)
        {
            // �÷��̾� Transform�� �Ҵ���� �ʾ��� ��� �ƹ��͵� ���� �ʽ��ϴ�.
            return;
        }

        // ī�޶��� ��ġ�� �÷��̾��� ��ġ�� �������� ���� ������ �����մϴ�.
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = targetPosition;
    }
}

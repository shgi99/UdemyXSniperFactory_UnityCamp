using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRigidbody; // �̵��� ����� Rigidbody ������Ʈ
    public float speed = 8f; // �÷��̾��� �ӷ�
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    playerRigidbody.AddForce(0f, 0f, speed);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    playerRigidbody.AddForce(0f, 0f, -speed);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    playerRigidbody.AddForce(-speed, 0f, 0f);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    playerRigidbody.AddForce(speed, 0f, 0f);
        //} // ���� �� - �Է� ���� �ڵ尡 ����

        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵��ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        // Vector3�� �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0, zSpeed);
        // Rigidbody�� �ӵ��� newVelocity ����
        playerRigidbody.velocity = newVelocity;
    }

    public void die()
    {
        // �÷��̾� ����� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}

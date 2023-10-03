using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody PointRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        PointRigidbody = GetComponent<Rigidbody>();
        PointRigidbody.velocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹 ��
        if (other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� GameManager ������Ʈ ��������
            GameManager gameManager = FindObjectOfType<GameManager>();
            // ������Ʈ�� �������µ� ���� ��
            if (gameManager != null)
            {
                gameManager.addScore();
                Destroy(gameObject);
            }
        }
        if(other.tag == "Wall")
            Destroy(gameObject);
    }
}

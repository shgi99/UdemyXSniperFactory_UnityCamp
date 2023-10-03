using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // �÷��̾�� �浹 ��
        if(other.tag == "Player")
        {
            // ���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();
            // ������Ʈ�� �������µ� ���� ��
            if(playerController != null)
            {
                playerController.die(); // PlayerController ������Ʈ�� die �޼ҵ� ����
            }
        }
        if (other.tag == "Wall")
            Destroy(gameObject);
    }

}

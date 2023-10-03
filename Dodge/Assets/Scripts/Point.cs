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
        // 플레이어와 충돌 시
        if (other.tag == "Player")
        {
            // 상대방 게임 오브젝트에서 GameManager 컴포넌트 가져오기
            GameManager gameManager = FindObjectOfType<GameManager>();
            // 컴포넌트를 가져오는데 성공 시
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRigidbody; // 이동에 사용할 Rigidbody 컴포넌트
    public float speed = 8f; // 플레이어의 속력
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
        //} // 수정 전 - 입력 감지 코드가 복잡

        // 수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        // Vector3의 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3 (xSpeed, 0, zSpeed);
        // Rigidbody의 속도에 newVelocity 저장
        playerRigidbody.velocity = newVelocity;
    }

    public void die()
    {
        // 플레이어 사망시 오브젝트 비활성화
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}

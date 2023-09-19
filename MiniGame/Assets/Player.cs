using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpPower = 10;
    public float y_low = -4;
    public float boost_jump = 1.5f;
    public float move_x = 0.5f;
    public float scale_y = 0.2f;
    public float rotation_x = 200.0f;
    public float rotation_z = 300.0f;
    TextMesh scoreOutput;
    int score = 0;
    void Start()
    {
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>(); // 이름으로 게임 오브젝트를 찾고, 그중 TextMesh 컴포넌트를 얻음
    }

    // Update is called once per frame 
    void Update()
    {
        transform.Rotate(rotation_x * Time.deltaTime, 0, rotation_z * Time.deltaTime);
        transform.position += new Vector3(move_x * Time.deltaTime, 0, 0); // 계속 앞으로 전진함
        // transform.localScale += new Vector3(0, scale_y * Time.deltaTime, 0); // 오브젝트의 y scale을 키움 / local은 나 자신, local이 안붙으면 자식? 상속된거도 해당된다
        if (Input.GetButtonDown("Jump")) // "Jump"는 문자열이라 문자가 달라도 문제 인식을 못하지만 발동은 안될것이다. 이 점 유의
        {
            if(transform.position.y < y_low)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower * boost_jump, 0); // 높이가 낮을경우 부스트 점프 발동
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            }
        }
            
    }

    private void OnCollisionEnter(Collision collision) // Collider에 충돌하게 되면 발동 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 켜져있는 씬을 불러옴 - 처음부터 시작, GetActiveScene = 현재 씬
    }

    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "점수 : " + score;
    }
}
    
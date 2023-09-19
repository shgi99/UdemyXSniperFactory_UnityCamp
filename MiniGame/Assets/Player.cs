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
        scoreOutput = GameObject.Find(name: "Score").GetComponent<TextMesh>(); // �̸����� ���� ������Ʈ�� ã��, ���� TextMesh ������Ʈ�� ����
    }

    // Update is called once per frame 
    void Update()
    {
        transform.Rotate(rotation_x * Time.deltaTime, 0, rotation_z * Time.deltaTime);
        transform.position += new Vector3(move_x * Time.deltaTime, 0, 0); // ��� ������ ������
        // transform.localScale += new Vector3(0, scale_y * Time.deltaTime, 0); // ������Ʈ�� y scale�� Ű�� / local�� �� �ڽ�, local�� �Ⱥ����� �ڽ�? ��ӵȰŵ� �ش�ȴ�
        if (Input.GetButtonDown("Jump")) // "Jump"�� ���ڿ��̶� ���ڰ� �޶� ���� �ν��� �������� �ߵ��� �ȵɰ��̴�. �� �� ����
        {
            if(transform.position.y < y_low)
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower * boost_jump, 0); // ���̰� ������� �ν�Ʈ ���� �ߵ�
            }
            else
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            }
        }
            
    }

    private void OnCollisionEnter(Collision collision) // Collider�� �浹�ϰ� �Ǹ� �ߵ� 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �����ִ� ���� �ҷ��� - ó������ ����, GetActiveScene = ���� ��
    }

    public void addScore(int s)
    {
        score += s;
        scoreOutput.text = "���� : " + score;
    }
}
    
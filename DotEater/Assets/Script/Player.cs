using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float rotataionSpeed = 360f;
    public int itemcnt;
    public Text ItemText;

    CharacterController charCtrl;
    Animator anim;
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        itemcnt = GameObject.FindGameObjectsWithTag("Dot").Length;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(dir.sqrMagnitude > 0.01f) // 앞을 보면서 이동하게 하는 코드
        {
            Vector3 forward = Vector3.Slerp(transform.forward, dir, rotataionSpeed * Time.deltaTime / Vector3.Angle(transform.forward, dir));
            transform.LookAt(transform.position + forward);
        }
        charCtrl.Move(dir * moveSpeed * Time.deltaTime);
        anim.SetFloat("Speed", charCtrl.velocity.magnitude); // Parameter의 Speed에 뒤에 값을 넣음, magnitude - 일반화(0~1까지의 값)
        if(GameObject.FindGameObjectsWithTag("Dot").Length < 1)
        {
            if(SceneManager.GetActiveScene().name == "Main_2")
            {
                SceneManager.LoadScene("Win"); // Win 씬 로드
            }
            else
            {
                SceneManager.LoadScene("Main_2"); // 스테이지2 씬 로드
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Dot":
                Destroy(other.gameObject);
                ItemText.text = "Dots Remain : " + GameObject.FindGameObjectsWithTag("Dot").Length + " / " + itemcnt;
                break;
            case "Enemy":
                SceneManager.LoadScene("Lose"); // 적에게 닿을시 패배 - Lose 씬 로드
                break;
        }
    }
}

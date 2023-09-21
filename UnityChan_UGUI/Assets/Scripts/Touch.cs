using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    // 모션 스테이트의 ID 얻기
    private int motionIdol = Animator.StringToHash("Base Layer.Idol");
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        univoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // false로 설정해놓아야 클릭했을때만 true로 전환함으로써 애니메이션이 발동되도록 가능
        animator.SetBool("Touch", false); 
        animator.SetBool("TouchHead", false);

        if(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol ) // 재생 중인 동작이 대기 동작인지 검사
        {
            animator.SetBool("Motion_Idle", true);
        }
        else
        {
            animator.SetBool("Motion_Idle", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100)) 
            {
                GameObject hitObj = hit.collider.gameObject; // 터치한 부분의 오브젝트 파악 후 부위(태크)별로 반응 다르게 하기
                if(hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                }
                else if(hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                }
            }
        }
    }
}

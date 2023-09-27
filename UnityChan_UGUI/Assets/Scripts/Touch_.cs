using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_ : MonoBehaviour
{
    System.DateTime now;
    public AudioClip voice1;
    public AudioClip voice2;
    private Animator animator;
    private AudioSource univoice;

    // ��� ������Ʈ�� ID ���
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
        now = System.DateTime.Now;
        // false�� �����س��ƾ� Ŭ���������� true�� ��ȯ�����ν� �ִϸ��̼��� �ߵ��ǵ��� ����
        animator.SetBool("Touch", false); 
        animator.SetBool("TouchHead", false);

        if(animator.GetCurrentAnimatorStateInfo(0).fullPathHash == motionIdol ) // ��� ���� ������ ��� �������� �˻�
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
                GameObject hitObj = hit.collider.gameObject; // ��ġ�� �κ��� ������Ʈ �ľ� �� ����(��ũ)���� ���� �ٸ��� �ϱ�
                if(hitObj.tag == "Head")
                {
                    animator.SetBool("TouchHead", true);
                    animator.SetBool("Face_Happy", true);
                    animator.SetBool("Face_Angry", false);
                    univoice.clip = voice1;
                    univoice.Play();
                    MsgDisp.SaveMessage("�ȳ�!\n���õ� ������ �����غ���!");
                }
                else if(hitObj.tag == "Body")
                {
                    animator.SetBool("Touch", true);
                    animator.SetBool("Face_Happy", false);
                    animator.SetBool("Face_Angry", true);
                    univoice.clip = voice2;
                    univoice.Play();
                    MsgDisp.SaveMessage("��!");
                }
                else if(hitObj.tag == "Arms")
                {
                    MsgDisp.SaveMessage("������\n" + now.Year + "�� " + now.Month + "�� " + now.Day + "�� " + now.Hour + "�� " + now.Minute + "�� " + now.Second + "�ʾ�!");
                }
            }
        }
    }
}
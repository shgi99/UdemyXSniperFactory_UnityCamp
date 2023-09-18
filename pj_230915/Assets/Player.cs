using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public int itemCount;
    public int finalCount = 10;
    public Text CountText;
    public Text ClearText;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = 0;
        SetCountText();
        ClearText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Finish")
        {
            if(itemCount == finalCount)
            {
                ClearText.text = "Clear !!";
            }
        }
        else
        {
            itemCount++; // 점수 올리기 
            Destroy(other.gameObject); //아이템 비활성화 
            SetCountText();
        }
    }
    void OnCollisionEnter(Collision collision)
    { //공이 바닥과 닿으면 다시 시작 

        if (collision.gameObject.name == "fall_Plane")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void SetCountText()
    {
        CountText.text = "갯수: " + itemCount.ToString() + " / " + finalCount.ToString();
    }
}

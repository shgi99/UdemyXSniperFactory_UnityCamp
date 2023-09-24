using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MsgDisp : MonoBehaviour
{
    public static string msg;
    public static bool flagDisplay;

    public Image Msg;
    public Text msgtext;
    private float waitDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flagDisplay)
        {
            waitDelay += Time.deltaTime;
            
            if(waitDelay > 6.0f)
            {
                flagDisplay = false;
                waitDelay = 0;
            }
            else
            {
                Msg.gameObject.SetActive(true);
            }
        }
        else
        {
            Msg.gameObject.SetActive(false);
        }

        if (!string.IsNullOrEmpty(msg))
        {
            ShowMessage(msg);
            msg = null;
        }
           
    }
    public static void SaveMessage(string msg)
    {
        MsgDisp.msg = msg;
    }

    public void ShowMessage(string msg)
    {
        flagDisplay = true;
        msgtext.text = msg;
    }
}

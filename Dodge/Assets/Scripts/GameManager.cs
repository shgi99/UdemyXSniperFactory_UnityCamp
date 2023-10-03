using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;
    private float surviveRecord;
    public bool isGameover;
    // Start is called before the first frame update
    void Start()
    {
        surviveRecord = 0;
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
        {
            surviveRecord += Time.deltaTime;
            timeText.text = "Record : " + (int)surviveRecord;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestRecord = PlayerPrefs.GetFloat("BestRecord");

        if(surviveRecord > bestRecord)
        {
            bestRecord = surviveRecord;
            PlayerPrefs.SetFloat("BestRecord", bestRecord);
        }

        recordText.text = "Best Record : " + (int)bestRecord;
    }
    public void addScore()
    {
        surviveRecord += 5;
    }
    public bool Get_isGameover()
    {
        return isGameover;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 60f;
    public bool isGameover;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGameover = FindObjectOfType<GameManager>().isGameover;
        if (!isGameover)
        {
            transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }
        else
        {
            transform.Rotate(0f, 0f, 0f);
        }
    }
}

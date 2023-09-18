using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public float interval = 1.5f;
    public float interval_2 = 2f;// 일정 시간
    public float range = 3;
    float term, term_2;
    // Start is called before the first frame update
    void Start()
    {
        term = interval; // 시작부터 벽이 하나 나오게 하기 위해
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        term_2 += Time.deltaTime;
        if (term >= interval) // 일정시간이 지나면
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation); // 다양한 벽들을 무작위로 생성
            if(Random.Range(0, 2) == 1)
            {
                // Instantiate(dropPrefab); // 50%의 확률로 떨어지는 장애물 생성
            }
            term -= interval;
        }

        if(term_2 >= interval_2)
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            Instantiate(coinPrefab, pos, transform.rotation);
            term_2 -= interval_2;
        }
    }
}

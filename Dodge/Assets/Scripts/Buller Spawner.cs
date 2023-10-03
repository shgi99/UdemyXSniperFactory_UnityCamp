using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerSpawner : MonoBehaviour
{
    public GameObject bulletPointPrefab;
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기
    public bool isGameover;

    private Transform target; // 발사할 대상 
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성시점에서 지난 시간
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f; // 최근 생성 이후 0으로 초기화
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // 탄약 생성 간격을 범위 안의 랜덤으로 지정
        target = FindObjectOfType<PlayerController>().transform; // PlayerController 컴포넌트를 가진 오브젝트를 찾아 타겟으로 설정
    }

    // Update is called once per frame
    void Update()
    {
        isGameover = FindObjectOfType<GameManager>().isGameover;
        if (!isGameover)
        {
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0;

                GameObject bullet = Instantiate(bulletPointPrefab, transform.position, transform.rotation);

                bullet.transform.LookAt(target);

                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }
        timeAfterSpawn += Time.deltaTime;

    }
}

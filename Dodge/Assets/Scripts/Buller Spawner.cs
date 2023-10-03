using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullerSpawner : MonoBehaviour
{
    public GameObject bulletPointPrefab;
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�
    public bool isGameover;

    private Transform target; // �߻��� ��� 
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ������������ ���� �ð�
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f; // �ֱ� ���� ���� 0���� �ʱ�ȭ
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); // ź�� ���� ������ ���� ���� �������� ����
        target = FindObjectOfType<PlayerController>().transform; // PlayerController ������Ʈ�� ���� ������Ʈ�� ã�� Ÿ������ ����
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

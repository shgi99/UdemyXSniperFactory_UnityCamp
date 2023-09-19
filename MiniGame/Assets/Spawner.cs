using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] wallPrefab;
    public GameObject dropPrefab;
    public float interval = 1.1f; // ���� �ð�
    public float range = 3;
    float term;
    // Start is called before the first frame update
    void Start()
    {
        term = interval; // ���ۺ��� ���� �ϳ� ������ �ϱ� ����
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if(term >= interval) // �����ð��� ������
        {
            Vector3 pos = transform.position;
            pos.y += Random.Range(-range, range);
            int wallType = Random.Range(0, wallPrefab.Length);
            Instantiate(wallPrefab[wallType], pos, transform.rotation); // �پ��� ������ �������� ����
            if(Random.Range(0, 2) == 1)
            {
                Instantiate(dropPrefab); // 50%�� Ȯ���� �������� ��ֹ� ����
            }
            term -= interval;
        }
    }
}

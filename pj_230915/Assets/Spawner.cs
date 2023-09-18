using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ItemPrefab;
    public float interval = 5.0f;
    float term = 0;
    // Start is called before the first frame update
    void Start()
    {
        term = interval;
    }

    // Update is called once per frame
    void Update()
    {
        term += Time.deltaTime;
        if(term >= interval)
        {
            Vector3 pos = transform.position;
            pos.y = 4;
            pos.x = Random.Range(0, 35);
            pos.z = Random.Range(0, 35);
            Instantiate(ItemPrefab, pos, transform.rotation);
            term -= interval;
        }
    }
}

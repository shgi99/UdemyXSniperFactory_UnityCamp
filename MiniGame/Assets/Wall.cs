using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = -4;
    public float rotation_z;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        rotation_z = Random.Range(0, 30);
        transform.Rotate(0, 0, rotation_z);
        player = GameObject.Find(name : "Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // X방향으로 움직이게 함, Time.deltaTime은 아주 작은 값으로 이걸 곱해줘서 speed만큼 이동하게끔 만들어줌
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            player.addScore(Random.Range(1, 5));
            Destroy(gameObject);
        } // x값이 -10, 범위 밖에면 삭제와 점수 1~5점
            
    }
}

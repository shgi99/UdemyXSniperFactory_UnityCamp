using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = -4;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name: "Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // X방향으로 움직이게 함, Time.deltaTime은 아주 작은 값으로 이걸 곱해줘서 speed만큼 이동하게끔 만들어줌
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        } // x값이 -10, 범위 밖에면 삭제와
    }
}

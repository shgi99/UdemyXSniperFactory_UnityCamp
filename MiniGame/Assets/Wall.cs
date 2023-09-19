using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = -6;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(name : "Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // X�������� �����̰� ��, Time.deltaTime�� ���� ���� ������ �̰� �����༭ speed��ŭ �̵��ϰԲ� �������
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
            player.addScore(1);
        } // x���� -10, ���� �ۿ��� ������ ���� +1
            
    }
}

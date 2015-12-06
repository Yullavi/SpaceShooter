
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int speed = 100;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!Cosmos.Pause)
        {
            var step = transform.position;

            step.z += speed * Time.deltaTime;
            transform.position = step;

            if (step.z > 300)
            {
                Destroy(gameObject);
            }
        }
    }
    //Вызывается Юнитью при столкновении коллайдера, висящего на скрипте, и любого другого
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "meteor")
        {
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
    }
}

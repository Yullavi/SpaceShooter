using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
    public int speed = 35;
    private Vector3 myVector3;
    // Use this for initialization
    void Start()
    {
        myVector3 = Random.onUnitSphere;
    }

    // Update is called once per frame
    void Update() {
        if (!Cosmos.Pause)
        {
            var step = transform.position;


            step.z -= speed*Time.deltaTime;
            transform.position = step;
            transform.Rotate(myVector3,(16*Time.deltaTime));

            if (step.z < -5)
            {
                Destroy(gameObject);
            }
        }
    }

}

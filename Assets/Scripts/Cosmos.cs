using UnityEngine;
using System.Collections;

public class Cosmos : MonoBehaviour
{

    // Use this for initialization
    public static bool Pause;
    public Meteor MeteorPrefab;
    public Rocket Rocket;
    private int count { set; get; }
    void Start()
    {
        Rocket.Collision += Rocket_Collision;
    }

    private void Rocket_Collision()
    {
        Debug.Log("попали");
        Pause = true;


    }

    void FixedUpdate()
    {
        if (!Pause)
        {
            if (Random.value < 1)
            {
                var posX = transform.position;
                posX.x = Random.Range(-30, 30);
                var meteors = GameObject.FindObjectsOfType<Meteor>();

                for (int i = 0; i < meteors.Length; i++)
                {
                    if (Vector3.Distance(meteors[i].transform.position, posX) < 21)
                        return;
                }
                
                var meteor = (Meteor)Instantiate(MeteorPrefab, posX, Random.rotation);
                meteor.transform.localScale = Vector3.one * Random.Range(0.1F, 0.3F);
                meteor.name = "meteor";
            }
        }

    }

    // Update is called once per frame

    void Update()
    {
        if (Rocket.HalfDead && Input.GetKey(KeyCode.Space))
        {
            Pause = false;
            Rocket.Go();
        }
    }

}

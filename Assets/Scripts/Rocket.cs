using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    public float MoveSpeed = 10;
    public GameObject Explosion;
    public bool HalfDead;
    private float timeBlink = 0.30f;
    public float Constraint = 8.0f;
    public Image[] Hearts;
    private LineRenderer Laser;
    private MeshRenderer[] Ship;
    private Renderer Fire;
    public GameObject ParticleSystemPrefab;
    private Weapon[] shootArray;

    public event Action Collision;

    private int Heart;

    // Use this for initialization
    void Start()
    {
        Ship = GetComponentsInChildren<MeshRenderer>();
        Fire = ParticleSystemPrefab.GetComponent<Renderer>();
        Heart = Hearts.Length;
        shootArray = GetComponentsInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //создает массив наследников Weapon
        for (int i = 0; i < shootArray.Length; i++)
        {
            if (Input.GetKey((KeyCode) (49 + i)))
            {
                shootArray[i].Shoot(); //выстрел первого наследника
            }
        }

        if (HalfDead)
        {
            timeBlink -= Time.deltaTime;
            if (timeBlink < 0.0)
            {
                foreach (var shipMesh in Ship)
                {
                    shipMesh.enabled = !shipMesh.enabled;
                }
                Fire.enabled = !Fire.enabled;

                timeBlink = 0.50f;
            }
        }
        else
        {

            var pos = transform.position;
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -Constraint)
            {
                pos.x -= MoveSpeed * Time.deltaTime;
                transform.position = pos;
            }
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < Constraint)
            {
                pos.x += MoveSpeed * Time.deltaTime;
                transform.position = pos;
            }
        }

    }


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "meteor")
        {
            Collision();

            Destroy(collision.gameObject);
            Stop();
            if (Heart > 0)
                HalfDead = true;
            else
            {
                Destroy(gameObject);
                Instantiate(Explosion, transform.position, transform.rotation);
            }
        }
    }

    public void Stop()
    {
        Heart -= 1;
        Hearts[Heart].gameObject.SetActive(false);

    }

    public void Go()
    {
        HalfDead = false;
        foreach (var meshRenderer in Ship)
        {
            meshRenderer.enabled = true;
        }
        ParticleSystemPrefab.GetComponent<Renderer>().enabled = true;
    }

}

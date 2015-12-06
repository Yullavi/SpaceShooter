using UnityEngine;
using System.Collections;

public class Lazer : Weapon
{
    void Update()
    {
        timer = Time.deltaTime;


        if (timer >= timeBetweenBullete * effectsDisplayTime)
        {
            DisableEffects();
        }
    }
    void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    // Use this for initialization
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponentInChildren<Light>();
    }


    public override void Shoot()
    {
        base.Shoot();

        timer = 0f;

          gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position); // Начальная точка стрельбы

        shootRay.origin = transform.position;
        shootRay.direction = Vector3.forward; // стрелять прямо по направлению оси z

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) // если луч попадает на игровой объект, то прерывается. иначе отрисовывается на 100 едениц,за пределы поля
        {
            Destroy(shootHit.collider.gameObject);

        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }



    }
}

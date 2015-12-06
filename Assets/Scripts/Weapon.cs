using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float timeBetweenBullete = 0.15f;  //промежуток времени между выстрелами
    public float range = 100f; // на сколько пули достигают объектов

    public float timer { get; set; } // правильное время атаки игроком
     protected Ray shootRay; // луч
    protected RaycastHit shootHit; // определение, кого подстреливаем
    protected int shootableMask; // кого стреляем
    protected ParticleSystem gunParticles;
    protected LineRenderer gunLine;
    protected AudioSource gunAudio;
    protected Light gunLight;
    public float effectsDisplayTime = 0.1f; // продолжительность эффектов




	// Use this for initialization
	void Awake () 
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame

    public virtual void Shoot ()
    {
        gunAudio.Play();

        /*timer = 0f;
        
        
        gunLight.enabled = true;
       
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position); // Начальная точка стрельбы

        shootRay.origin = transform.position;
        shootRay.direction = Vector3.forward; // стрелять прямо по направлению оси z

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask)) // если луч попадает на игровой объект, то прерывается. иначе отрисовывается на 100 едениц,за пределы поля
        {
            Destroy(shootHit.collider.gameObject);
            
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }*/



    }
}

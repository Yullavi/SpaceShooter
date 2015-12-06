using System;
using UnityEngine;
using System.Collections;

public class Cannon : Weapon
{
    public Bullet BulletPrefab;

    public override void Shoot()
    {
        base.Shoot();
        var guns = (Bullet)Instantiate(BulletPrefab, transform.position, transform.rotation);
    }
}

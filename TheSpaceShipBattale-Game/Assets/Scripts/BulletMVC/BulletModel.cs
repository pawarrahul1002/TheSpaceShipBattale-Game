using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{

    public float bulletForce { get; private set; }
    public float damage { get; private set; }
    // public BulletTypes type;
    private BulletController bulletController;
    public BulletModel(BulletScriptableObject bulletSO)
    {

        bulletForce = bulletSO.bulletForce;
        damage = bulletSO.bulletDamage;
        // type = bulletSO.bulletTypes;
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
}
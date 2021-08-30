using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    /*BulletModel : this is class use to assign properties from scriptable object*/
    public class BulletModel
    {

        public float bulletForce { get; private set; }
        public float damage { get; private set; }
        public BulletType bulletType;
        private BulletController bulletController;

        //BulletModel : below is the contructor in that assigning properties from scriptable object
        public BulletModel(BulletScriptableObject bulletSO)
        {

            this.bulletForce = bulletSO.bulletForce;
            this.damage = bulletSO.bulletDamage;
            this.bulletType = bulletSO.bulletType;
        }

        //SetBulletController : this is use for setting current controller 
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }
    }
}
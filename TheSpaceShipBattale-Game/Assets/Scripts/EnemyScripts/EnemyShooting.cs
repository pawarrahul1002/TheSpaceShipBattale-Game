using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    /*EnemyShooting :  this class is help in shooting bullet with fire rate control*/
    public class EnemyShooting : MonoBehaviour
    {
        [SerializeField] private Transform[] firePoints;
        [SerializeField] private BulletScriptableObject bullet;
        [SerializeField] private float fireRate = 1.2f;

        private float canFire = 0f;

        void Update()
        {
            ShootBullet();
        }

        //use for shooting bullet of enemies after specific timing 
        private void ShootBullet()
        {
            if (canFire < Time.time)
            {
                canFire = fireRate + Time.time;
                CreatingBullet();
            }
        }

        //creating bullet for enemies by getting instance if bullet controller
        public void CreatingBullet()
        {
            BulletServices.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        public Transform[] GetFiringPosition()
        {
            return firePoints;
        }
        public Quaternion GetFiringAngle()
        {
            return this.transform.rotation;
        }
        public BulletScriptableObject GetBullet()
        {
            return bullet;
        }
    }
}
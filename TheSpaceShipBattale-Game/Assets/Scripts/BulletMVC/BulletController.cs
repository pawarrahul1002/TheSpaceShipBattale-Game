using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfMidWay
{

    /*BulletController : this controller we used to instatiate bullet using constructor also
        we have movement script in it */

    public class BulletController
    {
        public BulletView bulletView { get; private set; }
        public BulletModel bulletModel { get; private set; }
        private Rigidbody2D rigidbody2d;
        public BulletController(BulletView _bulletView, BulletModel _bulletModel, Vector3 position, Quaternion rotation)
        {
            this.bulletModel = _bulletModel;
            this.bulletView = GameObject.Instantiate<BulletView>(_bulletView, position, Quaternion.Euler(0f, 0f, 90f));
            this.bulletView.SetBulletController(this);
            this.bulletModel.SetBulletController(this);
            this.rigidbody2d = bulletView.GetComponent<Rigidbody2D>();
            SoundManager.Instance.Play(Sounds.Laser);
        }


        //movement : this fun is for giving force to bullet after instatiate for both player and enemy in up and down dir
        public void Movement()
        {
            if (this.bulletModel.bulletType == BulletType.player)
            {
                bulletView.transform.Translate(Vector2.right * bulletModel.bulletForce * Time.deltaTime);
            }
            else if (this.bulletModel.bulletType == BulletType.Enemy)
            {
                bulletView.transform.Translate(Vector2.left * bulletModel.bulletForce * Time.deltaTime);
            }
        }
    }

}

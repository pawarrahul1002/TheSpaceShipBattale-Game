using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    /*
     PlayerView : player view is monobeahiour class attached to player prefab , use ful for getting input
         from player, also input for shooting and we controll shooting using
         fire rate by getting it from player model*/
    public class PlayerView : MonoBehaviour
    {
        private float canFire = 0f;
        public Transform[] firePoint;
        public BulletScriptableObject bullet;
        private PlayerController playerController;
        public void SetPlayerController(PlayerController playerController)
        {
            this.playerController = playerController;
            Debug.Log(this.playerController);
        }


        void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            playerController.MovePlayer(x, y);
            ShootBullet();
        }


        //ShootBullet :  this function we use for shotting bullet from player
        private void ShootBullet()
        {
            if (Input.GetButtonDown("Fire1") && canFire < Time.time)
            {
                canFire = playerController.playerModel.fireRate + Time.time;
                playerController.ShootBullet();
            }
        }


        //OnTriggerEnter2D : we set trigger checked and check what touches to player
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy") || other.CompareTag("Asteroid"))
            {
                ScoreController.instance.ActiveGameOverPanel();
            }
            else if (other.CompareTag("PowerUpHealth"))
            {
                playerController.PowerUpHealth();
                Destroy(other.gameObject);
            }
        }


        //DestroyView :  use after destroy called in player controller
        public void DestroyView()
        {
            playerController = null;
            firePoint = null;
            Destroy(this.gameObject);
        }



    }
}

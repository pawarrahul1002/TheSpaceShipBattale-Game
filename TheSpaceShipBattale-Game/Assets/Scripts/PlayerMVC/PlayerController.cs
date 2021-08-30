using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    //PlayerController : controll and instantiate player prefab with model and view
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        private float maxX_PlayerPos = 4f;
        private float maxY_PlayerPos = -7f;

        public PlayerController(PlayerModel playerModel, PlayerView playerView)
        {
            this.playerModel = playerModel;
            this.playerView = GameObject.Instantiate<PlayerView>(playerView, new Vector3(0f, -5f, 0f), Quaternion.identity);
            this.playerView.SetPlayerController(this);
        }

        //MovePlayer :  moves player if diffrent direction with constarints in  x and y axis at some pos
        public void MovePlayer(float xInput, float yInput)
        {
            Vector3 moveDir = new Vector3(xInput, yInput).normalized;

            Vector3 playerPos = playerView.transform.position;

            playerPos += moveDir * playerModel.movementSpeed * Time.deltaTime;

            playerPos.x = Mathf.Clamp(playerPos.x, -maxX_PlayerPos, maxX_PlayerPos);

            playerPos.y = Mathf.Clamp(playerPos.y, maxY_PlayerPos, 0);

            playerView.transform.position = new Vector2(playerPos.x, playerPos.y);

        }

        //ShootBullet:  this is for creating instance and bullet for player
        public void ShootBullet()
        {
            BulletServices.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        //getting fire point position from player view
        public Transform[] GetFiringPosition()
        {
            return playerView.firePoint;
        }

        //getting firing angle from player view
        public Quaternion GetFiringAngle()
        {
            return playerView.transform.rotation;
        }

        //getting bullet type from bullet scripatble object
        public BulletScriptableObject GetBullet()
        {
            return playerView.bullet;
        }


        //PowerUpHealth :  this function is called when player toches power ups
        public void PowerUpHealth()
        {
            playerModel.health += 50;
            ScoreController.instance.UpdateHealthText(playerModel.health);
        }

        //ApplyDamage : reduces health of player in this function, use when player touches bullet
        public void ApplyDamage(int damage)
        {
            if (playerModel != null)
            {
                if (playerModel.health > 0)
                {
                    ScoreController.instance.UpdateHealthText(playerModel.health);
                    playerModel.health -= damage;
                }
                else
                {
                    ScoreController.instance.UpdateHealthText(0);
                    ScoreController.instance.ActiveGameOverPanel();
                    Dead();
                }
            }
        }


        //dead : this fuc is called when player health is low or player toches enemy or asteroid
        private void Dead()
        {
            PlayerService.instance.DestroyPlayer(this);
        }


        //this is good prectice to assign null before destroy
        public void DestroyController()
        {
            playerModel.DestroyModel();
            playerView.DestroyView();
            playerModel = null;
            playerView = null;
        }
    }

}

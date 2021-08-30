using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    //PlayerModel : used to get properies and behaviour of player from scriptable object
    public class PlayerModel
    {
        private PlayerController playerController;
        public float movementSpeed { get; private set; }
        public int health { get; set; }
        public float fireRate { get; private set; }

        public PlayerModel(PlayerScriptableObject playerSO)
        {
            movementSpeed = playerSO.speed;
            health = playerSO.health;
            fireRate = playerSO.fireRate;
        }


        //setting player controller instance using SetPlayerController
        public void SetPlayerController(PlayerController PlayerController)
        {
            this.playerController = PlayerController;
        }

        //this is use after mail player destroy
        public void DestroyModel()
        {
            playerController = null;
        }

    }
}
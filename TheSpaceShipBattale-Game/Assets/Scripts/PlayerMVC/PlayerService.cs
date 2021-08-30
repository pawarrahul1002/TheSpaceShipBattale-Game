using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    /*PlayerService : use to deal with different services of player like instatiate,*/
    public class PlayerService : MonoSingletonGeneric<PlayerService>
    {
        public PlayerScriptableObject playerSO;
        private PlayerController playerController;
        public PlayerModel playerModel;

        void Start()
        {
            CreatePlayer();
        }

        //creating player by calling cinstructor of player controller
        public void CreatePlayer()
        {
            PlayerModel playerModel = new PlayerModel(playerSO);
            playerController = new PlayerController(playerModel, playerSO.playerView);
        }

        //getting player model
        public PlayerModel GetPlayerModel()
        {
            return playerModel;
        }

        //for getting player controller in another scripts
        public PlayerController GetPlayerController()
        {
            return playerController;
        }

        //called when we destroy player , it importatnt coz we are dealing with destroy service
        public void DestroyPlayer(PlayerController player)
        {
            player.DestroyController();
        }

    }
}
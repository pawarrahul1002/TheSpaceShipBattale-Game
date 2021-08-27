using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoSingletonGeneric<PlayerService>
{
    public PlayerScriptableObject playerSO;
    private PlayerController playerController;
    private PlayerModel playerModel;



    void Start()
    {
        CreateTank();
    }

    public void CreateTank()
    {
        PlayerModel playerModel = new PlayerModel(playerSO);
        playerController = new PlayerController(playerModel, playerSO.playerView);
    }

    // public PlayerModel GetPlayerModel()
    // {
    //     return playerModel;
    // }
    // public PlayerController GetPlayerController()
    // {
    //     return playerController;
    // }

}

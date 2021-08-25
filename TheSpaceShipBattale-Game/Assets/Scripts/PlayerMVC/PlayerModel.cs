using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private PlayerController playerController;
    public float movementSpeed { get; private set; }
    public float health { get; set; }
    public float fireRate { get; private set; }
    // public PlayerScriptableObject bulletType { get; private set; }



    public PlayerModel(PlayerScriptableObject playerSO)
    {
        movementSpeed = playerSO.speed;
        health = playerSO.health;
        fireRate = playerSO.fireRate;
    }

    public void SetPlayerController(PlayerController PlayerController)
    {
        this.playerController = PlayerController;
    }

}

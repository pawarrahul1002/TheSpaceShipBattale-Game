using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // Shoot();
        ShootBullet();
    }

    // void Shoot()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         bulletView = Instantiate(bulletView, firePoint.position, Quaternion.Euler(0f, 0f, 90f));
    //     }
    // }

    private void ShootBullet()
    {
        if (Input.GetButtonDown("Fire1") && canFire < Time.time)
        {
            // Debug.Log(canFire);
            canFire = playerController.playerModel.fireRate + Time.time;
            playerController.ShootBullet();
        }
    }

}

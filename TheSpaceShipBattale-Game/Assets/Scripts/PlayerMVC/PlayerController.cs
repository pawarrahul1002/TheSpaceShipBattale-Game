using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public float max_X = 7f;
    public float max_Y = -7f;
    public PlayerModel playerModel { get; private set; }
    public PlayerView playerView { get; private set; }

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = GameObject.Instantiate<PlayerView>(playerView, new Vector3(0f, -5f, 0f), Quaternion.identity);
        this.playerView.SetPlayerController(this);
    }


    public void MovePlayer(float x, float y)
    {
        Vector3 moveDir = new Vector3(x, y).normalized;

        Vector3 playerPos = playerView.transform.position;

        playerPos += moveDir * playerModel.movementSpeed * Time.deltaTime;

        if (playerPos.x < max_X && x > 0)
        {
            playerView.transform.position = new Vector2(playerPos.x, playerView.transform.position.y);
        }
        else if (playerPos.x > -max_X && x < 0)
        {
            playerView.transform.position = new Vector2(playerPos.x, playerView.transform.position.y);
        }
        else if (playerPos.y < 0 && y > 0)
        {
            playerView.transform.position = new Vector2(playerView.transform.position.x, playerPos.y);
        }
        else if (playerPos.y > max_Y && y < 0)
        {
            playerView.transform.position = new Vector2(playerView.transform.position.x, playerPos.y);
        }
    }


    public void ShootBullet()
    {
        BulletServices.instance.CreateBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
    }

    // public Vector3 GetFiringPosition()
    // {
    //     return playerView.firePoint.position;
    // }
    public Transform[] GetFiringPosition()
    {
        return playerView.firePoint;
    }
    public Quaternion GetFiringAngle()
    {
        return playerView.transform.rotation;
    }
    public BulletScriptableObject GetBullet()
    {
        return playerView.bullet;
    }

}



// [Header("Ship Speed")]

// public float _moveSpeed;
// // private PlayerInputActions _playerInput;
// private Rigidbody2D _rb;

// public bool _canMove;

// void Awake()
// {
//     _canMove = true;
//     // _playerInput = new PlayerInputActions();
//     _rb = GetComponent<Rigidbody2D>();
// }
// // Disable and Enable
// private void OnEnable()
// {
//     // _playerInput.Enable();    
// }

// private void OnDisable()
// {
//     // _playerInput.Disable();
// }
// // Topdown Movement System
// void FixedUpdate()
// {

//     if (!_canMove)
//     {
//         _rb.velocity = new Vector2(0, 0);

//     }

//     if (_canMove)
//     {
//         // Vector2 _moveInput = _playerInput.Movement.Move.ReadValue<Vector2>();
//         // _rb.velocity = _moveInput * _moveSpeed;
//     }
// }
// }



// Debug.Log(moveDir);
// Vector3 playerPos = playerView.transform.position;

// playerPos += moveDir * playerModel.movementSpeed * Time.deltaTime;


// if (playerPos.x < 10f)
// {
//     playerPos += moveDir * playerModel.movementSpeed * Time.deltaTime;
// }

// if (playerView.transform.position.x > -10f && playerView.transform.position.x < 10f
//         && playerView.transform.position.y > -10f && playerView.transform.position.y < 10f)
// if (playerPos.x < 10f)
// {
// }



// Vector3 move = playerView.transform.transform.position;
// move.x += playerView.transform.position.x * X_Input * Time.fixedDeltaTime;
// rgbd2d.MovePosition(move);
// Vector3 temp = playerView.transform.position;
// Debug.Log(X_Input);
// // playerView.transform.position += temp * 25f * Time.deltaTime;
// if (x > 0f && )
// {
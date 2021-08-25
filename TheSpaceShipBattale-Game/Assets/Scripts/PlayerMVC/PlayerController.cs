using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    public PlayerModel playerModel { get; private set; }
    public PlayerView playerView { get; private set; }

    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        this.playerModel = playerModel;
        this.playerView = playerView;

        playerView = GameObject.Instantiate<PlayerView>(playerView);
    }
    // public float speed = 5f;

    public float min_X, max_X;

    // void Update()
    // {
    //     // MovePlayer();
    // }

    // [SerializeField]
    // // private GameObject player_Bullet;

    // [SerializeField]
    // // private Transform attack_Point;

    // public float attack_Timer = 0.35f;
    // private float current_Attack_Timer;
    // private bool canAttack;

    // private AudioSource laserAudio;
    // public AudioClip destroyClip;

    // private Animator anim;
    // void MovePlayer()
    // {

    //     if (Input.GetAxisRaw("Horizontal") > 0f)
    //     {

    //         Vector3 temp = transform.position;
    //         temp.x += speed * Time.deltaTime;

    //         if (temp.x > max_X)
    //         {
    //             temp.x = max_X;
    //         }

    //         transform.position = temp;

    //     }
    //     else if (Input.GetAxisRaw("Horizontal") < 0f)
    //     {

    //         Vector3 temp = transform.position;
    //         temp.x -= speed * Time.deltaTime;

    //         if (temp.x < min_X)
    //         {
    //             temp.x = min_X;
    //         }

    //         transform.position = temp;

    //     }

    // }



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
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;


// namespace BattleOfMidWay
// {
//     public class EnemyController : MonoBehaviour
//     {
//         public static EnemyController instance;
//         public bool canRotate = false;
//         public Sprite[] sprites;
//         private SpriteRenderer asteroidSprite;
//         private NavMeshAgent navMeshAgent;
//         public PlayerView playerView;
//         public int health = 30;
//         public float enemySpeed = 3f;
//         private float MaxDownPos = -15.0f;

//         void Awake()
//         {
//             instance = this;
//             asteroidSprite = gameObject.GetComponent<SpriteRenderer>();
//         }

//         void Start()
//         {
//             // health = 30;
//             // enemySpeed = 3f;
//             if (canRotate)
//             {
//                 asteroidSprite.sprite = sprites[Random.Range(0, sprites.Length)];
//                 transform.eulerAngles = new Vector3(0f, 0f, Random.Range(1f, 2f) * 360);
//             }
//         }


//         void Update()
//         {
//             Move();
//             DestroyingIteself();
//         }


//         void Move()
//         {
//             Vector3 temp = transform.position;
//             temp.y -= enemySpeed * Time.deltaTime;
//             transform.position = temp;

//         }


//         private void DestroyingIteself()
//         {
//             if (this.gameObject.transform.position.y < MaxDownPos)
//             {
//                 Destroy(this.gameObject);
//             }
//         }
//     }
// }
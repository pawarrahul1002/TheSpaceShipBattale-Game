using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    /*bulletview : this is monobeahaviour class attached to bullet prefab*/
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }
        public float m_MaxLifeTime = 1f;
        public GameObject explsionAnim;

        //SetBulletController :  use for setting bulletcontroller instance
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }


        void Start()
        {
            // If it isn't destroyed by obstacles then, destroying after it's lifetime.
            Destroy(gameObject, m_MaxLifeTime);
        }

        /*in Fixed update movemnt of bullet is running by the instance of bullet controller,
         bullet movement function in the bullet controller*/
        private void FixedUpdate()
        {
            bulletController.Movement();
        }


        /*OnTriggerEnter2D : this is checking for collision of bullet with enemy, player, and asteroids
            we set ontrigger checked of box collider to use this fun*/
        void OnTriggerEnter2D(Collider2D other)
        {
            if ((bulletController.bulletModel.bulletType == BulletType.Enemy) && other.gameObject.GetComponent<PlayerView>() != null)
            {
                PlayerService.instance.GetPlayerController().ApplyDamage(10);
            }
            else if ((bulletController.bulletModel.bulletType == BulletType.player) && (other.CompareTag("Enemy")))
            {

                SoundManager.Instance.Play(Sounds.Explosion);
                ScoreController.instance.IncreaseScore();
                ScoreController.instance.EnemyDamage(10, other.gameObject);
            }
            else if ((bulletController.bulletModel.bulletType == BulletType.player) && (other.CompareTag("Asteroid")))
            {
                SoundManager.Instance.Play(Sounds.Explosion);
                ScoreController.instance.IncreaseScore();
                Destroy(other.gameObject);
            }

            DestroyBullets();

        }


        //bullet is destroying itself 
        private void DestroyBullets()
        {
            Destroy(gameObject);
        }

    }

}





















//  [SerializeField] private float speed = 10f;
//     [SerializeField] private float m_MaxLifeTime = 3f;
//     [HideInInspector] public bool isEnemyBullet = false;

//     void Start()
//     {
//         Destroy(gameObject, m_MaxLifeTime);
//         // if (isEnemyBullet)
//         // {
//         //     speed *= -1f;
//         // }
//         // Invoke("DeactivateGameObject", m_MaxLifeTime);
//     }

//     void Update()
//     {
//         Move();
//     }

//     void Move()
//     {
//         Vector3 position = transform.position;
//         position.y += speed * Time.deltaTime;
//         transform.position = position;
//     }

//     void DeactivateGameObject()
//     {
//         gameObject.SetActive(false);
//     }

//     // private void OnCollisonEnter2D(Collision2D target)
//     // {
//     //     // if (
//     //     // if (target.gameObject.CompareTag("Bullet") || target.gameObject.CompareTag("Enemy"))
//     //     // {
//     //     //     gameObject.SetActive(false);
//     //     // }
//     //     // if (target.tag == "Bullet" || target.tag == "Enemy")
//     //     // {
//     //     gameObject.SetActive(false);
//     //     // }
//     // }
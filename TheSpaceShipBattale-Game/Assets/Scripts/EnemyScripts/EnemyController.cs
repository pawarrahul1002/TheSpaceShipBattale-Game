using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace BattleOfMidWay
{
    /*EnemyMovement : this will controll the movement of enemies and diffrent objects like
                        asteroid black and while , boss enemy for now*/
    public class EnemyController : MonoBehaviour
    {

        public static EnemyController instance;
        [SerializeField] private bool canRotate = false;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float enemySpeed;
        private SpriteRenderer asteroidSprite;
        private float MaxDownPos = -15.0f;

        private void Awake()
        {
            instance = this;
            asteroidSprite = gameObject.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InitalizeEnemyMovement();
        }

        /*InitalizeEnemyMovement :  this will intialize enemy health, speed also control if asteroid is rotating or not*/
        private void InitalizeEnemyMovement()
        {
            enemySpeed = 3f;
            if (canRotate)
            {
                asteroidSprite.sprite = sprites[Random.Range(0, sprites.Length)];
                transform.eulerAngles = new Vector3(0f, 0f, Random.Range(1f, 2f) * 360);
            }

        }

        private void Update()
        {
            Move();
            DestroyingIteself();
        }

        /*Move :  this is for movement in downword direction*/
        private void Move()
        {
            Vector3 temp = transform.position;
            temp.y -= enemySpeed * Time.deltaTime;
            transform.position = temp;
        }


        /*DestroyingIteself :  enemies and objects are destroying themself after max down position*/

        private void DestroyingIteself()
        {
            if (this.gameObject.transform.position.y < MaxDownPos)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
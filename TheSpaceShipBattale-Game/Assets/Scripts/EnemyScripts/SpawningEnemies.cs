using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{
    /*SpawningEnemies : used to instatiate enemies , asterois , boss enemy and spwan them at different position after 
                            specific timimg*/
    public class SpawningEnemies : MonoBehaviour
    {
        public GameObject[] spwanObjects;
        [SerializeField] public Transform spawnPos;
        [SerializeField] float timeToComeBossEnemy = 10;
        private int enemySpawnBforHealth;
        private float timeSpend = 0;
        private bool spawnBoss = false;
        private Vector3 SpawnPos;
        private float timer = 1.5f;

        private float min_XPos = -3f;
        private float max_XPos = 3f;

        enum SpawnObjects
        {
            EnemyPrefab,
            Asteroid_Prefabs,
            PowerUpHealth,
            BossEnemy
        }


        IEnumerator Start()
        {
            enemySpawnBforHealth = 0;
            IntitlizedEnemySpwnPos();
            yield return new WaitForSeconds(3f);
            StartCoroutine(SpawnEnemies());
        }


        //iniatilizing spawning position using IntitlizedEnemySpwnPos function
        void IntitlizedEnemySpwnPos()
        {
            SpawnPos = spawnPos.position;
        }

        void Update()
        {
            BossTimer();
        }

        //BossTimer : boss will instatintate after this timer
        private void BossTimer()
        {
            timeSpend += Time.deltaTime;
            if (timeSpend == timeToComeBossEnemy)
            {
                spawnBoss = true;
            }
        }


        /*SpawnEnemies : this is main fun for spawning different enemies, asteroids,boss enemy
                    and health power up , first some of the enemies are gonna come and then power will appear*/

        IEnumerator SpawnEnemies()
        {
            if (spawnBoss)
            {

                Instantiate(spwanObjects[(int)SpawnObjects.BossEnemy], SpawnPos, Quaternion.identity);
            }
            else
            {
                float pos_X = Random.Range(min_XPos, max_XPos);
                SpawnPos.x = pos_X;
                int num = Random.Range(0, 3);
                Debug.Log(num);

                if (num == 2 && (enemySpawnBforHealth <= 2))
                {
                    num = Random.Range(0, 2);
                }

                if (num == 0)
                {
                    Instantiate(spwanObjects[(int)SpawnObjects.Asteroid_Prefabs], SpawnPos, Quaternion.identity);
                }
                else if (num == 1)
                {
                    Instantiate(spwanObjects[(int)SpawnObjects.EnemyPrefab], SpawnPos, Quaternion.Euler(0f, 0f, 180f));
                    enemySpawnBforHealth++;
                }
                else if (num == 2)
                {
                    Instantiate(spwanObjects[(int)SpawnObjects.PowerUpHealth], SpawnPos, Quaternion.identity);
                    enemySpawnBforHealth = 0;
                }

                yield return new WaitForSeconds(timer);
                StartCoroutine(SpawnEnemies());
            }
        }

    } // class



}

































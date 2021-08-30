using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace BattleOfMidWay
{
    /*
     ScoreController :  use to controll score also ui of game and 
                         also controll gamover panel by getting instance from unity editor
    */
    public class ScoreController : MonoBehaviour
    {

        public static ScoreController instance;
        public GameObject explosionAnim;
        private Animator animator;

        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI playerHealthText;
        public TextMeshProUGUI finalScoreText;
        public TextMeshProUGUI enemyKilledText;
        private int playerScore;
        public GameObject gameOverPanel;

        private int enemyHealth = 30;
        private int enemyKilled = 0;

        void Awake()
        {
            animator = GetComponent<Animator>();
            instance = this;
        }

        void Start()
        {
            this.gameObject.SetActive(true);
            InitializeUI();
        }

        //InitializeUI :  intializing UI values
        void InitializeUI()
        {
            enemyKilled = 0;
            playerScore = 0;
            scoreText.text = "Score : " + playerScore.ToString();
            enemyKilledText.text = "Enemy Killed : " + enemyKilled.ToString();
            UpdateHealthText(PlayerService.instance.GetPlayerController().playerModel.health);
        }

        //IncreaseScore :  this is used to called when player toches collectible
        public void IncreaseScore()
        {
            playerScore += 5;
            scoreText.text = "Score : " + playerScore.ToString();
        }

        //EnemyDamage :  called when bullet collides with enemy
        public void EnemyDamage(int damage, GameObject prefab)
        {
            if (enemyHealth < 0)
            {
                enemyKilled++;
                enemyKilledText.text = "Enemy Killed : " + enemyKilled.ToString();
                Destroy(prefab);
                PlayExplosionAnim(prefab.transform.position);
                return;
            }
            else
            {
                enemyHealth -= damage;
            }
        }


        //for getting enemy destroy effect we play animation
        void PlayExplosionAnim(Vector3 explosionPos)
        {
            GameObject explosion = Instantiate(explosionAnim, explosionPos, Quaternion.identity);
            Animator anim = explosion.GetComponent<Animator>();
            anim.SetBool("startExplosion", true);
            Destroy(explosion, 0.7f);
        }


        //UpdateHealthText :  upading health text in the UI with help of this
        public void UpdateHealthText(int health)
        {
            playerHealthText.text = "Health : " + health.ToString();
        }

        //ActiveGameOverPanel :  this is called when player dies
        public void ActiveGameOverPanel()
        {
            Time.timeScale = 0f;
            SoundManager.Instance.Play(Sounds.GameOver);
            gameOverPanel.SetActive(true);
            FinalText();
        }

        //FinalText :  this is final text when game over panel opens
        private void FinalText()
        {
            finalScoreText.text = "Your Score : " + playerScore.ToString() + "\n"
                                    + "Enemies Killed : " + enemyKilled.ToString();

        }


    }
}
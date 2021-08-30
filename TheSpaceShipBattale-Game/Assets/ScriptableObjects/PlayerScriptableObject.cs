using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{

    /*PlayerScriptableObject : this contains all data related to player 
        also we can creat any type of player in minimum time and change begaviour */

    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/NewPlayer")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public PlayerView playerView;
        public float speed;
        public int health;
        public float fireRate;

    }
}
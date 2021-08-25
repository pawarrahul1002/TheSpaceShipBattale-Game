using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/NewPlayer")]
public class PlayerScriptableObject : ScriptableObject
{
    public PlayerView playerView;
    public float speed;
    public float health;
    public float fireRate;

}

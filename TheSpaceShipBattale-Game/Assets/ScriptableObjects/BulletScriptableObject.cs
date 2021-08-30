using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfMidWay
{
    /*BulletScriptableObject : this contains all data related to bullet 
        also we can creat any type of bullet in minimum time */

    [CreateAssetMenu(fileName = "BulletScriptableObjects", menuName = "ScriptableObject/NewBullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        [Header("MVC Essentials")]
        public BulletView bulletView;

        [Header("Behaviour Variables")]
        public BulletType bulletType;
        public float bulletForce;
        public float bulletDamage;
    }

}

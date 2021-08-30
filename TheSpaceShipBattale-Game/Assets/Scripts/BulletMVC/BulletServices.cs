using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BattleOfMidWay
{

    /*BulletServices : this class is MonoSingletonGenericand deals with with services*/
    public class BulletServices : MonoSingletonGeneric<BulletServices>
    {
        public void CreateBullet(Transform[] transforms, Quaternion rotation, BulletScriptableObject type)
        {
            BulletScriptableObject bullet = type;
            BulletModel bulletModel = new BulletModel(bullet);
            for (int i = 0; i < transforms.Length; i++)
            {
                BulletController bulletController = new BulletController(bullet.bulletView, bulletModel, transforms[i].position, rotation);
            }
        }
    }
}
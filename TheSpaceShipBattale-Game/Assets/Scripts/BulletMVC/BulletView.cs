using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public BulletController bulletController { get; private set; }
    public ParticleSystem BullectDestroyVFX;
    public GameObject audioSource;
    public float m_MaxLifeTime = 1f;
    public Vector3 dir;
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }

    void Start()
    {
        Debug.Log(transform.localRotation);
        dir = (transform.localRotation * Vector2.up);//.normalized
        Debug.Log(transform.localRotation);
        // audioSource.transform.parent = null;
        // Destroy(audioSource, 0.5f);
        // If it isn't destroyed by obstacles then, destroying after it's lifetime.
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void FixedUpdate()
    {
        bulletController.Movement(dir);
    }

    void OnCollisionEnter(Collision other)
    {

        // if ((bulletController.bulletModel.type == BulletTypes.EnemyBullet) && other.gameObject.GetComponent<TankView>() != null)
        // {
        //     // TankService.GetInstance().GetTankController().ApplyDamage(bulletController.bulletModel.damage);
        // }
        // else if ((bulletController.bulletModel.type != BulletTypes.EnemyBullet) && other.gameObject.GetComponent<EnemyView>() != null)
        // {

        //     // other.gameObject.GetComponent<EnemyView>().enemyController.ApplyDamage(bulletController.bulletModel.damage);
        // }

        DestroyBullets();

    }

    private void DestroyBullets()
    {
        // BullectDestroyVFX.transform.parent = null;
        // BullectDestroyVFX.Play();
        // Destroy(BullectDestroyVFX.gameObject, BullectDestroyVFX.main.duration);
        Destroy(gameObject);
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
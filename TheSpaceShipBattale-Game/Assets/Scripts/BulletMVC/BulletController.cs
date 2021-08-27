using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletView bulletView { get; private set; }
    public BulletModel bulletModel { get; private set; }
    private Rigidbody2D rigidbody2d;
    public BulletController(BulletView _bulletView, BulletModel _bulletModel, Vector3 position, Quaternion rotation)
    {
        this.bulletModel = _bulletModel;
        this.bulletView = GameObject.Instantiate<BulletView>(_bulletView, position, Quaternion.Euler(0f, 0f, 90f));
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
        this.rigidbody2d = bulletView.GetComponent<Rigidbody2D>();
    }

    // public void Movement()
    // {
    //     rigidbody2d.AddForce(bulletView.transform.up * bulletModel.bulletForce, ForceMode2D.Impulse);

    //     // Vector3 move = bulletView.transform.transform.position;
    //     // move += bulletView.transform.forward * bulletModel.bulletForce * Time.fixedDeltaTime;

    //     // rigidbody2d.MovePosition(move);
    // }

    // public void Movement(Vector3 dir)
    // {
    //     Vector3 position = bulletView.transform.position;
    //     position.y += bulletModel.bulletForce * Time.deltaTime;
    //     bulletView.transform.position = position;
    // }
    public void Movement(Vector3 dir)
    {
        // dir = new Vector3(0f, 0f, 1f, 1f);
        Vector3 bulletPos = bulletView.transform.position;

        bulletPos += dir * bulletModel.bulletForce * Time.deltaTime;
        // Vector3 position = bulletView.transform.position;
        bulletView.transform.position = new Vector2(bulletPos.x, bulletPos.y);
        // bulletView.transform.position = position;
    }




}

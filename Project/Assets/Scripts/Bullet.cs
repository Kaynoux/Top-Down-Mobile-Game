using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using CodeMonkey.Utils;

public class Bullet : MonoBehaviour
{
    private Vector3 aimDirection;
    private float bulletSpeed;
    private float bulletDamage;
    private Transform bulletOwner;
    public void Setup(Vector3 aimDirection, float bulletSpeed, float bulletDamage, Transform bulletOwner)
    {
        this.aimDirection = aimDirection;
        this.bulletSpeed = bulletSpeed;
        this.bulletDamage = bulletDamage;
        this.bulletOwner = bulletOwner;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(aimDirection));
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        //Debug.Log("Try MOvig" + bulletSpeed);
        transform.position += aimDirection.normalized * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Target target = collider.gameObject.GetComponent<Target>();
        if(target != null && collider.gameObject.transform != bulletOwner )
        {
            target.Damage(bulletDamage);
            Destroy(gameObject);
            
        }
    }
}

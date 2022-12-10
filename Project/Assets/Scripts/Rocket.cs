using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using CodeMonkey.Utils;

public class Rocket: MonoBehaviour
{
    private Vector3 aimDirection;
    private float bulletSpeed;
    private float bulletDamage;
    private Transform bulletOwner;
    private float splashRadius;
    public void Setup(Vector3 aimDirection, float bulletSpeed, float bulletDamage, float splashRadius, Transform bulletOwner)
    {
        this.aimDirection = aimDirection;
        this.bulletSpeed = bulletSpeed;
        this.bulletDamage = bulletDamage;
        this.bulletOwner = bulletOwner;
        this.splashRadius = splashRadius;
        transform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(aimDirection));
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        //Debug.Log("Try MOvig" + bulletSpeed);
        transform.position += aimDirection.normalized * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("wefewfew");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRadius);

        if (collider.transform == bulletOwner)
        {
            return;
        }
        foreach (Collider2D hitCollider in hitColliders)
        {
            Target target = hitCollider.GetComponent<Target>();

            if (target != null && hitCollider.transform != bulletOwner )
            {
                var closestPoint = hitCollider.ClosestPoint(transform.position);
                var distance = Vector3.Distance(closestPoint, transform.position);
                var damagePercent = Mathf.InverseLerp(splashRadius, 0, distance);
                //linerar damage Dropoff in damage circle

                if (GlobalStats.instance.Critical >= Random.Range(0, 100))
                {
                    target.Damage(2 * bulletDamage * damagePercent, true);
                }
                else
                {
                    target.Damage(bulletDamage * damagePercent, false);
                }
            }
        }
        Destroy(gameObject);

        /*Target target = collider.gameObject.GetComponent<Target>();
        if (target != null && collider.gameObject.transform != bulletOwner)
        {
            target.Damage(bulletDamage);
            Destroy(gameObject);

        }*/
    }
}

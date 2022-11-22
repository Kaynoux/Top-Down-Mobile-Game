using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerShootProjectiles : MonoBehaviour
{
   public WeaponManager weaponManager;


    private void Start()
    {
        weaponManager.OnShoot += WeaponManager_OnShoot;
            
    }

    private void WeaponManager_OnShoot(object sender, WeaponManager.OnShootEventArgs e)
    {
        //UtilsClass.ShakeCamera(1f, .2f);
        Transform bulletTransform = Instantiate(e.bulletPrefab, e.gunEndPointPosition, Quaternion.identity);
        //Vector3 shootDir = (Quaternion.AngleAxis(e.angle * Mathf.Rad2Deg, Vector3.forward) * Vector3.right).normalized;
        //Debug.Log(e.angle + " " + shootDir);
        if (e.bulletType == 0) bulletTransform.GetComponent<Bullet>().Setup(e.aimDirection, e.bulletSpeed, e.bulletDamage, e.bulletOwner);
        else if (e.bulletType == 1) bulletTransform.GetComponent<Rocket>().Setup(e.aimDirection, e.bulletSpeed, e.bulletDamage, e.splashRadius, e.bulletOwner);

    }
}

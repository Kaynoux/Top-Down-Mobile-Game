using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "ScriptableObjects/WeaponSO")]
public class WeaponDataSO : ScriptableObject
{

    public string weaponName;
    public Transform weaponPrefab;
    public Transform bulletPrefab;
    public Vector3 gunEndPoint;
    public float bulletDamage;
    public float fireRate;
    public float bulletSpeed;
    public float reloadTime;
    public float splashRadius;
    public int magSize;
    public int bulletType;



}

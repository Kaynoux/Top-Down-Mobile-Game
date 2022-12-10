using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Linq;
using Unity.VisualScripting;
using CodeMonkey.Utils;

public class WeaponManager : MonoBehaviour
{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Transform bulletOwner;
        public Transform bulletPrefab;
        public Vector3 gunEndPointPosition;
        public Vector3 aimDirection;
        public float bulletSpeed;
        public float bulletDamage;
        public float splashRadius;
        public int bulletType;

        
        
    }
    public bool keyboardInput = false;
    public bool joystickInput = true;

    public int currentWeaponIndex;
    public int startWeapon;
    public List<WeaponDataSO> weaponsList;
    public Joystick joystickAim;
    public Transform weaponArm;
    public Slider reloadSlider;
    private List<float> reloadSliderValue;
    public Image reloadSliderImage;
    public Transform rotator;
    public Transform emptyPrefab;

    private float verticalAim;
    private float horizontalAim;
    private float angle;

    private float splashRadius;
    private int currentBulletType;
    private Transform currentWeaponTransform;
    private Transform currentEndPoint;
    private Animator currentAnimator;
    private Vector3 aimDirection;
    private float currentCooldown;
    private bool isReloading;

    private List<int> currentMagSizeList;
    

    private string weaponName;
    private Transform weaponPrefab;
    private Transform bulletPrefab;
    private float bulletDamage;
    private float fireRate;
    private float bulletSpeed;
    private float reloadTime;
    private int magSize;


    private void Start()
    {
        reloadSliderValue = new List<float>();
        currentMagSizeList = new List<int>();


        
        for (int i = 0; i < weaponsList.Count; i++)
        {
            currentMagSizeList.Add(weaponsList[i].magSize); 
            reloadSliderValue.Add(weaponsList[i].reloadTime);
            
        }
        

        SelectWeapon(startWeapon);
        reloadSlider.maxValue = magSize;
        reloadSlider.value = currentMagSizeList[currentWeaponIndex];
        weaponArm.eulerAngles = new Vector3(0, 0, 0);
    }


    private void Update()
    {
        
        HandleShooting();
        //Debug.Log(bulletSpeed);
        if(isReloading == true)
        {
            reloadSlider.value = reloadSliderValue[currentWeaponIndex] - Time.deltaTime;
            reloadSliderValue[currentWeaponIndex] -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(0);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(1);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectWeapon(2);
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (keyboardInput == true)
            {
                keyboardInput = false;
                joystickInput = true;
                joystickAim.gameObject.SetActive(true);
            }

            else 
            {
                keyboardInput = true;
                joystickInput = false;
                joystickAim.gameObject.SetActive(false);
            }
        }
        







    }

    private void SelectWeapon(int weaponIndex)
    {


        if (currentWeaponTransform != null)
        {
            Destroy(currentWeaponTransform.gameObject);
            Destroy(currentEndPoint.gameObject);
        }
        currentWeaponIndex = weaponIndex;

        weaponName = weaponsList[currentWeaponIndex].weaponName;
        weaponPrefab = weaponsList[currentWeaponIndex].weaponPrefab;
        bulletPrefab = weaponsList[currentWeaponIndex].bulletPrefab;
        bulletDamage = weaponsList[currentWeaponIndex].bulletDamage;
        fireRate = weaponsList[currentWeaponIndex].fireRate; //* (GlobalStats.instance.Skill / 100);
        bulletSpeed = weaponsList[currentWeaponIndex].bulletSpeed;
        magSize = weaponsList[currentWeaponIndex].magSize;
        reloadTime = weaponsList[currentWeaponIndex].reloadTime;
        currentBulletType = weaponsList[currentWeaponIndex].bulletType;
        splashRadius = weaponsList[currentWeaponIndex].splashRadius;
        currentWeaponTransform = Instantiate(weaponPrefab, weaponArm);
        currentEndPoint = Instantiate(emptyPrefab, weaponArm);
        currentEndPoint.localPosition = weaponsList[currentWeaponIndex].gunEndPoint;
        
        
        currentEndPoint.parent = weaponArm;
        
        currentAnimator = currentWeaponTransform.GetComponent<Animator>();
        
        

        if (isReloading)
        {
            StopCoroutine(Reload());
            isReloading = false;
            reloadSlider.maxValue = magSize;
            reloadSlider.value = currentMagSizeList[weaponIndex];
            reloadSliderImage.color = Color.blue;
            
        }
        else
        {
            reloadSlider.maxValue = magSize;
            reloadSlider.value = currentMagSizeList[weaponIndex];
        }

    }

    private void HandleAiming()
    {
        if (joystickAim.Horizontal != 0 || joystickAim.Vertical != 0 && joystickInput == true)
        {
            aimDirection = new Vector3(joystickAim.Horizontal, joystickAim.Vertical);
            horizontalAim = joystickAim.Horizontal;
            verticalAim = joystickAim.Vertical;
        }
        else if (keyboardInput == true)
        {
            aimDirection = UtilsClass.GetMouseWorldPosition() - currentEndPoint.position;
            horizontalAim = aimDirection.normalized.x;
            verticalAim = aimDirection.normalized.y;
        }
        //Debug.Log(horizontalAim + " " + verticalAim);

        

        angle = -(Mathf.Atan2(horizontalAim, verticalAim) * Mathf.Rad2Deg) + 90;


        //weaponArm.eulerAngles = new Vector3(0, 0, angle);
        if (horizontalAim < 0)
        {
            //Debug.Log("1");
            weaponArm.eulerAngles = new Vector3(-180, 0, -angle);
            rotator.localEulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            //Debug.Log("2");
            weaponArm.eulerAngles = new Vector3(0, 0, angle);
            rotator.localEulerAngles = new Vector3(0, 0, 0);
            //weaponArm.eulerAngles = new Vector3(0, 0, angle);
        }

        




    }

    private void HandleAutoAiming()
    {

        var closestEnemy = GetClosestEnemy();

        if (closestEnemy == null)
        {
            return;
        }

        aimDirection = closestEnemy.position - currentEndPoint.position;
        angle = -(Mathf.Atan2(aimDirection.normalized.x, aimDirection.normalized.y) * Mathf.Rad2Deg) + 90;

        if (aimDirection.normalized.x < 0)
        {
            //Debug.Log("1");
            weaponArm.eulerAngles = new Vector3(-180, 0, -angle);
            rotator.localEulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            //Debug.Log("2");
            weaponArm.eulerAngles = new Vector3(0, 0, angle);
            rotator.localEulerAngles = new Vector3(0, 0, 0);
            //weaponArm.eulerAngles = new Vector3(0, 0, angle);
        }

    }

    private Transform GetClosestEnemy()
    {
        var enemies = MainSpawner.instance.enemys;
        if (enemies.Count == 0)
        {
            return null;
        }
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    private void HandleShooting()
    {
        if(isReloading)
        {
            return;
        }

        if (currentMagSizeList[currentWeaponIndex] <= 0 && magSize != 0)
        {
            
            StartCoroutine(Reload());
            
            return;
        }

        else if (currentCooldown <= 0)
        {
            /*if ((joystickAim.Horizontal > 0.35 || joystickAim.Vertical > 0.35 || joystickAim.Horizontal < -0.35 || joystickAim.Vertical < -0.35 && joystickInput == true ) || (keyboardInput == true && Input.GetMouseButton(0)))
            {
                OnShoot?.Invoke(this, new OnShootEventArgs
                {
                    gunEndPointPosition = currentEndPoint.position,
                    aimDirection = aimDirection,
                    bulletPrefab = bulletPrefab,
                    bulletSpeed = bulletSpeed,
                    bulletDamage = bulletDamage,
                    bulletOwner = transform,
                    bulletType = currentBulletType,
                    splashRadius = splashRadius,

                }); ;
                currentCooldown = 1 / (fireRate / 60);
                currentMagSizeList[currentWeaponIndex] --;
                reloadSlider.value--;
                currentAnimator.SetTrigger("Shoot");
            }*/

            HandleAutoAiming();

            var damage = (bulletDamage * GlobalStats.instance.Attack * 0.01f) * (1 + (GlobalStats.instance.Strength * 0.01f));


            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = currentEndPoint.position,
                aimDirection = aimDirection,
                bulletPrefab = bulletPrefab,
                bulletSpeed = bulletSpeed,
                bulletDamage = damage,
                bulletOwner = transform,
                bulletType = currentBulletType,
                splashRadius = splashRadius,

            }); ;
            currentCooldown = 1 / (fireRate / 60);
            if (magSize != 0)
            {
                currentMagSizeList[currentWeaponIndex]--;
                reloadSlider.value--;
            }
           
            currentAnimator.SetTrigger("Shoot");

        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
        //Debug.Log(currentCooldown);
       

    }

    IEnumerator Reload()
    {
        isReloading = true;
        
        reloadSlider.maxValue = reloadTime;
        reloadSliderValue[currentWeaponIndex] = reloadTime;
        reloadSlider.value = reloadSliderValue[currentWeaponIndex];
        reloadSliderImage.color = Color.yellow;
        yield return new WaitForSeconds(reloadTime);
        currentMagSizeList[currentWeaponIndex] = magSize;
        reloadSlider.maxValue = magSize;
        reloadSliderImage.color = Color.blue;
        reloadSlider.value = currentMagSizeList[currentWeaponIndex];
        isReloading = false;

        
    }

    

}

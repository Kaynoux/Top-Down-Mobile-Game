using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTarget : MonoBehaviour
{
    
    public float topSpeed;
    public float accelSpeed;
    public float deccelRate;
    public float velPower;
    public Rigidbody2D rb;
    public float minDistanceToPlayer;
    public float maxDistanceToAttack;
    public float attackForce;
    public float damage;
    public float attackCooldown;
    public Transform sprite;

    private float currentAttackCooldown;
    private float beginX;
    private float beginY;
    private float speedDifX;
    private float speedDifY;
    private float accelRateX;
    private float accelRateY;
    private float moveX;
    private float moveY;

    private Transform player;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    private void FixedUpdate()
    {
        Vector3 direction = (player.position - transform.position).normalized * topSpeed;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > minDistanceToPlayer)
        {
            
            //Debug.Log(beginX + " " + beginY);

            beginX = direction.x;
            beginY = direction.y;

            speedDifX = beginX - rb.velocity.x;
            speedDifY = beginY - rb.velocity.y;

            accelRateX = beginX != 0 ? accelSpeed : deccelRate;
            accelRateY = beginY != 0 ? accelSpeed : deccelRate;

            moveX = Mathf.Pow(Mathf.Abs(speedDifX) * accelRateX, velPower) * Mathf.Sign(speedDifX);
            moveY = Mathf.Pow(Mathf.Abs(speedDifY) * accelRateY, velPower) * Mathf.Sign(speedDifY);

            //Debug.Log("X: " + beginX + " " + speedDifX + " " + accelRateX + " " + moveX + "Y: " + beginY + " " + speedDifY + " " + accelRateY + " " + moveY);

            rb.AddForce(new Vector2(moveX, moveY));
        }
        if (direction.x < 0)
        {
            //Debug.Log("1");
            sprite.localEulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            //Debug.Log("2");
            sprite.localEulerAngles = new Vector3(0, 0, 0);
            //weaponArm.eulerAngles = new Vector3(0, 0, angle);
        }
        currentAttackCooldown -= Time.deltaTime;

        if (distance < maxDistanceToAttack && currentAttackCooldown <= 0)
        {
            rb.AddForce(direction * attackForce);
            player.GetComponent<PlayerTarget>().Damage(damage);
            currentAttackCooldown = attackCooldown;

        }
        





    }
}

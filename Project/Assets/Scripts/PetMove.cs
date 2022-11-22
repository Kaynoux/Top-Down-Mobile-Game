using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    public float maxOffset;
    public float nearToWaypoint;
    public float maxSwitchCooldown;
    private float currentSwitchCooldown;

    private Transform player;
    //public List<Vector3> waypoints = new List<Vector3>();
    public Vector3 waypoint;

    public float topSpeed;
    public float accelSpeed;
    public float deccelRate;
    public float velPower;
    public Rigidbody2D rb;
    public Transform sprite;
    
    private float beginX;
    private float beginY;
    private float speedDifX;
    private float speedDifY;
    private float accelRateX;
    private float accelRateY;
    private float moveX;
    private float moveY;

    private Vector3 direction;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        MoveBetweenWaypoints();
    }

    private void FixedUpdate()
    {

        /*beginX = direction.x;
        beginY = direction.y;

        speedDifX = beginX - rb.velocity.x;
        speedDifY = beginY - rb.velocity.y;

        accelRateX = beginX != 0 ? accelSpeed : deccelRate;
        accelRateY = beginY != 0 ? accelSpeed : deccelRate;

        moveX = Mathf.Pow(Mathf.Abs(speedDifX) * accelRateX, velPower) * Mathf.Sign(speedDifX);
        moveY = Mathf.Pow(Mathf.Abs(speedDifY) * accelRateY, velPower) * Mathf.Sign(speedDifY);

        

        rb.AddForce(new Vector2(moveX, moveY));*/
        rb.AddForce(direction);
    }

    /*private void GetRandom()
    {
        for (int i = 0; i < 10; i++)
        {
            waypoints.Add(player.position + new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset)));
        }
       
                
    }*/

    private void MoveBetweenWaypoints()
    {
        if (currentSwitchCooldown <= 0)
        {
            waypoint = player.position + new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset));
            if (Vector3.Distance(player.position, transform.position) < 8)
            {
                direction = (waypoint - transform.position).normalized * topSpeed;
            }
            else
            {
                direction = (waypoint - transform.position).normalized * (topSpeed*3);
            }

            
            currentSwitchCooldown = maxSwitchCooldown;

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

        }


        else
        {
            currentSwitchCooldown -= Time.deltaTime;
        }

        
        

        



    }


}


    

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CharacterController2d : MonoBehaviour
{
    public bool keyboardInput = false;
    public bool joystickInput = true;
    public float dashForce;
    public float dashDuration;
    public float dashCooldown;
    public float topSpeed;
    public float accelSpeed;
    public float deccelRate;
    public float velPower;
    public Rigidbody2D rb;
    public Animator anim;
    public Joystick joystick;
    public Transform sprite;
    public bool disableHorMove;

    private Vector2 begin;
    private float beginX;
    private float beginY;
    private float speedDifX;
    private float speedDifY;
    private float accelRateX;
    private float accelRateY;
    private float moveX;
    private float moveY;
    

    private bool canDash = true;
    private bool isDashing;
    

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void Start()
    {
        inputManager.OnStartTouch += TryDash;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += TryDash;
    }

    

    private void OnDisable()
    {
        inputManager.OnEndTouch -= TryDash;
    }






    private void FixedUpdate()
    {
       
        //Debug.Log(beginX + " " + beginY);

        speedDifX = begin.x - rb.velocity.x;
        speedDifY = begin.y - rb.velocity.y;

        accelRateX = beginX != 0 ? accelSpeed : deccelRate;
        accelRateY = beginY != 0 ? accelSpeed : deccelRate;

        moveX = Mathf.Pow(Mathf.Abs(speedDifX) * accelRateX, velPower) * Mathf.Sign(speedDifX);
        moveY = Mathf.Pow(Mathf.Abs(speedDifY) * accelRateY, velPower) * Mathf.Sign(speedDifY);

        //Debug.Log("X: " + beginX + " " + speedDifX + " " + accelRateX + " " + moveX + "Y: " + beginY + " " + speedDifY + " " + accelRateY + " " + moveY);

        if(!disableHorMove)
        {
            
            rb.AddForce(new Vector2(moveX, moveY) * GlobalStats.instance.Speed / 100);

        }
        else
        {
            rb.AddForce(new Vector2(moveX, 0) * GlobalStats.instance.Speed / 100);
        }
       
        

        



    }

    private void Update()
    {
        if (joystickInput == true)
        {
            /*beginX = joystick.Horizontal * topSpeed;
            beginY = joystick.Vertical * topSpeed;

            if(beginX < 0 && beginY < 0)
            {
                beginX /= 2;
                beginY /= 2;
            }
            //Prevent diagnoal fast move*/
            begin = joystick.Direction.normalized * topSpeed;
        }

        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                begin.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                begin.y = -1;
            }
            else
            {
                begin.y = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                begin.x = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                begin.x = -1;
            }
            else
            {
                begin.x = 0;
            }

            begin = begin.normalized * topSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (keyboardInput == true)
            {
                keyboardInput = false;
                joystickInput = true;
                joystick.gameObject.SetActive(true);
            }

            else
            {
                keyboardInput = true;
                joystickInput = false;
                joystick.gameObject.SetActive(false);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            TryDash(new Vector2(Screen.width / 2 + 10, 0));
        }

       

    }

    public void TryDash(Vector2 pos)
    {
        Debug.Log("Try Dash");
        if ((pos.x > Screen.width / 2) && canDash)
        {
            StartCoroutine(Dash());
        }
        else
        {
            Debug.Log("DashFailed");
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        rb.AddForce(new Vector2(joystick.Horizontal * dashForce, joystick.Vertical * dashForce));
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    


}



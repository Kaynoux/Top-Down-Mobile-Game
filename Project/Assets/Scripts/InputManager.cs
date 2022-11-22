using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine.InputSystem;


[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    public delegate void StartTouchDelegate(Vector2 position);
    public event StartTouchDelegate OnStartTouch;

    public delegate void EndTouchDelegate(Vector2 position);
    public event EndTouchDelegate OnEndTouch;
    
    private PlayerControlls playerControlls;

    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            playerControlls = new PlayerControlls();
        }
       
    } 

  

    private void OnEnable()
    {
        playerControlls.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Disable(); 
    }

    private void Start()
    {
        playerControlls.Map.TapAction.started += ctx => StartTouch(ctx);
        playerControlls.Map.TapAction.canceled += ctx => EndTouch(ctx);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log(playerControlls.Map.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(playerControlls.Map.TouchPosition.ReadValue<Vector2>());
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        
    }


    
}

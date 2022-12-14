//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerControlls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControlls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControlls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControlls"",
    ""maps"": [
        {
            ""name"": ""Map"",
            ""id"": ""e5c704a9-bfbc-4eee-b57e-8a6114c85359"",
            ""actions"": [
                {
                    ""name"": ""TapAction"",
                    ""type"": ""Button"",
                    ""id"": ""5a33ce2b-1a1f-4516-bccf-7d706724e761"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""14e6b48e-9233-48e5-a158-0840f4782dd3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a682c801-5d16-4605-a66c-311c28c18851"",
                    ""path"": ""<Touchscreen>/touch1/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TapAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8736d33-634d-480f-a430-0df9464c7266"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Map
        m_Map = asset.FindActionMap("Map", throwIfNotFound: true);
        m_Map_TapAction = m_Map.FindAction("TapAction", throwIfNotFound: true);
        m_Map_TouchPosition = m_Map.FindAction("TouchPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Map
    private readonly InputActionMap m_Map;
    private IMapActions m_MapActionsCallbackInterface;
    private readonly InputAction m_Map_TapAction;
    private readonly InputAction m_Map_TouchPosition;
    public struct MapActions
    {
        private @PlayerControlls m_Wrapper;
        public MapActions(@PlayerControlls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TapAction => m_Wrapper.m_Map_TapAction;
        public InputAction @TouchPosition => m_Wrapper.m_Map_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Map; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapActions set) { return set.Get(); }
        public void SetCallbacks(IMapActions instance)
        {
            if (m_Wrapper.m_MapActionsCallbackInterface != null)
            {
                @TapAction.started -= m_Wrapper.m_MapActionsCallbackInterface.OnTapAction;
                @TapAction.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnTapAction;
                @TapAction.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnTapAction;
                @TouchPosition.started -= m_Wrapper.m_MapActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_MapActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_MapActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_MapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TapAction.started += instance.OnTapAction;
                @TapAction.performed += instance.OnTapAction;
                @TapAction.canceled += instance.OnTapAction;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public MapActions @Map => new MapActions(this);
    public interface IMapActions
    {
        void OnTapAction(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSyStem/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""MouseControl"",
            ""id"": ""9f601862-4de4-4030-af5f-ad8f4daad9a9"",
            ""actions"": [
                {
                    ""name"": ""ButtonLeft"",
                    ""type"": ""Button"",
                    ""id"": ""a7b1cde8-cc72-4836-9463-3bc3817ed588"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveMouse"",
                    ""type"": ""Value"",
                    ""id"": ""86d39a92-db92-4aa5-bdd1-125c437795bb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ee76d63-83ec-4835-a6bb-f94e18715501"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ButtonLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e265163-7290-4510-8064-da4119336758"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": []
        }
    ]
}");
        // MouseControl
        m_MouseControl = asset.FindActionMap("MouseControl", throwIfNotFound: true);
        m_MouseControl_ButtonLeft = m_MouseControl.FindAction("ButtonLeft", throwIfNotFound: true);
        m_MouseControl_MoveMouse = m_MouseControl.FindAction("MoveMouse", throwIfNotFound: true);
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

    // MouseControl
    private readonly InputActionMap m_MouseControl;
    private IMouseControlActions m_MouseControlActionsCallbackInterface;
    private readonly InputAction m_MouseControl_ButtonLeft;
    private readonly InputAction m_MouseControl_MoveMouse;
    public struct MouseControlActions
    {
        private @Controls m_Wrapper;
        public MouseControlActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ButtonLeft => m_Wrapper.m_MouseControl_ButtonLeft;
        public InputAction @MoveMouse => m_Wrapper.m_MouseControl_MoveMouse;
        public InputActionMap Get() { return m_Wrapper.m_MouseControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseControlActions set) { return set.Get(); }
        public void SetCallbacks(IMouseControlActions instance)
        {
            if (m_Wrapper.m_MouseControlActionsCallbackInterface != null)
            {
                @ButtonLeft.started -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnButtonLeft;
                @ButtonLeft.performed -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnButtonLeft;
                @ButtonLeft.canceled -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnButtonLeft;
                @MoveMouse.started -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnMoveMouse;
                @MoveMouse.performed -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnMoveMouse;
                @MoveMouse.canceled -= m_Wrapper.m_MouseControlActionsCallbackInterface.OnMoveMouse;
            }
            m_Wrapper.m_MouseControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ButtonLeft.started += instance.OnButtonLeft;
                @ButtonLeft.performed += instance.OnButtonLeft;
                @ButtonLeft.canceled += instance.OnButtonLeft;
                @MoveMouse.started += instance.OnMoveMouse;
                @MoveMouse.performed += instance.OnMoveMouse;
                @MoveMouse.canceled += instance.OnMoveMouse;
            }
        }
    }
    public MouseControlActions @MouseControl => new MouseControlActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IMouseControlActions
    {
        void OnButtonLeft(InputAction.CallbackContext context);
        void OnMoveMouse(InputAction.CallbackContext context);
    }
}

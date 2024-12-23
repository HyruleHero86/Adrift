//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/GamepadInputActions.inputactions
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

public partial class @GamepadInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamepadInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamepadInputActions"",
    ""maps"": [
        {
            ""name"": ""Gamepad"",
            ""id"": ""33b46e8d-7670-494d-a984-7d7a2a9efecf"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""02ccfc9c-d6e8-40de-b7eb-9aadb5e6afe4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""63561ceb-a02d-4cd5-8a69-18826c57de3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interaction"",
                    ""type"": ""Button"",
                    ""id"": ""cc971bf2-4ad7-40ca-baeb-f6bf869b9a20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c99fcb68-3c26-445a-9074-65a0a84e87d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""89cd20cb-76af-4adc-a488-29bacb8492e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropL"",
                    ""type"": ""Button"",
                    ""id"": ""e5910a44-fdb4-4d36-818b-6e16985fb1c5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DropR"",
                    ""type"": ""Button"",
                    ""id"": ""f5949e9c-7157-49d0-9a6a-ca5296c219d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2c4d9ac0-4105-4372-8aec-8727141ed718"",
                    ""path"": ""<HID:: USB Gamepad          >/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24d30cf3-f096-4199-aa10-ee7d8a9c0d65"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9eed546-b272-4bc9-ad7e-1c6ea4b31994"",
                    ""path"": ""<HID:: USB Gamepad          >/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interaction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f06c79bd-6162-4792-8513-ec957841e191"",
                    ""path"": ""<HID:: USB Gamepad          >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7e6e389-f210-44f4-bbf7-5e3f03e1865d"",
                    ""path"": ""<HID:: USB Gamepad          >/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9a6921c-3b7d-41e1-89ed-092ba2e8eb55"",
                    ""path"": ""<HID:: USB Gamepad          >/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropL"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4de20c42-5f9e-48d1-a6d4-5f6a206ae947"",
                    ""path"": ""<HID:: USB Gamepad          >/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropR"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gamepad
        m_Gamepad = asset.FindActionMap("Gamepad", throwIfNotFound: true);
        m_Gamepad_Move = m_Gamepad.FindAction("Move", throwIfNotFound: true);
        m_Gamepad_Look = m_Gamepad.FindAction("Look", throwIfNotFound: true);
        m_Gamepad_Interaction = m_Gamepad.FindAction("Interaction", throwIfNotFound: true);
        m_Gamepad_Jump = m_Gamepad.FindAction("Jump", throwIfNotFound: true);
        m_Gamepad_Sprint = m_Gamepad.FindAction("Sprint", throwIfNotFound: true);
        m_Gamepad_DropL = m_Gamepad.FindAction("DropL", throwIfNotFound: true);
        m_Gamepad_DropR = m_Gamepad.FindAction("DropR", throwIfNotFound: true);
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

    // Gamepad
    private readonly InputActionMap m_Gamepad;
    private List<IGamepadActions> m_GamepadActionsCallbackInterfaces = new List<IGamepadActions>();
    private readonly InputAction m_Gamepad_Move;
    private readonly InputAction m_Gamepad_Look;
    private readonly InputAction m_Gamepad_Interaction;
    private readonly InputAction m_Gamepad_Jump;
    private readonly InputAction m_Gamepad_Sprint;
    private readonly InputAction m_Gamepad_DropL;
    private readonly InputAction m_Gamepad_DropR;
    public struct GamepadActions
    {
        private @GamepadInputActions m_Wrapper;
        public GamepadActions(@GamepadInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gamepad_Move;
        public InputAction @Look => m_Wrapper.m_Gamepad_Look;
        public InputAction @Interaction => m_Wrapper.m_Gamepad_Interaction;
        public InputAction @Jump => m_Wrapper.m_Gamepad_Jump;
        public InputAction @Sprint => m_Wrapper.m_Gamepad_Sprint;
        public InputAction @DropL => m_Wrapper.m_Gamepad_DropL;
        public InputAction @DropR => m_Wrapper.m_Gamepad_DropR;
        public InputActionMap Get() { return m_Wrapper.m_Gamepad; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamepadActions set) { return set.Get(); }
        public void AddCallbacks(IGamepadActions instance)
        {
            if (instance == null || m_Wrapper.m_GamepadActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GamepadActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Interaction.started += instance.OnInteraction;
            @Interaction.performed += instance.OnInteraction;
            @Interaction.canceled += instance.OnInteraction;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @DropL.started += instance.OnDropL;
            @DropL.performed += instance.OnDropL;
            @DropL.canceled += instance.OnDropL;
            @DropR.started += instance.OnDropR;
            @DropR.performed += instance.OnDropR;
            @DropR.canceled += instance.OnDropR;
        }

        private void UnregisterCallbacks(IGamepadActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Interaction.started -= instance.OnInteraction;
            @Interaction.performed -= instance.OnInteraction;
            @Interaction.canceled -= instance.OnInteraction;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @DropL.started -= instance.OnDropL;
            @DropL.performed -= instance.OnDropL;
            @DropL.canceled -= instance.OnDropL;
            @DropR.started -= instance.OnDropR;
            @DropR.performed -= instance.OnDropR;
            @DropR.canceled -= instance.OnDropR;
        }

        public void RemoveCallbacks(IGamepadActions instance)
        {
            if (m_Wrapper.m_GamepadActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGamepadActions instance)
        {
            foreach (var item in m_Wrapper.m_GamepadActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GamepadActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GamepadActions @Gamepad => new GamepadActions(this);
    public interface IGamepadActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnInteraction(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnDropL(InputAction.CallbackContext context);
        void OnDropR(InputAction.CallbackContext context);
    }
}

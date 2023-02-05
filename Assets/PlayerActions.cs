//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/PlayerActions.inputactions
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

public partial class @PlayerActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerActions"",
    ""maps"": [
        {
            ""name"": ""Actions"",
            ""id"": ""e45dc6e0-a77d-4734-8730-0e1a672d4725"",
            ""actions"": [
                {
                    ""name"": ""OnJump"",
                    ""type"": ""Button"",
                    ""id"": ""2ead2b18-e797-4e38-9973-c87a43a6c909"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OnMove"",
                    ""type"": ""Value"",
                    ""id"": ""b5a102bb-bd2a-4043-8dad-1a7c1316807c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OnFire"",
                    ""type"": ""Button"",
                    ""id"": ""416dd99b-81b9-44b4-856a-05cc7b62afed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OnInteract"",
                    ""type"": ""Button"",
                    ""id"": ""f6ceb7f4-b0f4-46c1-9162-e7cfcde49387"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OnPause"",
                    ""type"": ""Button"",
                    ""id"": ""5e694497-d8d1-4a71-b901-8626f9bd7cd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OnSwitch"",
                    ""type"": ""Value"",
                    ""id"": ""69367f8a-c951-488e-9342-dbb41f05c805"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ff11cc1a-042a-4695-8aca-50900475ab13"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff896811-ccfd-4f78-84c6-aada848ebb92"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1402f759-c129-4d5a-8b7b-5b9785f95155"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb59606d-34d3-44bd-8840-1b77eb0865c7"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1d09ac33-2de2-4002-b918-82eddd795615"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""198ea295-35ae-4424-81ab-45c22c69fa85"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""8c37d20a-7b5b-4822-8da6-ce9ac02874ed"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""5eaccb65-b14d-46e2-84db-20ca19aea7f6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""5a346786-e506-4d3b-83c1-6edf2eb04fd8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""1311f67a-2559-4811-9f28-16a7b97ff347"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""59c79431-ee2b-47b0-b717-d5745fa16a8a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""0bcb4445-8fd2-4c2a-a358-57bf74d94bf2"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Up"",
                    ""id"": ""30ece228-e49e-4510-b038-d8610b6d77cf"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Down"",
                    ""id"": ""59ccae68-e8ef-4c2d-98a8-37f367ed745e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Left"",
                    ""id"": ""7bc42376-21d9-4eae-9902-c825ecc56ac8"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Right"",
                    ""id"": ""ead96620-aee8-44a5-b9e4-f444ab9d7604"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0ac6c889-4fb5-4969-bd38-44ff3f909809"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5966cc42-da9b-4a18-b9de-eb4b23aedb8b"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a3422377-3c6d-4f00-ae57-e1ef9a175e0e"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ed95a8f-2398-47e5-921c-1c06d636cfad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2732561e-d98a-42a6-a345-3913643ed92b"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnFire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59b78fc1-a6e6-4d23-a6b7-d95a9764f194"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8cc129e-9c88-4c7c-b6f5-5b59846e79b7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1baa318-0b6c-44ad-837d-47f30b1fb09c"",
                    ""path"": ""<XInputController>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5982b28b-ef87-44e0-b6a4-7e20f879d1a4"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47301100-dda2-46f6-9eed-fbc8d520859e"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1000544d-9959-4dfa-addf-ed808b196025"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de9d722c-7ebc-47b1-811d-95af10c7d8cf"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnPause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""427fbbbb-4738-484c-aeeb-417a4ab4e27e"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2bdb309-c32e-48d0-839b-395e96a96737"",
                    ""path"": ""<XInputController>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""286fb689-08cb-4fc7-b39e-448a6e950f58"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d3506c9a-3d53-4cb7-a34a-6bc8282d2327"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6eba5c63-4800-4ae9-895d-2ec127e2ed19"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""10da79dd-6ae1-4a46-9261-e855b90a395f"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c1dac2cc-3e8c-4c55-96a6-37832e970f14"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f58cfc81-c201-48ad-87c0-07411a4db8af"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnSwitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_OnJump = m_Actions.FindAction("OnJump", throwIfNotFound: true);
        m_Actions_OnMove = m_Actions.FindAction("OnMove", throwIfNotFound: true);
        m_Actions_OnFire = m_Actions.FindAction("OnFire", throwIfNotFound: true);
        m_Actions_OnInteract = m_Actions.FindAction("OnInteract", throwIfNotFound: true);
        m_Actions_OnPause = m_Actions.FindAction("OnPause", throwIfNotFound: true);
        m_Actions_OnSwitch = m_Actions.FindAction("OnSwitch", throwIfNotFound: true);
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

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_OnJump;
    private readonly InputAction m_Actions_OnMove;
    private readonly InputAction m_Actions_OnFire;
    private readonly InputAction m_Actions_OnInteract;
    private readonly InputAction m_Actions_OnPause;
    private readonly InputAction m_Actions_OnSwitch;
    public struct ActionsActions
    {
        private @PlayerActions m_Wrapper;
        public ActionsActions(@PlayerActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnJump => m_Wrapper.m_Actions_OnJump;
        public InputAction @OnMove => m_Wrapper.m_Actions_OnMove;
        public InputAction @OnFire => m_Wrapper.m_Actions_OnFire;
        public InputAction @OnInteract => m_Wrapper.m_Actions_OnInteract;
        public InputAction @OnPause => m_Wrapper.m_Actions_OnPause;
        public InputAction @OnSwitch => m_Wrapper.m_Actions_OnSwitch;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @OnJump.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnJump;
                @OnJump.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnJump;
                @OnJump.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnJump;
                @OnMove.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnMove;
                @OnMove.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnMove;
                @OnMove.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnMove;
                @OnFire.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnFire;
                @OnFire.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnFire;
                @OnFire.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnFire;
                @OnInteract.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnInteract;
                @OnInteract.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnInteract;
                @OnInteract.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnInteract;
                @OnPause.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnPause;
                @OnPause.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnPause;
                @OnPause.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnPause;
                @OnSwitch.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnSwitch;
                @OnSwitch.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnSwitch;
                @OnSwitch.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnOnSwitch;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @OnJump.started += instance.OnOnJump;
                @OnJump.performed += instance.OnOnJump;
                @OnJump.canceled += instance.OnOnJump;
                @OnMove.started += instance.OnOnMove;
                @OnMove.performed += instance.OnOnMove;
                @OnMove.canceled += instance.OnOnMove;
                @OnFire.started += instance.OnOnFire;
                @OnFire.performed += instance.OnOnFire;
                @OnFire.canceled += instance.OnOnFire;
                @OnInteract.started += instance.OnOnInteract;
                @OnInteract.performed += instance.OnOnInteract;
                @OnInteract.canceled += instance.OnOnInteract;
                @OnPause.started += instance.OnOnPause;
                @OnPause.performed += instance.OnOnPause;
                @OnPause.canceled += instance.OnOnPause;
                @OnSwitch.started += instance.OnOnSwitch;
                @OnSwitch.performed += instance.OnOnSwitch;
                @OnSwitch.canceled += instance.OnOnSwitch;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    public interface IActionsActions
    {
        void OnOnJump(InputAction.CallbackContext context);
        void OnOnMove(InputAction.CallbackContext context);
        void OnOnFire(InputAction.CallbackContext context);
        void OnOnInteract(InputAction.CallbackContext context);
        void OnOnPause(InputAction.CallbackContext context);
        void OnOnSwitch(InputAction.CallbackContext context);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/New Controls.inputactions
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

public partial class @NewControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""New action map"",
            ""id"": ""fc027551-c723-4b74-98d6-8dc3d9c9202d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""fa6c9947-aa87-4bf9-8bd2-23e55552bcd5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SlowWalk"",
                    ""type"": ""Button"",
                    ""id"": ""28ee1e61-b5e0-4c40-a3bb-51bc13668d1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""bd4adc90-8076-4c2d-a5e9-9b5523c03525"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ThrowingKnifeMode"",
                    ""type"": ""Button"",
                    ""id"": ""415f2500-f28f-4eb9-90d1-df2cf431238e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""PassThrough"",
                    ""id"": ""535ab209-3bdd-406e-84b2-ff7533aa152f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""5197669e-874d-4320-b329-524c80638978"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Invisibility"",
                    ""type"": ""Button"",
                    ""id"": ""b367cd61-a831-4560-9114-f3d7115fb98e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Smoke"",
                    ""type"": ""Button"",
                    ""id"": ""f3ea4040-8064-4d08-be3c-314fd2c2cde3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a6e97a62-e594-4ec2-ac3e-6fb5861d286c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8d9c8e03-c2d5-47b6-b8e2-395892dde14e"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""47d362a9-2cc0-40f8-b5b8-c51b7db4ba3c"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""80779e1d-707a-4294-aa49-8b9b093e0453"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""15e44cec-1323-4514-93a1-a0b083b88118"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bba91bc2-1f57-4d81-a8b3-55ee3d571b63"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SlowWalk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9fecaa3-8e42-4fa7-a09c-468e55694d31"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9761cef9-4305-4046-a5e1-2baaed160cdf"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowingKnifeMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46e7063a-7b8e-42df-92f4-8e15cee3dd8e"",
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
                    ""id"": ""2c43b113-b7e9-48f3-a02f-5744e589d92e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""584733bf-beaa-48ef-99a1-e9c9175e5a29"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Invisibility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba132acd-6bf8-4b12-a162-ca41d6075802"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Smoke"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Move = m_Newactionmap.FindAction("Move", throwIfNotFound: true);
        m_Newactionmap_SlowWalk = m_Newactionmap.FindAction("SlowWalk", throwIfNotFound: true);
        m_Newactionmap_Pause = m_Newactionmap.FindAction("Pause", throwIfNotFound: true);
        m_Newactionmap_ThrowingKnifeMode = m_Newactionmap.FindAction("ThrowingKnifeMode", throwIfNotFound: true);
        m_Newactionmap_Look = m_Newactionmap.FindAction("Look", throwIfNotFound: true);
        m_Newactionmap_Aim = m_Newactionmap.FindAction("Aim", throwIfNotFound: true);
        m_Newactionmap_Invisibility = m_Newactionmap.FindAction("Invisibility", throwIfNotFound: true);
        m_Newactionmap_Smoke = m_Newactionmap.FindAction("Smoke", throwIfNotFound: true);
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

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Move;
    private readonly InputAction m_Newactionmap_SlowWalk;
    private readonly InputAction m_Newactionmap_Pause;
    private readonly InputAction m_Newactionmap_ThrowingKnifeMode;
    private readonly InputAction m_Newactionmap_Look;
    private readonly InputAction m_Newactionmap_Aim;
    private readonly InputAction m_Newactionmap_Invisibility;
    private readonly InputAction m_Newactionmap_Smoke;
    public struct NewactionmapActions
    {
        private @NewControls m_Wrapper;
        public NewactionmapActions(@NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Newactionmap_Move;
        public InputAction @SlowWalk => m_Wrapper.m_Newactionmap_SlowWalk;
        public InputAction @Pause => m_Wrapper.m_Newactionmap_Pause;
        public InputAction @ThrowingKnifeMode => m_Wrapper.m_Newactionmap_ThrowingKnifeMode;
        public InputAction @Look => m_Wrapper.m_Newactionmap_Look;
        public InputAction @Aim => m_Wrapper.m_Newactionmap_Aim;
        public InputAction @Invisibility => m_Wrapper.m_Newactionmap_Invisibility;
        public InputAction @Smoke => m_Wrapper.m_Newactionmap_Smoke;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                @SlowWalk.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSlowWalk;
                @SlowWalk.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSlowWalk;
                @SlowWalk.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSlowWalk;
                @Pause.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnPause;
                @ThrowingKnifeMode.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnThrowingKnifeMode;
                @ThrowingKnifeMode.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnThrowingKnifeMode;
                @ThrowingKnifeMode.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnThrowingKnifeMode;
                @Look.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnLook;
                @Aim.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnAim;
                @Invisibility.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnInvisibility;
                @Invisibility.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnInvisibility;
                @Invisibility.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnInvisibility;
                @Smoke.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSmoke;
                @Smoke.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSmoke;
                @Smoke.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnSmoke;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @SlowWalk.started += instance.OnSlowWalk;
                @SlowWalk.performed += instance.OnSlowWalk;
                @SlowWalk.canceled += instance.OnSlowWalk;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @ThrowingKnifeMode.started += instance.OnThrowingKnifeMode;
                @ThrowingKnifeMode.performed += instance.OnThrowingKnifeMode;
                @ThrowingKnifeMode.canceled += instance.OnThrowingKnifeMode;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Invisibility.started += instance.OnInvisibility;
                @Invisibility.performed += instance.OnInvisibility;
                @Invisibility.canceled += instance.OnInvisibility;
                @Smoke.started += instance.OnSmoke;
                @Smoke.performed += instance.OnSmoke;
                @Smoke.canceled += instance.OnSmoke;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface INewactionmapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSlowWalk(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnThrowingKnifeMode(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnInvisibility(InputAction.CallbackContext context);
        void OnSmoke(InputAction.CallbackContext context);
    }
}
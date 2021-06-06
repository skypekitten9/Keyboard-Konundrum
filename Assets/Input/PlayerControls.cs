// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""RagdollControlls"",
            ""id"": ""e45631ee-12d6-4d32-8889-89cf9eec8951"",
            ""actions"": [
                {
                    ""name"": ""Left Launch"",
                    ""type"": ""Button"",
                    ""id"": ""9a13ded4-60f9-47ae-a7f5-0b3457be24db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Launch"",
                    ""type"": ""Button"",
                    ""id"": ""2ea8f4fd-98ae-4ffc-9144-59838b3dcb95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Movement"",
                    ""type"": ""Value"",
                    ""id"": ""e093810a-294a-4741-b824-5eb6cea06462"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Movement"",
                    ""type"": ""Value"",
                    ""id"": ""d02bf4c2-d736-4dbf-b8ed-53206e22dba4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0600a008-f32e-4f3f-b60a-54d543818b4f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Left Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a151beb-23bf-4eb5-b63e-5d3b2c4f90e6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Right Launch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""661c3f5e-f8af-4b9d-b8eb-38bf69a14ede"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Right Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""9a4b01d5-8812-4769-b92a-257d810d5962"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c2a1f061-9a96-48f1-8157-cbc90b51fd69"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f9b0fa96-470f-45ed-8731-2c484feebaef"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0fb33a8d-1a03-46cf-ba3f-50f06436e088"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ef9e054c-9cb7-4c75-9987-dc0268b265c5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Right Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8f74e7f5-ed4a-4665-bdf5-dbf36207032c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Left Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // RagdollControlls
        m_RagdollControlls = asset.FindActionMap("RagdollControlls", throwIfNotFound: true);
        m_RagdollControlls_LeftLaunch = m_RagdollControlls.FindAction("Left Launch", throwIfNotFound: true);
        m_RagdollControlls_RightLaunch = m_RagdollControlls.FindAction("Right Launch", throwIfNotFound: true);
        m_RagdollControlls_LeftMovement = m_RagdollControlls.FindAction("Left Movement", throwIfNotFound: true);
        m_RagdollControlls_RightMovement = m_RagdollControlls.FindAction("Right Movement", throwIfNotFound: true);
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

    // RagdollControlls
    private readonly InputActionMap m_RagdollControlls;
    private IRagdollControllsActions m_RagdollControllsActionsCallbackInterface;
    private readonly InputAction m_RagdollControlls_LeftLaunch;
    private readonly InputAction m_RagdollControlls_RightLaunch;
    private readonly InputAction m_RagdollControlls_LeftMovement;
    private readonly InputAction m_RagdollControlls_RightMovement;
    public struct RagdollControllsActions
    {
        private @PlayerControls m_Wrapper;
        public RagdollControllsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftLaunch => m_Wrapper.m_RagdollControlls_LeftLaunch;
        public InputAction @RightLaunch => m_Wrapper.m_RagdollControlls_RightLaunch;
        public InputAction @LeftMovement => m_Wrapper.m_RagdollControlls_LeftMovement;
        public InputAction @RightMovement => m_Wrapper.m_RagdollControlls_RightMovement;
        public InputActionMap Get() { return m_Wrapper.m_RagdollControlls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RagdollControllsActions set) { return set.Get(); }
        public void SetCallbacks(IRagdollControllsActions instance)
        {
            if (m_Wrapper.m_RagdollControllsActionsCallbackInterface != null)
            {
                @LeftLaunch.started -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnLeftLaunch;
                @LeftLaunch.performed -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnLeftLaunch;
                @LeftLaunch.canceled -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnLeftLaunch;
                @RightLaunch.started -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnRightLaunch;
                @RightLaunch.performed -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnRightLaunch;
                @RightLaunch.canceled -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnRightLaunch;
                @LeftMovement.started -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnLeftMovement;
                @LeftMovement.performed -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnLeftMovement;
                @LeftMovement.canceled -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnLeftMovement;
                @RightMovement.started -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnRightMovement;
                @RightMovement.performed -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnRightMovement;
                @RightMovement.canceled -= m_Wrapper.m_RagdollControllsActionsCallbackInterface.OnRightMovement;
            }
            m_Wrapper.m_RagdollControllsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftLaunch.started += instance.OnLeftLaunch;
                @LeftLaunch.performed += instance.OnLeftLaunch;
                @LeftLaunch.canceled += instance.OnLeftLaunch;
                @RightLaunch.started += instance.OnRightLaunch;
                @RightLaunch.performed += instance.OnRightLaunch;
                @RightLaunch.canceled += instance.OnRightLaunch;
                @LeftMovement.started += instance.OnLeftMovement;
                @LeftMovement.performed += instance.OnLeftMovement;
                @LeftMovement.canceled += instance.OnLeftMovement;
                @RightMovement.started += instance.OnRightMovement;
                @RightMovement.performed += instance.OnRightMovement;
                @RightMovement.canceled += instance.OnRightMovement;
            }
        }
    }
    public RagdollControllsActions @RagdollControlls => new RagdollControllsActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IRagdollControllsActions
    {
        void OnLeftLaunch(InputAction.CallbackContext context);
        void OnRightLaunch(InputAction.CallbackContext context);
        void OnLeftMovement(InputAction.CallbackContext context);
        void OnRightMovement(InputAction.CallbackContext context);
    }
}

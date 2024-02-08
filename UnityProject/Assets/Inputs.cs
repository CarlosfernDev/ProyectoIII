//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs.inputactions
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

public partial class @Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""ActionMap1"",
            ""id"": ""4f60b2fc-5b72-42d3-a181-53c57c0f668d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c98c9947-f885-4d9f-9a0a-1525a446ed6b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""da30644d-6bea-4b36-a6d1-56bd53010e75"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pausa"",
                    ""type"": ""Button"",
                    ""id"": ""d258961c-9e98-4a94-bab1-5b822e560264"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UsarEquipable"",
                    ""type"": ""Button"",
                    ""id"": ""b4135272-a709-4d19-a7d8-efc8c38421fb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e8a3ac31-4cfe-4b82-96f0-f67551e79f7b"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""161495a1-fc20-455b-abb8-cac216c357cb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bee81502-abd6-44b0-9a40-45c18d454590"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""45c48f11-d53d-44ae-8b91-adec197a639c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""56b5772c-9269-4492-aacd-a654e0b5dce2"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f6331dd5-9207-4353-b4aa-6de683eb8efc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dd285f0-cc64-4591-bc56-0331b36bc1fc"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pausa"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3b555d0-4570-4973-b211-3851d478ee4c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4366fcb1-8d19-4d50-b887-cad2b904042a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UsarEquipable"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // ActionMap1
        m_ActionMap1 = asset.FindActionMap("ActionMap1", throwIfNotFound: true);
        m_ActionMap1_Movement = m_ActionMap1.FindAction("Movement", throwIfNotFound: true);
        m_ActionMap1_Interact = m_ActionMap1.FindAction("Interact", throwIfNotFound: true);
        m_ActionMap1_Pausa = m_ActionMap1.FindAction("Pausa", throwIfNotFound: true);
        m_ActionMap1_UsarEquipable = m_ActionMap1.FindAction("UsarEquipable", throwIfNotFound: true);
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

    // ActionMap1
    private readonly InputActionMap m_ActionMap1;
    private List<IActionMap1Actions> m_ActionMap1ActionsCallbackInterfaces = new List<IActionMap1Actions>();
    private readonly InputAction m_ActionMap1_Movement;
    private readonly InputAction m_ActionMap1_Interact;
    private readonly InputAction m_ActionMap1_Pausa;
    private readonly InputAction m_ActionMap1_UsarEquipable;
    public struct ActionMap1Actions
    {
        private @Inputs m_Wrapper;
        public ActionMap1Actions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_ActionMap1_Movement;
        public InputAction @Interact => m_Wrapper.m_ActionMap1_Interact;
        public InputAction @Pausa => m_Wrapper.m_ActionMap1_Pausa;
        public InputAction @UsarEquipable => m_Wrapper.m_ActionMap1_UsarEquipable;
        public InputActionMap Get() { return m_Wrapper.m_ActionMap1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMap1Actions set) { return set.Get(); }
        public void AddCallbacks(IActionMap1Actions instance)
        {
            if (instance == null || m_Wrapper.m_ActionMap1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ActionMap1ActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Pausa.started += instance.OnPausa;
            @Pausa.performed += instance.OnPausa;
            @Pausa.canceled += instance.OnPausa;
            @UsarEquipable.started += instance.OnUsarEquipable;
            @UsarEquipable.performed += instance.OnUsarEquipable;
            @UsarEquipable.canceled += instance.OnUsarEquipable;
        }

        private void UnregisterCallbacks(IActionMap1Actions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Pausa.started -= instance.OnPausa;
            @Pausa.performed -= instance.OnPausa;
            @Pausa.canceled -= instance.OnPausa;
            @UsarEquipable.started -= instance.OnUsarEquipable;
            @UsarEquipable.performed -= instance.OnUsarEquipable;
            @UsarEquipable.canceled -= instance.OnUsarEquipable;
        }

        public void RemoveCallbacks(IActionMap1Actions instance)
        {
            if (m_Wrapper.m_ActionMap1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IActionMap1Actions instance)
        {
            foreach (var item in m_Wrapper.m_ActionMap1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ActionMap1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ActionMap1Actions @ActionMap1 => new ActionMap1Actions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IActionMap1Actions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPausa(InputAction.CallbackContext context);
        void OnUsarEquipable(InputAction.CallbackContext context);
    }
}

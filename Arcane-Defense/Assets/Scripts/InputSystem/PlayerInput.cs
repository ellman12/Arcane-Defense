//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.0
//     from Assets/Scripts/InputSystem/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""24155465-b13f-443a-8992-ad30e88a251b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c66b366a-ac17-411c-bbb1-d6ee72a5cfb5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a79d3cb7-4283-4968-bf2c-f3ba1900e4b5"",
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
                    ""id"": ""ea800ed0-f693-407e-84f5-0880590da7e1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d8651ff-fb7e-4d47-97bb-af6bb3c12986"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f52cf7e2-dd21-4ca5-b2a0-be232da755ee"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65a91d0c-17d8-43fc-b422-0703c5dcc104"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Spells"",
            ""id"": ""adbde275-3324-477c-bf80-b90d381bcd5d"",
            ""actions"": [
                {
                    ""name"": ""Slot1"",
                    ""type"": ""Button"",
                    ""id"": ""fef95831-ff45-4683-b77c-8dba8871ce98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot2"",
                    ""type"": ""Button"",
                    ""id"": ""71f9e0c1-f660-4428-a857-8e8c003aa534"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot3"",
                    ""type"": ""Button"",
                    ""id"": ""b7a3399e-b665-4aa6-a38d-c10d7c95ea63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot4"",
                    ""type"": ""Button"",
                    ""id"": ""cfb394f7-602b-4a09-9c5b-ab258a9c160a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot5"",
                    ""type"": ""Button"",
                    ""id"": ""05562281-6237-4ce6-b028-37f23d9ec729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Slot6"",
                    ""type"": ""Button"",
                    ""id"": ""d489cd7a-1522-481f-8fee-7637cbc37734"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80708d9a-6203-4f30-9252-5d8d4752e8e2"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ae2bcd7-25fe-4bec-af63-2122b634bd26"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd19334c-cd26-48ba-ad16-e60d751cc904"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f2be68e-0152-4e14-be93-b32c3f73ea9e"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19bb9c8f-a5ef-44d1-ac89-aa0d98a67708"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52c4bd25-3c29-41d0-80c3-75643773dcec"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slot6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
        // Spells
        m_Spells = asset.FindActionMap("Spells", throwIfNotFound: true);
        m_Spells_Slot1 = m_Spells.FindAction("Slot1", throwIfNotFound: true);
        m_Spells_Slot2 = m_Spells.FindAction("Slot2", throwIfNotFound: true);
        m_Spells_Slot3 = m_Spells.FindAction("Slot3", throwIfNotFound: true);
        m_Spells_Slot4 = m_Spells.FindAction("Slot4", throwIfNotFound: true);
        m_Spells_Slot5 = m_Spells.FindAction("Slot5", throwIfNotFound: true);
        m_Spells_Slot6 = m_Spells.FindAction("Slot6", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Movement;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Movement_Movement;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Spells
    private readonly InputActionMap m_Spells;
    private List<ISpellsActions> m_SpellsActionsCallbackInterfaces = new List<ISpellsActions>();
    private readonly InputAction m_Spells_Slot1;
    private readonly InputAction m_Spells_Slot2;
    private readonly InputAction m_Spells_Slot3;
    private readonly InputAction m_Spells_Slot4;
    private readonly InputAction m_Spells_Slot5;
    private readonly InputAction m_Spells_Slot6;
    public struct SpellsActions
    {
        private @PlayerInput m_Wrapper;
        public SpellsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Slot1 => m_Wrapper.m_Spells_Slot1;
        public InputAction @Slot2 => m_Wrapper.m_Spells_Slot2;
        public InputAction @Slot3 => m_Wrapper.m_Spells_Slot3;
        public InputAction @Slot4 => m_Wrapper.m_Spells_Slot4;
        public InputAction @Slot5 => m_Wrapper.m_Spells_Slot5;
        public InputAction @Slot6 => m_Wrapper.m_Spells_Slot6;
        public InputActionMap Get() { return m_Wrapper.m_Spells; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpellsActions set) { return set.Get(); }
        public void AddCallbacks(ISpellsActions instance)
        {
            if (instance == null || m_Wrapper.m_SpellsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SpellsActionsCallbackInterfaces.Add(instance);
            @Slot1.started += instance.OnSlot1;
            @Slot1.performed += instance.OnSlot1;
            @Slot1.canceled += instance.OnSlot1;
            @Slot2.started += instance.OnSlot2;
            @Slot2.performed += instance.OnSlot2;
            @Slot2.canceled += instance.OnSlot2;
            @Slot3.started += instance.OnSlot3;
            @Slot3.performed += instance.OnSlot3;
            @Slot3.canceled += instance.OnSlot3;
            @Slot4.started += instance.OnSlot4;
            @Slot4.performed += instance.OnSlot4;
            @Slot4.canceled += instance.OnSlot4;
            @Slot5.started += instance.OnSlot5;
            @Slot5.performed += instance.OnSlot5;
            @Slot5.canceled += instance.OnSlot5;
            @Slot6.started += instance.OnSlot6;
            @Slot6.performed += instance.OnSlot6;
            @Slot6.canceled += instance.OnSlot6;
        }

        private void UnregisterCallbacks(ISpellsActions instance)
        {
            @Slot1.started -= instance.OnSlot1;
            @Slot1.performed -= instance.OnSlot1;
            @Slot1.canceled -= instance.OnSlot1;
            @Slot2.started -= instance.OnSlot2;
            @Slot2.performed -= instance.OnSlot2;
            @Slot2.canceled -= instance.OnSlot2;
            @Slot3.started -= instance.OnSlot3;
            @Slot3.performed -= instance.OnSlot3;
            @Slot3.canceled -= instance.OnSlot3;
            @Slot4.started -= instance.OnSlot4;
            @Slot4.performed -= instance.OnSlot4;
            @Slot4.canceled -= instance.OnSlot4;
            @Slot5.started -= instance.OnSlot5;
            @Slot5.performed -= instance.OnSlot5;
            @Slot5.canceled -= instance.OnSlot5;
            @Slot6.started -= instance.OnSlot6;
            @Slot6.performed -= instance.OnSlot6;
            @Slot6.canceled -= instance.OnSlot6;
        }

        public void RemoveCallbacks(ISpellsActions instance)
        {
            if (m_Wrapper.m_SpellsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISpellsActions instance)
        {
            foreach (var item in m_Wrapper.m_SpellsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SpellsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SpellsActions @Spells => new SpellsActions(this);
    public interface IMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
    public interface ISpellsActions
    {
        void OnSlot1(InputAction.CallbackContext context);
        void OnSlot2(InputAction.CallbackContext context);
        void OnSlot3(InputAction.CallbackContext context);
        void OnSlot4(InputAction.CallbackContext context);
        void OnSlot5(InputAction.CallbackContext context);
        void OnSlot6(InputAction.CallbackContext context);
    }
}
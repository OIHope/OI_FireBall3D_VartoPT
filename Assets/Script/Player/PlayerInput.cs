//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.8.2
//     from Assets/Script/Player/PlayerInput.inputactions
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
using UnityEngine;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""GameInput"",
            ""id"": ""c68da317-131f-4f0b-9347-904331dc1ccc"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""34fb4603-0288-4f44-becf-13a47cc64c20"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc95a098-9069-467c-8f66-dd1982c603ff"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ecd545ad-9ca9-49b1-9faa-88797c83ffb7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GameInput
        m_GameInput = asset.FindActionMap("GameInput", throwIfNotFound: true);
        m_GameInput_Shoot = m_GameInput.FindAction("Shoot", throwIfNotFound: true);
    }

    ~@PlayerInput()
    {
        Debug.Assert(!m_GameInput.enabled, "This will cause a leak and performance issues, PlayerInput.GameInput.Disable() has not been called.");
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

    // GameInput
    private readonly InputActionMap m_GameInput;
    private List<IGameInputActions> m_GameInputActionsCallbackInterfaces = new List<IGameInputActions>();
    private readonly InputAction m_GameInput_Shoot;
    public struct GameInputActions
    {
        private @PlayerInput m_Wrapper;
        public GameInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_GameInput_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_GameInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameInputActions set) { return set.Get(); }
        public void AddCallbacks(IGameInputActions instance)
        {
            if (instance == null || m_Wrapper.m_GameInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameInputActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
        }

        private void UnregisterCallbacks(IGameInputActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
        }

        public void RemoveCallbacks(IGameInputActions instance)
        {
            if (m_Wrapper.m_GameInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameInputActions instance)
        {
            foreach (var item in m_Wrapper.m_GameInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameInputActions @GameInput => new GameInputActions(this);
    public interface IGameInputActions
    {
        void OnShoot(InputAction.CallbackContext context);
    }
}

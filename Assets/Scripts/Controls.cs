// GENERATED AUTOMATICALLY FROM 'Assets/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""f0a236c4-2b27-4e35-bd23-0c378a4fd5cc"",
            ""actions"": [
                {
                    ""name"": ""Speed"",
                    ""type"": ""Value"",
                    ""id"": ""1da4260f-6254-4b81-a887-86493c114b67"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""d25f5f25-3f4c-47ae-b861-80d9f9dd7845"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fly"",
                    ""type"": ""Button"",
                    ""id"": ""6b5743ec-5d27-4b01-a895-377c9b79d44e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard AD"",
                    ""id"": ""d1d9a9d4-fd67-4a46-9794-1421b88f60df"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""01b38fcb-fe70-4e47-a860-255eea3c0941"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""9f771fda-2318-437e-b75d-fc403002ad3e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Arrow Keys"",
                    ""id"": ""964f32cf-9cba-4196-b33b-c6c7b062f2db"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""34f9b146-67ca-40ba-bcab-20a0f074baf6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""580ade33-721d-4578-95c7-323520c7f69c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d48a68b7-bd57-434d-9923-fe3b5be3c530"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcf8772a-d431-4e34-81ab-006228663792"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard WS"",
                    ""id"": ""ed8c6d72-8505-4b3e-bfff-3c1a8c91d8a3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6f46f036-4ae3-4cf8-b6dd-592a0e0a2ebe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""5e3f748c-bb13-41fd-b627-92124927be7a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Arrow Keys"",
                    ""id"": ""5ff940bf-3bad-4c1d-b4df-d422415e811e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3c7b1813-a8cf-4b03-bad3-d02be1ca6926"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""753c8b60-3592-49b8-a779-03df7f7b894c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Speed = m_Game.FindAction("Speed", throwIfNotFound: true);
        m_Game_Jump = m_Game.FindAction("Jump", throwIfNotFound: true);
        m_Game_Fly = m_Game.FindAction("Fly", throwIfNotFound: true);
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Speed;
    private readonly InputAction m_Game_Jump;
    private readonly InputAction m_Game_Fly;
    public struct GameActions
    {
        private Controls m_Wrapper;
        public GameActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction Speed => m_Wrapper.m_Game_Speed;
        public InputAction Jump => m_Wrapper.m_Game_Jump;
        public InputAction Fly => m_Wrapper.m_Game_Fly;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                Speed.started -= m_Wrapper.m_GameActionsCallbackInterface.OnSpeed;
                Speed.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnSpeed;
                Speed.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnSpeed;
                Jump.started -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnJump;
                Fly.started -= m_Wrapper.m_GameActionsCallbackInterface.OnFly;
                Fly.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnFly;
                Fly.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnFly;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                Speed.started += instance.OnSpeed;
                Speed.performed += instance.OnSpeed;
                Speed.canceled += instance.OnSpeed;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Fly.started += instance.OnFly;
                Fly.performed += instance.OnFly;
                Fly.canceled += instance.OnFly;
            }
        }
    }
    public GameActions Game => new GameActions(this);
    public interface IGameActions
    {
        void OnSpeed(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnFly(InputAction.CallbackContext context);
    }
}

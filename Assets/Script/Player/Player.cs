using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UDCJ
{
    public class Player : MonoBehaviour, IBulletInteractable
    {
        private Rigidbody2D rigidbody;
        private PlayerInput playerInput;
        private InputAction moveAction;
        private InputAction shootAction;
        private InputAction lookAction;
        private Vector2 shootDirection;
        
        private GameplayColour currentColour;
        public GameplayColour CurrentColour
        {
            get
            {
                return currentColour;
            }
            private set
            {
                currentColour = value;
                GameStatics.SetSpriteColour(playerVisualsSpriteRenderer, currentColour);
                GameStatics.SetGameObjectToColourLayer(this.gameObject, currentColour);
                if (directionIndicator != null)
                {
                    if (currentColour == GameplayColour.Nutral)
                    {
                        directionIndicator.gameObject.SetActive(false);
                    }
                    else
                    {
                        directionIndicator.gameObject.SetActive(true);
                    }
                }
            }
        }

        [SerializeField] [MinValue(0)] [MaxValue(1)]
        private int playerIndex = 0;
        
        [Space][Space]
        [SerializeField]
        private float moveSpeed = 10.0f;
        [SerializeField]
        private ColouredBullet bulletPrefab;
        [SerializeField]
        private SpriteRenderer[] playerVisualsSpriteRenderer;

        [SerializeField] 
        private Transform directionIndicator;

        private IBulletInteractable _bulletInteractableImplementation;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            if (rigidbody == null)
            {
                Debug.LogError("Rigidbody not found on player");
            }
        }

        private void Start()
        {
            CurrentColour = GameplayColour.Nutral;
            
            playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            shootAction = playerInput.actions["Shoot"];
            lookAction = playerInput.actions["Look"];
            
            InputSystem.onDeviceChange += InputSystemOnonDeviceChange;
            AssignInputDevicesToPlayer();
        }

        private void OnDestroy()
        {
            InputSystem.onDeviceChange -= InputSystemOnonDeviceChange;
        }
        
#region Co-Op Input Assignment Handeling
        private void InputSystemOnonDeviceChange(InputDevice inputDevice, InputDeviceChange change)
        {
            if (inputDevice is Gamepad)
            {
                AssignInputDevicesToPlayer();
            }
        }

        private void AssignInputDevicesToPlayer()
        {
            ReadOnlyArray<Gamepad> gamepads = Gamepad.all;
            InputDevice[] devices = new InputDevice[0];

            if (gamepads.Count >= 2)
            {
                switch (playerIndex)
                {
                    case 0:
                        devices = new InputDevice[1] { gamepads[1] };
                        break;
                    case 1:
                        devices = new InputDevice[1] { gamepads[0] };
                        break;
                }
                playerInput.SwitchCurrentControlScheme("Gamepad", devices);
            }
            else if (gamepads.Count == 1)
            {
                switch (playerIndex)
                {
                    case 0:
                        devices = new InputDevice[2] { Keyboard.current, Mouse.current };
                        playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", devices);
                        break;
                    case 1:
                        devices = new InputDevice[1] { gamepads[0] };
                        playerInput.SwitchCurrentControlScheme("Gamepad", devices);
                        break;
                }
            }
            else
            {
                Debug.Log("There is no controller connected, need at least 1 controller along side keyboard to play this game");
            }
        }
#endregion

        private void Update()
        {
            Vector2 moveDirection = moveAction.ReadValue<Vector2>().normalized;
            Vector2 lookDirection = lookAction.ReadValue<Vector2>().normalized;
            Vector2 shootDirection = lookDirection != Vector2.zero ? lookDirection : moveDirection;

            rigidbody.linearVelocity = moveDirection * moveSpeed;
            if (shootDirection != Vector2.zero)
            {
                directionIndicator.rotation = Quaternion.LookRotation(directionIndicator.forward, shootDirection);
            }
            if (moveDirection != Vector2.zero)
            {
                shootDirection = moveDirection;
            }
            
            if (shootAction.WasPressedThisFrame())
            {
                SpitOutCurrentColour();
            }
            
#if UNITY_EDITOR
            if (Keyboard.current.kKey.wasPressedThisFrame)
            {
                int currentColourInt = (int)CurrentColour;
                currentColourInt++;
                if (currentColourInt > 3)
                    currentColourInt = 0;
                CurrentColour = (GameplayColour)currentColourInt;
            }
#endif
        }

        private void SpitOutCurrentColour()
        {
            if (CurrentColour == GameplayColour.Nutral)
                return;
            
            Vector3 spawnPoint = directionIndicator.position + (directionIndicator.up);
            ColouredBullet spawnedBullet = Instantiate(bulletPrefab,  spawnPoint, Quaternion.identity);
            spawnedBullet.SetupBullet(CurrentColour, directionIndicator.up);
            
            CurrentColour = GameplayColour.Nutral;
        }

        public void SetPlayerColour(GameplayColour newColour)
        {
            CurrentColour = newColour;
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            if (interactingBullet.BulletColour != CurrentColour)
            {
                SetPlayerColour(interactingBullet.BulletColour);
            }
        }
    }
}
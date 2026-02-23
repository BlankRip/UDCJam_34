using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace UDCJ
{
    public class Player : MonoBehaviour, IBulletInteractable
    {
        private Rigidbody2D rigidbody;
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
            
            PlayerInput playerInput = GetComponent<PlayerInput>();
            moveAction = playerInput.actions["Move"];
            shootAction = playerInput.actions["Shoot"];
            lookAction = playerInput.actions["Look"];
        }

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
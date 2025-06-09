using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace UDCJ
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rigidbody;
        private InputAction moveAction;
        private InputAction shootAction;
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
            
            PlayerInput playerInput = PlayerInputProvider.GetPlayerInputComp();
            moveAction = playerInput.actions["Move"];
            shootAction = playerInput.actions["Shoot"];
        }

        private void Update()
        {
            Vector2 moveDirection = moveAction.ReadValue<Vector2>().normalized;
            rigidbody.linearVelocity = moveDirection * moveSpeed;
            if (moveDirection != Vector2.zero)
            {
                directionIndicator.rotation = Quaternion.LookRotation(directionIndicator.forward, moveDirection);
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
            
            Debug.Log("Spit out colour");
            Vector3 spawnPoint = directionIndicator.position + (directionIndicator.up);
            ColouredBullet spawnedBullet = Instantiate(bulletPrefab,  spawnPoint, Quaternion.identity);
            spawnedBullet.SetupBullet(CurrentColour, directionIndicator.up);
            
            CurrentColour = GameplayColour.Nutral;
        }

        public void SetPlayerColour(GameplayColour newColour)
        {
            CurrentColour = newColour;
        }
    }
}
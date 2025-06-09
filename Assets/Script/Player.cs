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
        private GameplayColour CurrentColour
        {
            get
            {
                return currentColour;
            }
            set
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
        private float moveSpeed = 2000.0f;
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
            rigidbody.linearVelocity = moveDirection * (moveSpeed * Time.deltaTime);
            if (moveDirection != Vector2.zero)
            {
                directionIndicator.rotation = Quaternion.LookRotation(directionIndicator.forward, moveDirection);
                shootDirection = moveDirection;
            }
            
            if (shootAction.WasPressedThisFrame())
            {
                SpitOutCurrentColour();
            }
            
            if (Keyboard.current.kKey.wasPressedThisFrame)
            {
                int currentColourInt = (int)CurrentColour;
                currentColourInt++;
                if (currentColourInt > 3)
                    currentColourInt = 0;
                CurrentColour = (GameplayColour)currentColourInt;
            }
        }

        private void SpitOutCurrentColour()
        {
            if (CurrentColour == GameplayColour.Nutral)
                return;
            
            Debug.Log("Spit out colour");
            CurrentColour = GameplayColour.Nutral;
        }

        private void SetGameobjectLayer(int layer)
        {
            gameObject.layer = layer;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = layer;
            }
        }
    }
}
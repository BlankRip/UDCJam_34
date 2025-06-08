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

        [SerializeField]
        private float moveSpeed = 2000.0f;
        [SerializeField]
        private SpriteRenderer playerVisualSpriteRenderer;

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
            GameStatics.SetSpriteColor(playerVisualSpriteRenderer, GameplayColour.Nutral);
            SetGameobjectLayer(GameStatics.NutralColourLayer);
            
            PlayerInput playerInput = PlayerInputProvider.GetPlayerInputComp();
            moveAction = playerInput.actions["Move"];
        }

        private void Update()
        {
            Vector2 moveDirection = moveAction.ReadValue<Vector2>().normalized;
            rigidbody.linearVelocity = moveDirection * moveSpeed * Time.deltaTime;
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
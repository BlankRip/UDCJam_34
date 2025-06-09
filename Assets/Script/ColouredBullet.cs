using System;
using Unity.VisualScripting;
using UnityEngine;

namespace UDCJ
{
    public class ColouredBullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1300.0f;
        [SerializeField] private float lifetime = 16.0f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private GameplayColour bulletColour;
        private Rigidbody2D rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            Destroy(this.gameObject, lifetime);
        }

        private void Update()
        {
            rigidbody.linearVelocity = transform.up * moveSpeed;
        }

        public void SetupBullet(GameplayColour colour, Vector3 upVector)
        {
            GameStatics.SetSpriteColour(spriteRenderer, colour);
            GameStatics.SetGameObjectToColourLayer(this.gameObject, colour);
            transform.up = upVector;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(this.gameObject, 0.03f);
        }
    }
}
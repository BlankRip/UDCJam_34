using MyNamespace;
using UnityEngine;

namespace UDCJ
{
    public class ColouredBullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1300.0f;
        [SerializeField] private float lifetime = 16.0f;
        
        [Space][Space][Header("Visuals")]
        [SerializeField] private SpriteRenderer[] spriteRenderers;
        [SerializeField] private Transform visualRotationPivot;
        
        public GameplayColour BulletColour { get; private set; }
        private Rigidbody2D rigidbody;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            Destroy(this.gameObject, lifetime);
        }

        private void Update()
        {
            rigidbody.linearVelocity = transform.up * moveSpeed;
            visualRotationPivot.Rotate(Vector3.forward, Time.deltaTime * -360.0f);
        }

        public void SetupBullet(GameplayColour colour, Vector3 upVector)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                GameStatics.SetSpriteColour(spriteRenderer, colour);
            }
            GameStatics.SetGameObjectToColourLayer(this.gameObject, colour);
            transform.up = upVector;
            BulletColour = colour;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IBulletInteractable interactable = other.GetComponent<IBulletInteractable>();
            if (interactable != null)
            {
                interactable.OnInteract(this);
            }
            if (other.GetComponent<IIgnoreBulletDestroy>() == null)
            {
                Destroy(this.gameObject, 0.03f);
            }
        }
    }
}
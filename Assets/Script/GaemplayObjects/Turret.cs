using NaughtyAttributes;
using UnityEngine;

namespace UDCJ
{
    public class Turret : ColourGameObjectBase
    {
        [Space] [Space] 
        [Header("Turret Settings")] 
        [SerializeField] private float gapBetweenShots = 3.0f;
        [SerializeField] private Transform spawnPointTransform;
        [SerializeField] private ColouredBullet bulletPrefab;
#if UNITY_EDITOR
        [OnValueChanged("OnStartDeactivatedChanged")]
#endif
        [SerializeField] private bool startDeactivated = false;
        [SerializeField] private float startDelay = 0.0f;

        private GameplayColour currentColour;
        private float timer;
        private bool isActive;

        private void Start()
        {
            FunctionaltiyPass();
            
            currentColour = startDeactivated ? GameplayColour.Nutral : startingColour;
            timer = gapBetweenShots + startDelay;
            isActive = !startDeactivated;
        }

        private void FunctionaltiyPass()
        {
            if (bulletPrefab == null)
            {
                Debug.LogError("There is no assigned bullet prefab so self destroying component", gameObject);
                DestroyImmediate(this);
            }

            if (spawnPointTransform == null)
            {
                Debug.LogError("There is no assigned spawn point transform so self destroying component", gameObject);
                DestroyImmediate(this);
            }
        }

        private void Update()
        {
            if (!isActive)
                return;
            
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                SpawnBullet();
                timer = gapBetweenShots;
            }
        }

        private void SpawnBullet()
        {
            Vector3 spawnPoint = spawnPointTransform.position + (spawnPointTransform.up * 0.4f);
            ColouredBullet spawnedBullet = Instantiate(bulletPrefab,  spawnPoint, Quaternion.identity);
            spawnedBullet.SetupBullet(currentColour, spawnPointTransform.up);
        }

        public void OnPoweredUp(GameplayColour powerColour)
        {
            isActive = true;
            currentColour = powerColour;
            SetObjectColour(currentColour);
            timer = gapBetweenShots;
            SpawnBullet();
        }

        public void Deactivate()
        {
            isActive = false;
            currentColour = GameplayColour.Nutral;
            SetObjectColour(currentColour);
        }
        
#if UNITY_EDITOR
        private void OnStartDeactivatedChanged()
        {
            if(startDeactivated)
                startingColour = GameplayColour.Nutral;
            SetObjectColour(startingColour);
        }
#endif
    }
}

using System;
using NaughtyAttributes;
using UnityEngine;

namespace UDCJ
{
    public class Portal : MonoBehaviour, IBulletInteractable
    {
        [Header("Visuals")]
        [SerializeField] private Transform spinnySquare;
        [SerializeField] private Transform spinnySquare2;
        [SerializeField] [Range(0, 8)]
        #if UNITY_EDITOR
        [OnValueChanged("SetPortalColour")]
        #endif
        private int portalColourIndex;
        [SerializeField] private PortalColours portalColours;

        [Space] [Space]
        [Header("Portal Settings")]
        [SerializeField] private Portal connectedPortal;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private ColouredBullet bulletPrefab;

        private void Start()
        {
            SetPortalColour();
            FunctionalityPass();
        }

        private void FunctionalityPass()
        {
            if (connectedPortal == null)
            {
                Debug.LogError("There is no connected Portal so self destroying component", gameObject);
                DestroyImmediate(this);
            }
            if (bulletPrefab == null)
            {
                Debug.LogError("There is no assigned bullet prefab so self destroying component", gameObject);
                DestroyImmediate(this);
            }
        }

        private void Update()
        {
            spinnySquare.Rotate(Vector3.forward, Time.deltaTime * 180f);
            spinnySquare2.Rotate(Vector3.forward, Time.deltaTime * -180f);
        }

        public void SpawnBullet(GameplayColour colour)
        {
            Vector3 spawnPoint = bulletSpawnPoint.position;
            ColouredBullet spawnedBullet = Instantiate(bulletPrefab,  spawnPoint, Quaternion.identity);
            spawnedBullet.SetupBullet(colour, bulletSpawnPoint.up);
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            connectedPortal.SpawnBullet(interactingBullet.BulletColour);
        }

        private void SetPortalColour()
        {
            SpriteRenderer render = spinnySquare.GetComponent<SpriteRenderer>();
            if(render != null)
                render.color = portalColours.Colours[portalColourIndex];
            render = spinnySquare2.GetComponent<SpriteRenderer>();
            if(render != null)
                render.color = portalColours.Colours[portalColourIndex];
                
        }
        
        #if UNITY_EDITOR
        public void SetPortalColourIndex(int colourIndex)
        {
            portalColourIndex = colourIndex;
            SetPortalColour();
        }
        #endif
    }
}
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

        [Space] [Space]
        [Header("Portal Settings")]
        [SerializeField] private Portal connectedPortal;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private ColouredBullet bulletPrefab;

        private void Start()
        {
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
    }
}
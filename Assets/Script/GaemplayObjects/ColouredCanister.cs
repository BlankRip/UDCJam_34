using System;
using UnityEngine;

namespace UDCJ
{
    public class ColouredCanister : ColourGameObjectBase, IBulletInteractable
    {   
        [Space][Space][Header("Canister Specifics")]
        [SerializeField] ColourSplatter colourSplatterPrefab;
        private GameplayColour currentColour;

        private void Start()
        {
            currentColour = startingColour;
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            if (currentColour == GameplayColour.Nutral)
            {
                currentColour = interactingBullet.BulletColour;
                SetObjectColour(currentColour);
            }
            else
            {
                if (currentColour != interactingBullet.BulletColour)
                {
                    ColourSplatter spawnedSpatter = Instantiate(colourSplatterPrefab, transform.position, Quaternion.identity);
                    spawnedSpatter.SetObjectColour(currentColour);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
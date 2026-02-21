using System;
using MyNamespace;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace UDCJ
{
    public class ColourSplatter : ColourGameObjectBase, IIgnoreBulletDestroy
    {
        [SerializeField] bool isSingelPickUp = false;

        public override void SetObjectColour(GameplayColour gameplayColour)
        {
            base.SetObjectColour(gameplayColour);
            startingColour = gameplayColour;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if(player)
            {
                if (isSingelPickUp)
                {
                    if (player.CurrentColour == startingColour)
                        return;
                }
                
                player.SetPlayerColour(startingColour);
                
                if (isSingelPickUp)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}

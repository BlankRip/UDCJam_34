using System;
using MyNamespace;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.U2D;

namespace UDCJ
{
    public class ColourSplatter : MonoBehaviour, IIgnoreBulletDestroy
    {
#if UNITY_EDITOR
        [OnValueChanged("SetColourInEditor")]
#endif
        [SerializeField] private GameplayColour splatterColour;
        [SerializeField] private SpriteShapeRenderer spriteRenderer;

        public void SetSplatterColour(GameplayColour colour)
        {
            GameStatics.SetSpriteColour(spriteRenderer, colour);
            splatterColour = colour;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if(player)
            {
                player.SetPlayerColour(splatterColour);
            }
        }

#if UNITY_EDITOR
        private void SetColourInEditor()
        {
            GameStatics.SetSpriteColour(spriteRenderer, splatterColour);
        }
#endif
    }
}

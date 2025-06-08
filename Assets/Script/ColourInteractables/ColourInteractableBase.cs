using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace UDCJ
{
    public class ColourInteractableBase : MonoBehaviour
    {
#if UNITY_EDITOR
        [OnValueChanged("OnStartingColourValueChanged")]
#endif
        [SerializeField] protected GameplayColour startingColour;
        [SerializeField] protected SpriteRenderer[] visualsSpriteRenderers;

        protected void SetObjectColour(GameplayColour gameplayColour)
        {
            foreach (SpriteRenderer spriteRenderer in visualsSpriteRenderers)
            {
                GameStatics.SetSpriteColor(spriteRenderer, gameplayColour);
            }
            GameStatics.SetGameObjectToColourLayer(this.gameObject, gameplayColour);
        }
        
#if UNITY_EDITOR
        private void OnStartingColourValueChanged()
        {
            SetObjectColour(startingColour);
        }
#endif
    }
}

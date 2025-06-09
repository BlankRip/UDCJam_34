using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace UDCJ
{
    public class ColourInteractableBase : MonoBehaviour
    {
#if UNITY_EDITOR
        [OnValueChanged("OnStartingColourValueChanged")]
#endif
        [SerializeField] protected GameplayColour startingColour;
        [SerializeField] protected SpriteRenderer[] visualsSpriteRenderers;
        [SerializeField] protected SpriteShapeRenderer[] visualsSpriteShapeRenderers;

        protected void SetObjectColour(GameplayColour gameplayColour)
        {
            GameStatics.SetSpriteColour(visualsSpriteRenderers, gameplayColour);
            GameStatics.SetSpriteColour(visualsSpriteShapeRenderers, gameplayColour);
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

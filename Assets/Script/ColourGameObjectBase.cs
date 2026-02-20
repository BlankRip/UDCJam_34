using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace UDCJ
{
    public class ColourGameObjectBase : MonoBehaviour
    {
#if UNITY_EDITOR
        [OnValueChanged("OnStartingColourValueChanged")]
#endif
        [SerializeField] protected GameplayColour startingColour;
        [SerializeField] protected bool shouldAdjustLayer = false;
        [SerializeField] protected SpriteRenderer[] visualsSpriteRenderers;
        [SerializeField] protected SpriteShapeRenderer[] visualsSpriteShapeRenderers;

        protected void SetObjectColour(GameplayColour gameplayColour)
        {
            GameStatics.SetSpriteColour(visualsSpriteRenderers, gameplayColour);
            GameStatics.SetSpriteColour(visualsSpriteShapeRenderers, gameplayColour);
            if (shouldAdjustLayer)
            {
                GameStatics.SetGameObjectToColourLayer(this.gameObject, gameplayColour);
            }
        }
        
        public void ReturnToStartingColour()
        {
            SetObjectColour(startingColour);
        }
        
#if UNITY_EDITOR
        private void OnStartingColourValueChanged()
        {
            SetObjectColour(startingColour);
        }
#endif
    }
}

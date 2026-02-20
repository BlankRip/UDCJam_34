using NaughtyAttributes;
using UnityEngine;

namespace UDCJ
{
    public class WallPiece : MonoBehaviour
    {
#if UNITY_EDITOR
        [OnValueChanged("OnWallSizeChanged")]
#endif
        [SerializeField] private Vector2 wallSize = new Vector2(0.8f, 1.0f);

        [SerializeField] private Transform visualTransform;
            
#if UNITY_EDITOR
        private void OnWallSizeChanged()
        {
            if(visualTransform)
                visualTransform.localScale = new Vector3(wallSize.x, wallSize.y, 1.0f);
        }
#endif
    }
}

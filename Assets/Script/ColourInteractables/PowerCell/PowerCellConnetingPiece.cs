using NaughtyAttributes;
using UnityEngine;

namespace UDCJ
{
    public class PowerCellConnetingPiece : ColourGameObjectBase
    {
#if UNITY_EDITOR
        [OnValueChanged("OnPieceSizeChanged")]
#endif
        [SerializeField] private Vector2 pieceSize = new Vector2(2.0f, 0.25f);
        
#if UNITY_EDITOR
        private void OnPieceSizeChanged()
        {
            if(visualsSpriteRenderers[0] != null)
                visualsSpriteRenderers[0].transform.localScale = new Vector3(pieceSize.x, pieceSize.y, 1.0f);
        }
#endif
    }
}
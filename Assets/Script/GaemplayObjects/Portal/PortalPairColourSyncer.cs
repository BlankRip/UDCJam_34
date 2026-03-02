using NaughtyAttributes;
using UnityEngine;

namespace UDCJ
{
    public class PortalPairColourSyncer : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] Portal portal;
        [SerializeField] Portal portal2;
        [SerializeField] [Range(0, 8)]
        [OnValueChanged("SetPortalColour")]
        private int portalColourIndex;
        
        private void SetPortalColour()
        {
            portal.SetPortalColourIndex(portalColourIndex);
            portal2.SetPortalColourIndex(portalColourIndex);
        }
#endif
    }
}

using UDCJ;
using UnityEngine;

namespace UDCJ
{
    public class UI_Base : MonoBehaviour
    {
        [field: SerializeField] public UIType CurrentUIType { get; protected set; }
    }
}
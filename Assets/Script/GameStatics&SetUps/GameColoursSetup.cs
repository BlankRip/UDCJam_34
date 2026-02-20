using System;
using UnityEngine;

namespace UDCJ
{
    public class GameColoursSetup : MonoBehaviour
    {
        [SerializeField] private Color nutralColour = Color.white;
        [SerializeField] private Color colour1 = Color.blue;
        [SerializeField] private Color colour2 = Color.yellow;
        [SerializeField] private Color colour3 = Color.green;

        private void Awake()
        {
            GameStatics.NutralColour = nutralColour;
            GameStatics.Colour1 = colour1;
            GameStatics.Colour2 = colour2;
            GameStatics.Colour3 = colour3;
        }
    }
}

using System;
using UnityEngine;

namespace UDCJ
{
    public class ColouredDoor : ColourInteractableBase
    {
        private void Start()
        {
            SetObjectColour(startingColour);
        }

        public void ChangeDoorColor(GameplayColour colour)
        {
            //Maybe some SFX here
            SetObjectColour(colour);
        }
    }
}
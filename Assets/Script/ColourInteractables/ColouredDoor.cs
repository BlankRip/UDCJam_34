using System;
using UnityEngine;

namespace UDCJ
{
    public class ColouredDoor : ColourGamebojectBase
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

        public void ReturnDoorColorToStartingColour()
        {
            SetObjectColour(startingColour);
        }
    }
}
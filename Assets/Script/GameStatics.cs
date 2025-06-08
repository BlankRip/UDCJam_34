using System;
using UnityEngine;

namespace UDCJ
{
    public static class GameStatics
    {
        public static string Colour1Name = "Blue";
        public static string Colour2Name = "Yellow";
        public static string Colour3Name = "Green";

        public static int NutralColourLayer = 0;
        public static int Colour1Layer = 6;
        public static int Colour2Layer = 7;
        public static int Colour3Layer = 8;
        
        public static Color NutralColour = Color.white;
        public static Color Colour1 = Color.blue;
        public static Color Colour2 = Color.yellow;
        public static Color Colour3 = Color.green;
        
        public static void SetSpriteColor(SpriteRenderer spriteRenderer, GameplayColour gameplayColour)
        {
            int colour = (int)gameplayColour;
            if (colour < 0 || colour > 3)
            {
                Debug.LogError("Requesting invalid colour from game statics");
            }
            
            switch (colour)
            {
                case 0:
                    spriteRenderer.color = NutralColour;
                    break;
                case 1:
                    spriteRenderer.color = Colour1;
                    break;
                case 2:
                    spriteRenderer.color = Colour2;
                    break;
                case 3:
                    spriteRenderer.color = Colour3;
                    break;
                default:
                    spriteRenderer.color = NutralColour;
                    break;
            }
        }
    }
}

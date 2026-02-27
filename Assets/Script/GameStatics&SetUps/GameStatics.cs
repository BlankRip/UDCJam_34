using System;
using UnityEngine;
using UnityEngine.U2D;

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
        
        public static Color NutralColour = Color.gray;
        public static Color Colour1 = Color.blue;
        public static Color Colour2 = Color.yellow;
        public static Color Colour3 = Color.green;
        public static Color WallColour = Color.black;
        
        public static string UnlockedLevelsId = "UnlockedLevels";
        public static string LastPlayedLevelId = "LastPlayedLevel";
        public static int Level1SceneBuildIndex = 1;

        public static void SetGameObjectToColourLayer(GameObject gameObject, GameplayColour gameplayColour)
        {
            int layerToSetTo = GetColourLayer(gameplayColour);
            gameObject.layer = layerToSetTo;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.layer = layerToSetTo;
            }
        }
        
        private static int GetColourLayer(GameplayColour gameplayColour)
        {
            int colour = (int)gameplayColour;
            switch (colour)
            {
                case 0:
                    return NutralColourLayer;
                case 1:
                    return Colour1Layer;
                case 2:
                    return Colour2Layer;
                case 3:
                    return Colour3Layer;
                default:
                    return NutralColourLayer;
            }
        }

        public static void SetSpriteColour(SpriteRenderer[] spriteRenderers, GameplayColour gameplayColour)
        {
            foreach (SpriteRenderer renderer in spriteRenderers)
            {
                SetSpriteColour(renderer, gameplayColour);
            }
        }
        
        public static void SetSpriteColour(SpriteRenderer spriteRenderer, GameplayColour gameplayColour)
        {
            int colour = (int)gameplayColour;
            if (colour < 0 || colour > 4)
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
                case 4:
                    spriteRenderer.color = WallColour;
                    break;
                default:
                    spriteRenderer.color = NutralColour;
                    break;
            }
        }
        
        public static void SetSpriteColour(SpriteShapeRenderer[] spriteRenderers, GameplayColour gameplayColour)
        {
            foreach (SpriteShapeRenderer renderer in spriteRenderers)
            {
                SetSpriteColour(renderer, gameplayColour);
            }
        }
        
        public static void SetSpriteColour(SpriteShapeRenderer spriteRenderer, GameplayColour gameplayColour)
        {
            int colour = (int)gameplayColour;
            if (colour < 0 || colour > 4)
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
                case 4:
                    spriteRenderer.color = WallColour;
                    break;
                default:
                    spriteRenderer.color = NutralColour;
                    break;
            }
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UDCJ
{
    public class PlayerInputProvider : MonoBehaviour
    {
        private static PlayerInput playerInput;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            if (playerInput == null)
            {
                Debug.LogError("There is no player input component attached to this game object.");
            }
        }

        public static PlayerInput GetPlayerInputComp()
        {
            if (playerInput == null)
            {
                Debug.LogError("No player input avaiable to provide");
                return null;
            }
            return playerInput;
        }
    }
}
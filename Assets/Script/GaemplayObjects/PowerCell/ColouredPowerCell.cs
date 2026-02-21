using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UDCJ
{
    public class ColouredPowerCell: ColourGameObjectBase, IBulletInteractable
    {
        [SerializeField] protected GameplayColour colourToMatch;
        public bool IsMatched { get; private set; }

        public UnityEvent<GameplayColour> OnColourMatched;
        public UnityEvent OnColourMisMatched;
        [SerializeField] [Tooltip("Once the color is matched it is locked in")] 
        protected bool singleMatch = false;

        [SerializeField] protected GameObject interactionLockedVisual;
        protected bool interactionLocked = false;

        protected GameplayColour currentColour;

        protected GameplayColour CurrentColour
        {
            get
            {
                return currentColour;
            }
            set
            {
                currentColour = value;
                SetObjectColour(currentColour);
                TestForColourMatch();
            }
        }

        private void Start()
        {
            CurrentColour = startingColour;
        }

        public void SetColour(GameplayColour colour)
        {
            if (interactionLocked)
                return;
            
            CurrentColour = colour;
        }

        protected void TestForColourMatch()
        {
            if (!IsMatched)
            {
                if (currentColour == colourToMatch)
                {
                    ColourMatch();
                }
            }
            else
            {
                if (currentColour != colourToMatch)
                {
                    ColourMisMatch();
                }
            }
        }

        protected virtual void ColourMatch()
        {
            IsMatched = true;
            OnColourMatched.Invoke(colourToMatch);
            if (singleMatch)
            {
                interactionLocked = true;
                interactionLockedVisual?.SetActive(true);
            }
        }

        protected virtual void ColourMisMatch()
        {
            IsMatched = false;
            OnColourMisMatched.Invoke();
        }

        public void ResetCellState()
        {
            IsMatched = false;
            ReturnToStartingColour();
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            SetColour(interactingBullet.BulletColour);
        }
    }
}
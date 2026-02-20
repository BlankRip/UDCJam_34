using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UDCJ
{
    public class ColouredPowerCell: ColourGameObjectBase, IBulletInteractable
    {
        [SerializeField] protected GameplayColour colourToMatch;
        protected bool isMatched = false;

        [SerializeField] private UnityEvent<GameplayColour> OnColourMatched;
        [SerializeField] private UnityEvent OnColourMisMatched;
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
            if (!isMatched)
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
            isMatched = true;
            OnColourMatched.Invoke(colourToMatch);
            if (singleMatch)
            {
                interactionLocked = true;
                interactionLockedVisual?.SetActive(true);
            }
        }

        protected virtual void ColourMisMatch()
        {
            isMatched = false;
            OnColourMisMatched.Invoke();
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            SetColour(interactingBullet.BulletColour);
        }
    }
}
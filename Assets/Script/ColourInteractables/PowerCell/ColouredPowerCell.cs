using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace UDCJ
{
    public class ColouredPowerCell: ColourGamebojectBase, IBulletInteractable
    {
        [SerializeField] protected GameplayColour colourToMatch;
        protected bool isMatched = false;

        [SerializeField] private UnityEvent<GameplayColour> OnColourMatched;
        [SerializeField] private UnityEvent OnColourMisMatched;

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
        }

        protected virtual void ColourMisMatch()
        {
            isMatched = false;
            OnColourMisMatched.Invoke();
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            if (interactingBullet.BulletColour == colourToMatch)
            {
                SetColour(interactingBullet.BulletColour);
            }
            Debug.Log("INteracted Failed");
        }
    }
}
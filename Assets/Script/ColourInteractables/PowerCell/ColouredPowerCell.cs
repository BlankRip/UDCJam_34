using System;
using UnityEngine;
using UnityEngine.Events;

namespace UDCJ
{
    public class ColouredPowerCell: ColourInteractableBase
    {
        [SerializeField] protected GameplayColour colourToMatch;
        protected bool isMatched = false;

        [SerializeField] private UnityEvent OnColourMatched;
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
            OnColourMatched.Invoke();
        }

        protected virtual void ColourMisMatch()
        {
            isMatched = false;
            OnColourMisMatched.Invoke();
        }
    }
}
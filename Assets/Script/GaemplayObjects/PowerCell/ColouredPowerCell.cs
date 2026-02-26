using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UDCJ
{
    public class ColouredPowerCell: ColourGameObjectBase, IBulletInteractable
    {
        [Space] [Space] [Header("Power Cell Settings")]
        [SerializeField] protected GameplayColour colourToMatch;
        public UnityEvent<GameplayColour> OnColourMatched;
        public UnityEvent OnColourMisMatched;
        public bool IsMatched { get; private set; }
        
        [Space] [Space] [Header("Power Cell behavior options")]
        [SerializeField] [Tooltip("Player can't manually deactivate this using diffrent colour bullet once it is matched")] 
        protected bool singleMatch = false;
        [SerializeField] protected GameObject interactionLockedVisual;

        [SerializeField] [Tooltip("If the power cell should get deactivated automatically after activation")]
        private bool autoDeactivate = false;
        [SerializeField] private float autoDeactivateTime = 2.0f;
        
        protected bool interactionLocked = false;
        protected float timer;
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
            timer = autoDeactivateTime;
        }

        private void Update()
        {
            if (autoDeactivate && IsMatched)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    if (singleMatch)
                    {
                        interactionLocked = false;
                        interactionLockedVisual?.SetActive(false);
                    }
                    CurrentColour = GameplayColour.Nutral;
                    ColourMisMatch();
                }
            }
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
            if (autoDeactivate)
            {
                timer = autoDeactivateTime;
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
            if (singleMatch)
            {
                interactionLocked = false;
                interactionLockedVisual?.SetActive(false);
            }
            ReturnToStartingColour();
        }

        public void OnInteract(ColouredBullet interactingBullet)
        {
            SetColour(interactingBullet.BulletColour);
        }
    }
}
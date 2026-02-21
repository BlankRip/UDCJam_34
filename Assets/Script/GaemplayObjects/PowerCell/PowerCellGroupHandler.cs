using System;
using UnityEngine;

namespace UDCJ
{
    public class PowerCellGroupHandler : MonoBehaviour
    {
        [SerializeField] private ColouredPowerCell[] groupedCells;
        private ColouredPowerCell currentActiveCell;

        private void Start()
        {
            foreach (ColouredPowerCell powerCell in groupedCells)
            {
                powerCell.OnColourMatched.AddListener(OnPowerCellMatched);
                powerCell.OnColourMisMatched.AddListener(OnPowerCellUnMatched);
            }
        }

        private void OnDestroy()
        {
            foreach (ColouredPowerCell powerCell in groupedCells)
            {
                powerCell.OnColourMatched.RemoveListener(OnPowerCellMatched);
                powerCell.OnColourMisMatched.RemoveListener(OnPowerCellUnMatched);
            }
        }

        private void OnPowerCellMatched(GameplayColour colour)
        {
            foreach (ColouredPowerCell powerCell in groupedCells)
            {
                if (powerCell.IsMatched && powerCell != currentActiveCell)
                {
                    currentActiveCell?.ResetCellState();
                    currentActiveCell = powerCell;
                    break;
                }
            }
        }

        private void OnPowerCellUnMatched()
        {
            foreach (ColouredPowerCell powerCell in groupedCells)
            {
                if (!powerCell.IsMatched && powerCell == currentActiveCell)
                {
                    currentActiveCell = null;
                    break;
                }
            }
        }
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UDCJ
{
    public class LevelExit : MonoBehaviour
    {
        [SerializeField]
        private bool isFinalLevel = false;
        
        private int playersInTrigger;
        
        [Space][Space][Header("Visuals")]
        [SerializeField] 
        private Transform bottomPiece;
        [SerializeField]
        private Transform middlePiece;
        [SerializeField]
        private Transform topPiece;

        private void Update()
        {
            bottomPiece.Rotate(Vector3.forward, Time.deltaTime * 180f);
            middlePiece.Rotate(Vector3.forward, Time.deltaTime * -90f);
            topPiece.Rotate(Vector3.forward, Time.deltaTime * -180f);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                playersInTrigger++;
                if (playersInTrigger == 2)
                {
                    if (isFinalLevel)
                    {
                        SceneManager.LoadScene(GameStatics.ThanksForPlayingSceneBuildIndex);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<Player>())
            {
                playersInTrigger--;
            }
        }
    }
}

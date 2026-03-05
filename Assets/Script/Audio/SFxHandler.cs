using System;
using UnityEngine;

namespace UDCJ
{
    public class SFxHandler : MonoBehaviour
    {
        public static SFxHandler Instance;

        private void Awake()
        {
            if(Instance == null)
                Instance = this;
            else
                Destroy(this);
        }

        [SerializeField] private AudioSource player1Source;
        [SerializeField] private AudioSource player2Source;
        [SerializeField] private AudioSource levelObjectSource;

        [Space] [Space] [Header("All sfx clips")] 
        [SerializeField] private AudioClip absorbeClip;
        [SerializeField] private AudioClip bulletLaunchClip;
        [SerializeField] private AudioClip portelTeleportClip;
        [SerializeField] private AudioClip canisterBreakClip;
        [SerializeField] private AudioClip powerCellSuccessClip;
        [SerializeField] private AudioClip powerCellResetClip;
        
        private AudioSource GetAudioSource()
        {
            return levelObjectSource;
        }
        
        private AudioSource GetAudioSource(int playerIndex)
        {
            return playerIndex == 0 ? player1Source: player2Source;
        }

        private void Start()
        {
            if(player1Source == null || player2Source == null || levelObjectSource == null)
                Destroy(this);
        }

        public void PlayAbsorbed()
        {
            GetAudioSource().PlayOneShot(powerCellSuccessClip);
        }
        
        public void PlayAbsorbed(int playerIndex)
        {
            GetAudioSource(playerIndex).PlayOneShot(absorbeClip);
        }
        
        public void PlayBulletLaunched(int playerIndex)
        {
            GetAudioSource(playerIndex).PlayOneShot(bulletLaunchClip);
        }
        
        public void PlayPortelTeleport()
        {
            GetAudioSource().PlayOneShot(portelTeleportClip);
        }
        
        public void PlayCanisterBreak()
        {
            GetAudioSource().PlayOneShot(canisterBreakClip);
        }
        
        public void PlayPowerCellMatched()
        {
            GetAudioSource().PlayOneShot(powerCellSuccessClip);
        }
        
        public void PlayPowerCellReset()
        {
            GetAudioSource().PlayOneShot(powerCellResetClip);
        }
    }
}

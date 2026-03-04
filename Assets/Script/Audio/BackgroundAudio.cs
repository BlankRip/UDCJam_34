using System;
using UnityEngine;

namespace UDCJ
{
    public class BackgroundAudio : MonoBehaviour
    {
        private static BackgroundAudio instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                this.transform.SetParent(null);
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            if(instance == this)
                instance = null;
        }
    }
}

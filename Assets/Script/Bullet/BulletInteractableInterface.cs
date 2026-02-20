using UnityEngine;

namespace UDCJ
{
    public interface IBulletInteractable
    {
        public void OnInteract(ColouredBullet interactingBullet);
    }
}
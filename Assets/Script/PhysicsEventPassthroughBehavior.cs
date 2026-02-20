using System;
using UnityEngine;

namespace UDCJ
{
    [RequireComponent(typeof(Collider))]
    public class PhysicsEventPassthroughBehavior : MonoBehaviour
    {
        public event Action<Collider> TriggerEnter;
        public event Action<Collider> TriggerExit;
        public event Action<Collision> CollisionEnter;
        public event Action<Collision> CollisionExit;
 
        private void OnCollisionEnter(Collision collision)
        {
            CollisionEnter?.Invoke(collision);
        }
 
        private void OnCollisionExit(Collision collision)
        {
            CollisionExit?.Invoke(collision);
        }
 
        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(other);
        }
 
        private void OnTriggerExit(Collider other)
        {
            TriggerExit?.Invoke(other);
        }
    }
}

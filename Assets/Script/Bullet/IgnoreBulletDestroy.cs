using UnityEngine;

namespace MyNamespace
{
    public class IgnoreBulletDestroy : MonoBehaviour, IIgnoreBulletDestroy
    {
        //Use this Monobehaviour on game object only if that game object does not have any script attached to it at all
        // else just make that script impliment the IgnoreBulletDestroy
    }

    public interface IIgnoreBulletDestroy
    {
        
    }
}

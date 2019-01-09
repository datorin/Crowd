using UnityEngine;

namespace DefaultNamespace
{
    public interface ITriggerable
    {
        void Fire(Vector3 origin, float distance);
        void Gold(Vector3 origin, float distance);
    }
}
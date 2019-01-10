using UnityEngine;

namespace DefaultNamespace
{
    public interface ITriggerable
    {
        void Fire(Vector3 origin);
        void Gold(Vector3 origin);
    }
}
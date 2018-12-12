using UnityEngine;

namespace DefaultNamespace
{
    public class ValuesManager : MonoBehaviour
    {
        public static ValuesManager Instance;

        [SerializeField] public float Tolerance;
        [SerializeField] public string IsFinished;
        
        private void Awake()
        {
            Instance = this;
        }
    }
}
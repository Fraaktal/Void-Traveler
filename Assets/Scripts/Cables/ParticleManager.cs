using UnityEngine;

namespace Cables
{
    public class ParticleManager : MonoBehaviour
    {
        public GameObject particleEmitterPrefab;
        private GameObject instance;
    
        public void Activate()
        {
            instance = Instantiate(particleEmitterPrefab, transform.position, transform.rotation);
        }

        public void Desactivate()
        {
            Destroy(instance);
        }
    }
}

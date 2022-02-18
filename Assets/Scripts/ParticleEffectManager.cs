using UnityEngine;

public class ParticleEffectManager : MonoBehaviour
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

using UnityEngine;

public class SensorLight : MonoBehaviour
{

    [SerializeField] Light pointLight;
    [SerializeField] float intensity = 3f;

    private void Start()
    {
        pointLight.intensity = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            pointLight.intensity = intensity;
        }
    }



}

using UnityEngine;

public class BubbleObstacle : MonoBehaviour
{
    public float force = 3000;
    [SerializeField] GameObject smoke;
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        source.enabled = true;
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddForce(-c.transform.forward.normalized * force);
                Destroy(gameObject);
                source.Play();
                GameObject _smoke = Instantiate(smoke, transform.position, Quaternion.identity);
                Destroy(_smoke, 1f);

            }
        }
    }

}

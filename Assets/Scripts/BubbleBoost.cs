using UnityEngine;

public class BubbleBoost : MonoBehaviour
{
    public float forwardForce = 550f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            Vector3 dir = other.transform.forward;  
            dir = dir.normalized;

            playerRb.AddForce(dir * forwardForce);

            Destroy(gameObject, 1f);
        }
    }
    
}

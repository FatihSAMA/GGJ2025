using UnityEngine;

public class BubbleObstacle : MonoBehaviour
{
    public float force = 3000;

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();

            if(rb != null)
            {

                rb.AddForce(-c.transform.forward.normalized * force);

            }
        }
    }

}

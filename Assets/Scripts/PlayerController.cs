using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsHiding { get; private set; } = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HideSpace"))
        {
            IsHiding = true;
            Debug.Log("Player is now hiding!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HideSpace"))
        {
            IsHiding = false;
            Debug.Log("Player is no longer hiding!");
        }
    }
}

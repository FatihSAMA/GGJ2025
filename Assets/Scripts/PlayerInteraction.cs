using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject interactText;
    [SerializeField] private GameObject smoke;
    [SerializeField] private float interactionRange = 2f;

    private RaycastHit hit;
    private Collider col;
    private float offset;

    private void Awake()
    {
        col = GetComponent<Collider>();
        offset = col != null ? col.bounds.extents.y : 1f;
    }

    private void Start()
    {
        interactText.SetActive(false);
    }

    private void Update()
    {
        if (TryGetInteractionHit(out hit))
        {
            HandleInteraction();
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    private bool TryGetInteractionHit(out RaycastHit hit)
    {
        Vector3 rayStart = transform.position + Vector3.up * offset;
        return Physics.Raycast(rayStart, transform.forward, out hit, interactionRange);
    }
        
    private void HandleInteraction()
    {
        if (hit.transform.CompareTag("Bubble"))
        {
            ShowInteractText();
            if (IsPressedE())
            {
                InteractWithBubble();
            }
        }
        else if (hit.transform.CompareTag("Door"))
        {
            ShowInteractText();
            if (IsPressedE())
            {
                InteractWithDoor();
            }
        }
        else if (hit.transform.CompareTag("LockedDoor"))
        {
            ShowInteractText();
            if (IsPressedE())
            {
                // TODO: kapý kilit sesi oynat
            }
        }
        else
        {
            interactText.SetActive(false);
        }
    }

    private void ShowInteractText()
    {
        interactText.SetActive(true);
    }

    private bool IsPressedE()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    private void InteractWithBubble()
    {
        GameObject _smoke = Instantiate(smoke, hit.transform.position, Quaternion.identity);
        Destroy(hit.transform.gameObject);
        Destroy(_smoke, 1f);
    }

    private void InteractWithDoor()
    {
        Animator doorAnimator = hit.transform.GetComponent<Animator>();
        if (doorAnimator != null)
        {
            doorAnimator.SetBool("open", true);
        }
    }
}

using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactText;

    private RaycastHit hit;
    private bool ray = false;

    private void Start()
    {
            interactText.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (ray && hit.transform.CompareTag("Bubble"))
        {
            interactText.gameObject.SetActive(true);

            if (isPressedE())
            {
                Destroy(hit.transform.gameObject, 1f);
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }


    private void FixedUpdate()
    {

        ray = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f);

    }


    private bool isPressedE()
    {
        if (Input.GetKeyDown(KeyCode.E)) {  return true; }
        return false;
    }


}

using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject smoke;

    private RaycastHit hit;
    private bool ray = false;
    private Collider col;
    private float offset;

    private void Awake()
    {
        offset = col != null ? col.bounds.extents.y : 1f;
    }

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (ray && hit.transform != null && hit.transform.CompareTag("Bubble"))
        {
            interactText.gameObject.SetActive(true);

            if (isPressedE())
            {
                GameObject _smoke = Instantiate(smoke, hit.transform.position, Quaternion.identity);
                Destroy(hit.transform.gameObject);
                Destroy(_smoke, 1f);
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }


    private void FixedUpdate()
    {
        Vector3 rayStart = transform.position + Vector3.up * offset;
        ray = Physics.Raycast(rayStart, transform.TransformDirection(Vector3.forward), out hit, 2f);
        //Debug.DrawRay(rayStart, transform.TransformDirection(Vector3.forward) * 2f, Color.red);

    }


    private bool isPressedE()
    {
        if (Input.GetKeyDown(KeyCode.E)) {  return true; }
        return false;
    }


}

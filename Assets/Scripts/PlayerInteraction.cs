using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject interactText;
    [SerializeField] GameObject smoke;

    private RaycastHit hit;
    private bool ray = false;
    private Collider col;
    private float offset;

    public AudioClip[] audioClips;
    AudioSource source;

    private void Awake()
    {
        offset = col != null ? col.bounds.extents.y : 1f;
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (ray && hit.transform != null)
        {

            if (hit.transform.CompareTag("Bubble"))
            {
                interactText.gameObject.SetActive(true);
                if (isPressedE())
                {
                    GameObject _smoke = Instantiate(smoke, hit.transform.position, Quaternion.identity);
                    Destroy(hit.transform.gameObject);
                    source.PlayOneShot(audioClips[0]);
                    Destroy(_smoke, 1f);
                }
            }

            if (hit.transform.CompareTag("Door"))
            {
                interactText.gameObject.SetActive(true);
                if (isPressedE())
                {
                    hit.transform.GetComponent<Animator>().SetBool("open", true);
                    hit.transform.GetComponent<BoxCollider>().isTrigger = true;
                    source.PlayOneShot(audioClips[1]);
                }
            }

            if (hit.transform.CompareTag("LockedDoor"))
            {
                interactText.gameObject.SetActive(true);
                if (isPressedE())
                {
                    //source.PlayOneShot(audioClips[2]);
                }
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
        ray = Physics.Raycast(rayStart, Camera.main.transform.forward, out hit, 2.5f);
        Debug.DrawRay(rayStart, Camera.main.transform.forward * 2.5f, Color.red);

    }


    private bool isPressedE()
    {
        if (Input.GetKeyDown(KeyCode.E)) { return true; }
        return false;
    }


}
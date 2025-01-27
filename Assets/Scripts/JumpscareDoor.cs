using System.Collections;
using UnityEngine;

public class JumpscareDoor : MonoBehaviour
{

    private Animator _animator;
    [SerializeField] private GameObject smoke;
    AudioSource source;


    private void Awake()
    {
        _animator = transform.GetChild(1).GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animator.SetBool("open", true);
            yield return new WaitForSeconds(.3f);
            source.Play();
            GameObject _smoke = Instantiate(smoke, transform.GetChild(0).transform.position, Quaternion.identity);
            Destroy(transform.GetChild(0).gameObject);
            // TODO: ses oynat
            Destroy(_smoke, 1f);
        }
    }


}

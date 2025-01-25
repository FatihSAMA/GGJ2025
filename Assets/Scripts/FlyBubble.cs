using UnityEngine;
using System.Collections;

public class FlyBubble : MonoBehaviour
{       
    

    private Animator animator;

    private void Awake() {
        animator = gameObject.GetComponent<Animator>();
    }

    private IEnumerator OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag("Player")){
            // TODO: speedi 0 a çek
            other.transform.parent = transform;
            other.transform.position = transform.position;
            other.GetComponent<Rigidbody>().isKinematic = true;
            animator.SetTrigger("isEnter");
            yield return new WaitForSeconds(2);
            other.transform.parent = null;
            Destroy(gameObject);
            other.GetComponent<Rigidbody>().isKinematic = false;
        }
    }


}

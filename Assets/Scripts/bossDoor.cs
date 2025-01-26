using System.Collections;
using UnityEngine;

public class bossDoor : MonoBehaviour
{

    private Animator aniController;

    private void Awake()
    {
        aniController = transform.GetComponent<Animator>();    
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Boss"))
        {
            Boss boss = other.gameObject.GetComponent<Boss>();
            
            if (boss != null)
            {

                boss.boss_status = Boss.bossStatus.BREAK;
                yield return new WaitForSeconds(10);
                boss.boss_status = Boss.bossStatus.SEARCH;
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player"))
        {
            yield return new WaitForSeconds(1);
            aniController.SetBool("close", true);
        }

       

    }


}

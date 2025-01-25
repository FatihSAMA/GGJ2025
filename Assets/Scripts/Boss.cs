using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private enum bossStatus{
        IDLE,       //Do nothing
        CHASE,     //setDestination player
        CATCH,     //Animation 
        SEARCH,    //setDestination random
        DOUBT,      //setDestination bubble.sound
        BREAK,      //Door break
    }

    private bossStatus boss_status = bossStatus.IDLE;
    private Vector3 initialPlayerPosition;
    private bool hasPlayerMoved = false;

    [SerializeField] Transform player;
    NavMeshAgent agent;

    void Awake(){
        agent = GetComponent<NavMeshAgent>();
        initialPlayerPosition = player.position;
    }
    void Update()
    {
        if(!hasPlayerMoved){
            CheckPlayerMovement();
        }
        switch(boss_status){
            case bossStatus.IDLE:
                break;
            case bossStatus.CHASE:
                agent.SetDestination(player.position);
                break;
            case bossStatus.CATCH:
                Debug.Log("Game Over!");
                break;
            case bossStatus.SEARCH:
                //agent.SetDestination()
                break;
            case bossStatus.DOUBT:
                break;
            case bossStatus.BREAK:
                break;
        }
    }

    void CheckPlayerMovement(){
        if (Vector3.Distance(initialPlayerPosition, player.position) > 0.1f){
            hasPlayerMoved = true;
            boss_status = bossStatus.CHASE;
            Debug.Log("Player moved, game started, boss in now chasing!");
        }
    }
}
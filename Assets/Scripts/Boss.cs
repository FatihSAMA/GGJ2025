using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

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

    [SerializeField] private Transform player;
    [SerializeField] private List<Transform> searchSpaces;
    [SerializeField] private float hideDistance = 15f;
    private NavMeshAgent agent;
    private Transform currentSearchArea;
    [SerializeField] private float chaseDistance = 10f; //Search radious threshold
    [SerializeField] private PlayerController playerController; // Take hide situation from player.
    void Awake(){
        agent = GetComponent<NavMeshAgent>();
        initialPlayerPosition = player.position;
        playerController = player.GetComponent<PlayerController>();
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (!hasPlayerMoved)
        {
            CheckPlayerMovement();
        }
        switch (boss_status){
            case bossStatus.IDLE:
                break;
            case bossStatus.CHASE:
                agent.SetDestination(player.position);

                ControlIfHide(distanceToPlayer);
                break;
            case bossStatus.CATCH:
                Debug.Log("Game Over!");
                break;
            case bossStatus.SEARCH:
                if (agent.remainingDistance < 5f)
                {
                    SelectRandomSearchArea();
                    SetRandomSearchDestination();
                }

                if (distanceToPlayer < chaseDistance)
                {
                    boss_status = bossStatus.CHASE;
                }
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

    void SearchPlayer(){
        if (agent.remainingDistance < 0.5f){
            SetRandomSearchDestination();
        }
    }

    void SelectRandomSearchArea()
    {
        // Rastgele bir search space seç
        int randomIndex = Random.Range(0, searchSpaces.Count);
        currentSearchArea = searchSpaces[randomIndex];
        Debug.Log("Boss is now searching in: " + currentSearchArea.name);
    }
    void SetRandomSearchDestination()
    {
        if (currentSearchArea == null) SelectRandomSearchArea();

        Bounds bounds = currentSearchArea.GetComponent<Collider>().bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);
        Vector3 randomPos = new Vector3(randomX, transform.position.y, randomZ);

        agent.SetDestination(randomPos);
        Debug.Log("Boss is searching at position: " + randomPos);
    }
    void ControlIfHide(float distanceToPlayer)
    {
        if (playerController.IsHiding && distanceToPlayer >= hideDistance)
        {
            boss_status = bossStatus.SEARCH;
            Debug.Log("Boss lost the player! Switching to SEARCH mode.");
        }
    }
}
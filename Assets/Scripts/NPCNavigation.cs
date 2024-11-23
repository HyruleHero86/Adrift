using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static NPCNavigation;

public class NPCNavigation : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10f;
    public float chaseRadius = 15f;
    public float idleTime = 2f;
    public List<Transform> patrolPoints;
    public AudioClip dectionClip;
    public float chaseVolume = 1.0f;
    public float patrolSpeed = 2.0f;
    public float chaseSpeed = 3.5f;

    private NavMeshAgent agent;
    private NPCSTATE currentState;
    private int currentPatrolIndex;
    private float idleTimer;
    private bool playerDetected;
    private AudioSource audioSource;

    private HidingSpot hidingSpot;

    public enum NPCSTATE
    {
        Patrolling,
        Chasing,
        Idle

    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        currentState =NPCSTATE.Patrolling; 
        currentPatrolIndex =0;
        playerDetected = false;
       
        if (patrolPoints.Count > 0 )
        {
            agent.destination = patrolPoints[currentPatrolIndex].position;
        }

        hidingSpot = player.GetComponent<HidingSpot>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case NPCSTATE.Patrolling:
                Patrol();
                break;

            case NPCSTATE.Chasing:
                Chase();
                break;

            case NPCSTATE.Idle:
                Idle();
                break;
                
                
        }
        
        DetectPlayer();
       
                
    }

    void Patrol()
    {
        agent.speed = patrolSpeed;
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentState = NPCSTATE.Idle;
            idleTimer = idleTime;
        }

        DetectPlayer();
    }

    void Chase()
    {

        if (hidingSpot.isHiding || Vector3.Distance(transform.position, player.position) > chaseRadius)
        {
            playerDetected = false;
            currentState = NPCSTATE.Patrolling;
            agent.speed = patrolSpeed;
            agent.destination = patrolPoints[currentPatrolIndex].position;
            
        }
        else
        {
            agent.destination = player.position; // Keep chasing the player
            PlayDectionSound();
        }
    }

    void Idle()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            // Move to the next patrol point
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
            agent.destination = patrolPoints[currentPatrolIndex].position;
            currentState = NPCSTATE.Patrolling;
        }
        DetectPlayer();
    }

    void DetectPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (Vector3.Distance(transform.position, player.position) <= detectionRadius && !hidingSpot.isHiding)
        {
            playerDetected = true;
            currentState = NPCSTATE.Chasing;
            agent.speed = chaseSpeed;
            PlayDectionSound();
            Debug.Log("Player detected, chasing!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            PlayDectionSound();
            Debug.Log("Player detected, chasing!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            Debug.Log("Player lost, resuming patrol.");
        }
    }

    void PlayDectionSound()
    {
        if (dectionClip != null && audioSource != null)
        {
            audioSource.clip = dectionClip;
            audioSource.volume = chaseVolume;
            audioSource.Play();
        }
    }

}




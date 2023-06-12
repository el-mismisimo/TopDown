using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    public float activationRange = 10f;

    private Transform player;
    private bool isActivated = false;
    public NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent  =GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!isActivated)
        {
            // Verificar si el jugador está dentro del rango de activación
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= activationRange)
            {
                isActivated = true;
            }
        }
        else
        {
            // Seguir al jugador
            agent.SetDestination(player.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class OrcPathfinding : MonoBehaviour
{
    public GameObject player;
    public GameObject self;
    public string myID;
    public Rigidbody2D rb;
    public bool dropsAxe;
    public bool aggro = false;
    
    public int health = 10;

    private NavMeshAgent agent;
    
    void Start()
    {
        myID = SceneManager.GetActiveScene().name + self.name;
        if (Hud.hud.enemies.Contains(myID))
        {
            Destroy(self);
        }
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (aggro)
        {
            agent.SetDestination(player.transform.position);
        }

        if (health <= 0)
        {
            self.SetActive(false);
            Hud.hud.enemies.Add(myID);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aggro = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Oh!");
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<HealthManager>().TakeDamage(1, 2);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aggro = false;
        }
    }
}

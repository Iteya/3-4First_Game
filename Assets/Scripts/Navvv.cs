using UnityEngine;
using UnityEngine.AI;

public class Navvv : MonoBehaviour
{
    [SerializeField] private Transform target;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < 20)
        {
            agent.SetDestination(target.position);
        }
    }
}

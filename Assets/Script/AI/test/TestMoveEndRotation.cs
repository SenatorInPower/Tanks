using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveEndRotation : MonoBehaviour
{

    public NavMeshAgent NavMeshAgent;
    void Start()
    {

    }
    void SetDestinationTank(Vector3 target)
    {
        NavMeshAgent.SetDestination(target);
    }
    void StopAgent()
    {
        NavMeshAgent.isStopped = true;
    }
    void SetSpeedTank(int speed)
    {
        NavMeshAgent.speed = speed;

    }
    public IEnumerator Atack()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Move()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator Update()
    {
        yield return null;
    }
}

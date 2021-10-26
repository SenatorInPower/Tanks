using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TestMoveEndRotation : MonoBehaviour
{
    public Transform pointToMove;
    public Transform pointToMove2;
    public Transform Hiro;
    public NavMeshAgent NavMeshAgent;
    public BoxCollider territory;

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
    [Button]
    void testRot()
    {
        StartCoroutine(Update());
    }
    //transform.RotateAround(pivotPoint, Vector3.up, 90);
    public float angleX;
    public float angleY;
    public float radius = 10;
    IEnumerator Rotation()
    {
        Vector3 RotTo = Hiro.position - transform.position;
        Quaternion rotTank = transform.rotation;
        //   transform.LookAt(RotTo);
        Quaternion targetRotation = Quaternion.LookRotation(RotTo);
        float timeLerp = 0;
        while (true)
        {
            timeLerp += Time.deltaTime / 3;


            transform.rotation = Quaternion.Lerp(rotTank, targetRotation, timeLerp); ;
            if (timeLerp > 1)
            {
                print("hit");
                yield break;
            }
            yield return null;
        }
    }

    public IEnumerator Move(Vector3 to)
    {
        SetDestinationTank(to);
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            if (NavMeshAgent.remainingDistance<15)
            {
                yield break;
             
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator Update()
    {
        while (true)
        {
            yield return StartCoroutine(Move(RandomPositionInTerritory()));
            yield return StartCoroutine(Rotation());
        }
    }
    internal Vector3 RandomPositionInTerritory()
    {
        Vector3 posRendom = new Vector3(Random.Range(territory.bounds.min.x, territory.bounds.max.x), transform.position.y, Random.Range(territory.bounds.min.z, territory.bounds.max.z));
        return posRendom;
    }
}

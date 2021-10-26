using Script.AI.Controller;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    const byte koefDistSpeed = 1;
    internal byte accuracy = 15;   //random distance from the target
    public Transform target; public short damage; public short distanse;
    public Transform startsVector;
    void Start()
    {

    }
    [Button]
    void testShut(/*Transform target, short damage, short distanse*/)
    {
        StartCoroutine(MoveTo(target.position, damage, distanse));
    }
    public IEnumerator MoveTo(Vector3 target, short damage, short distanse)
    {

        transform.position = startsVector.position;

        Vector3 startPosBall = transform.position;
        float distense_Time = Vector3.Distance(transform.position, target);
        distense_Time = Mathf.Lerp(0, 1, LevelInfo.MaxDistanseShut / distense_Time) * koefDistSpeed;
        float TimeInterpolation = 0;
        Vector3 targetNew = RendomPosNearTarget(ShutDistensePoint(distanse, target));
        while (true)
        {
            TimeInterpolation += Time.deltaTime * distense_Time;
            transform.position = Vector3.Lerp(startPosBall, targetNew, TimeInterpolation);
            if (TimeInterpolation > 1)
            {
                yield break;
            }
            yield return null;
        }
    }
    private Vector3 ShutDistensePoint(short distense, Vector3 target)
    {
        Vector3 DistShut;
        if (distense < Vector3.Distance(target, transform.position))
        {
            DistShut = target;
        }
        else
        {
             DistShut=(target - transform.position).normalized;
            DistShut = DistShut * distense;
        }
      
    
        return DistShut;
    }
    private Vector3 RendomPosNearTarget(Vector3 target)
    {
        Vector3 pos = new Vector3(Random.Range(target.x - accuracy, target.x + accuracy), target.y - 1, Random.Range(target.z - accuracy, target.z + accuracy));
        return pos;
    }

}

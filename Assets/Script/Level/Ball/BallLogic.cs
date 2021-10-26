using Script.AI.Controller;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    const byte koefDistSpeed = 3;
    internal byte accuracy = 6;   //random distance from the target
   // public Transform target; public short damage; public short distanse;




    [SerializeField]
    private Transform startsVector;
    internal void Init(Transform startsVector)
    {
        this.startsVector = startsVector;
    }


  public  void Shut(Vector3 target, short damage, short distanse)
    {
        StartCoroutine(MoveTo(target, damage, distanse));
    }
    public IEnumerator MoveTo(Vector3 target, short damage, short MaxDistenseTank)  //������ �������� � ��������� ������� ����� ������ �������� �����������
    {
        transform.position = startsVector.position;    // ������� ������ � ���� 

        Vector3 startPosBall = transform.position;   //��������� ��������� �������
        float distense_Time = Vector3.Distance(target, startPosBall);  //���������� �������� �� ������ �����

        float TimeInterpolation = 0;      //���������� ������������ �� ������� 
        Vector3 targetNew = RendomPosNearTarget(ShutDistensePoint(MaxDistenseTank, target, distense_Time));      //��������� ������� ������� �� ����

        distense_Time = Mathf.Lerp(0.1f,1, distense_Time/ LevelInfo.MaxDistanseShut) ; //���������� �������� ������������ � ������ ���������
                                                                                                     //( LevelInfo.MaxDistanseShut ������������ ��������� � ������ ������� �����)
        while (true)
        {
            TimeInterpolation += Time.deltaTime / distense_Time;
            transform.position = Vector3.Lerp(startPosBall, targetNew, TimeInterpolation);
            if (TimeInterpolation > 1)
            {
                yield break;
            }
            yield return null;
        }
    }
    private Vector3 ShutDistensePoint(short MaxDistenseTank, Vector3 target, float distenseToTarget)
    {
        Vector3 DistShut;                                                       //���� ��������� �� ���� ������ ������������ ��������� �������� � ��������� �����, �� �������� � ���� �� � ������� ���������

        if (MaxDistenseTank > distenseToTarget)
        {
            DistShut = target;
        }
        else
        {

            float dist = Mathf.Lerp(0.1f,1, MaxDistenseTank / distenseToTarget);
            DistShut = target;
            DistShut *= dist;
            DistShut = new Vector3(DistShut.x, target.y, DistShut.z);

        }


        return DistShut;
    }
    private Vector3 RendomPosNearTarget(Vector3 target)         // ���������� �������� ����� ����� �����,� ������ ������� � ����
    {
        Vector3 pos = new Vector3(Random.Range(target.x - accuracy, target.x + accuracy), target.y - 1, Random.Range(target.z - accuracy, target.z + accuracy));
        return pos;
    }

}

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
    public IEnumerator MoveTo(Vector3 target, short damage, short MaxDistenseTank)  //снаряд движется в рандомную позицию возле игрока имитируя погрешность
    {
        transform.position = startsVector.position;    // вернули снаряд и дулу 

        Vector3 startPosBall = transform.position;   //сохраняем стартовую позицию
        float distense_Time = Vector3.Distance(target, startPosBall);  //определяем растоние до бьекта чтобы

        float TimeInterpolation = 0;      //переменная интерполяции по времени 
        Vector3 targetNew = RendomPosNearTarget(ShutDistensePoint(MaxDistenseTank, target, distense_Time));      //случайная позиция стреляя по цели

        distense_Time = Mathf.Lerp(0.1f,1, distense_Time/ LevelInfo.MaxDistanseShut) ; //определяем скорость интерполяции с учетом дистанции
                                                                                                     //( LevelInfo.MaxDistanseShut максимальное растояние с учетом размера карты)
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
        Vector3 DistShut;                                                       //если дистанция до цели меньше максимальнйо дистанции задданой в состоянии танка, то стреляем в танк но с меньшим растояним

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
    private Vector3 RendomPosNearTarget(Vector3 target)         // вычисление случайно точки возле танка,с шансом попасть в танк
    {
        Vector3 pos = new Vector3(Random.Range(target.x - accuracy, target.x + accuracy), target.y - 1, Random.Range(target.z - accuracy, target.z + accuracy));
        return pos;
    }

}

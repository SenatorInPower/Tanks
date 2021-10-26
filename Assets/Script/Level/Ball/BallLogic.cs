using Script.AI.Controller;
using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    const byte koefDistSpeed = 1;
    internal byte accuracy = 15;   //random distance from the target
    public Transform target; public short damage; public short distanse;




    [SerializeField]
    private Transform startsVector;
    internal void Init(Transform startsVector)
    {
        this.startsVector = startsVector;
    }

    [Button]
    void testShut(/*Transform target, short damage, short distanse*/)
    {
        StartCoroutine(MoveTo(target.position, damage, distanse));
    }
    public IEnumerator MoveTo(Vector3 target, short damage, short distanse)  //снаряд движется в рандомную позицию возле игрока имитируя погрешность
    {

        transform.position = startsVector.position;    // вернули снаряд и дулу 

        Vector3 startPosBall = transform.position;   //сохраняем стартовую позицию
        float distense_Time = Vector3.Distance(transform.position, target);  //определяем растоние до бьекта чтобы
        distense_Time = Mathf.Lerp(0, 1, LevelInfo.MaxDistanseShut / distense_Time) * koefDistSpeed; //определяем скорость интерполяции с учетом дистанции
                                                                                                     //( LevelInfo.MaxDistanseShut максимальное растояние с учетом размера карты)
                                                                                                     //умножая на коэффециент скорости       
  
        float TimeInterpolation = 0;      //переменная интерполяции по времени 
        Vector3 targetNew = RendomPosNearTarget(ShutDistensePoint(distanse, target));      //случайная позиция стреляя по цели
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
        Vector3 DistShut;                                                       //если дистанция до цели меньше максимальнйо дистанции задданой в состоянии танка, то стреляем в танк но с меньшим растояним
        if (distense > Vector3.Distance(target, transform.position))
        {
            DistShut = target;
        }
        else
        {
            DistShut = (target - transform.position).normalized;
            DistShut = DistShut * distense;
        }


        return DistShut;
    }
    private Vector3 RendomPosNearTarget(Vector3 target)         // вычисление случайно точки возле танка,с шансом попасть в танк
    {
        Vector3 pos = new Vector3(Random.Range(target.x - accuracy, target.x + accuracy), target.y - 1, Random.Range(target.z - accuracy, target.z + accuracy));
        return pos;
    }

}

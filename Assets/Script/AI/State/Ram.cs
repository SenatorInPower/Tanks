using Script.AI.Controller;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
using UnityEngine.AI;

namespace Script.AI.States
{
    public class Ram : ITankState
    {
       
       
        private TankState tank;
        private WaitForSeconds wait = new WaitForSeconds(0.5f);


        public Ram(TankState tank)
        {
           this.tank = tank;   
        }



        public IEnumerator Update(MonoBehaviour myMonoBehaviour) //стреляет на определенной дистации и меняет позицию
        {

            while (true)
            {
                yield return myMonoBehaviour.StartCoroutine(Move(tank.levelInfo.RandomPositionInTerritory()));
                yield return myMonoBehaviour.StartCoroutine(Rotation(tank.BallAtack.transform, tank.tankStats.hiroPosition.TransformHiro.position));
                yield return myMonoBehaviour.StartCoroutine(Atack());
            }
        }

        public IEnumerator Atack()
        {
            // стреляет на своей дистанции если попадут в ответ ,то сменить позицию
            tank.BallAtack.Atack(tank.tankStats.hiroPosition.TransformHiro.position, tank.tankStats.Damage, tank.tankStats.Distanse);
            yield break;
        }

        IEnumerator Rotation(Transform rotationElement, Vector3 target)
        {
            Vector3 rotationTo = target - rotationElement.position;
            Quaternion rotationTank = rotationElement.rotation;

            Quaternion targetRotation = Quaternion.LookRotation(rotationTo);
            float timeLerp = 0;
            while (true)
            {
                timeLerp += Time.deltaTime;


                rotationElement.rotation = Quaternion.Lerp(rotationTank, targetRotation, timeLerp); ;
                if (timeLerp > 1)
                {

                    yield break;
                }
                yield return null;
            }
        }

        public IEnumerator Move(Vector3 targetPoint)
        {
            SetDestinationTank(targetPoint);
            yield return new WaitForSeconds(0.1f);
            while (true)
            {
                if (tank.tankStats.NavMeshAgent.remainingDistance < 15)
                {
                    yield break;

                }
                yield return wait;
            }
        }
        void SetDestinationTank(Vector3 target)
        {
            tank.tankStats.NavMeshAgent.SetDestination(target);
        }
        void StopAgent()
        {
            tank.tankStats.NavMeshAgent.isStopped = true;
        }
    }
}
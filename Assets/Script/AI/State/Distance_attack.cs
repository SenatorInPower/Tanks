using Script.AI.Controller;
using System.Collections;
using UnityEngine;

namespace Script.AI.States
{
    public class Distance_attack : ITankState
    {

        private TankState tank;
        private WaitForSeconds wait = new WaitForSeconds(0.5f);

        public Distance_attack(TankState tank)
        {
            this.tank = tank;
        }
        void MoveToPoint()
        {

        }
        public IEnumerator Update(MonoBehaviour myMonoBehaviour) //стреляет на определенной дистации и меняет позицию
        {

            while (true)
            {
                yield return myMonoBehaviour.StartCoroutine(Move(tank.levelInfo.RandomPositionInTerritory()));
                for (int i = 0; i < tank.levelInfo.DistenseAtackCount(); i++)
                {
                    yield return myMonoBehaviour.StartCoroutine(Rotation(tank.BallAtack.transform, tank.tankStats.hiroPosition.TransformHiro.position));
                    yield return myMonoBehaviour.StartCoroutine(Atack());
                }

            }
        }

        public IEnumerator Atack()
        {
            short DistAtackLenght = 0;
            if (tank.levelInfo.MinDistenseOveride() != 0)
            {
                DistAtackLenght = tank.levelInfo.MinDistenseOveride();
            }
            else
            {
                DistAtackLenght = tank.tankStats.Distanse;
            }
            // стреляет на своей дистанции если попадут в ответ ,то сменить позицию
            tank.BallAtack.Atack(tank.tankStats.hiroPosition.TransformHiro.position, tank.tankStats.Damage, DistAtackLenght);
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

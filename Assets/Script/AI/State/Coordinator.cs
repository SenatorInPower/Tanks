
using Script.AI.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.AI.States
{

    public class Coordinator : ITankState
    {

      
        static short tankCoordinatorCount;
        static bool isLead;

        private TankState tank;
        private List<TankState> _tanks;
        private WaitForSeconds wait = new WaitForSeconds(0.5f);

        private List<TankState> tanks { get { if (_tanks == null) { _tanks = new List<TankState>(); } return _tanks; } set => _tanks = value; }


        public Coordinator(TankState tankCoordinator)
        {
            this.tank = tankCoordinator;

            if (tank.levelInfo.LeadID() == tankCoordinatorCount)
            {
                isLead = true;

            }
            else
            {
                isLead = false;
            }
            tanks.Add(this.tank);
            tankCoordinatorCount++;
        }
        ~Coordinator()
        {
            tankCoordinatorCount--;
            tanks.Remove(this.tank);

        }


        public IEnumerator Update(MonoBehaviour myMonoBehaviour)
        {

            while (true)
            {
                if (isLead)
                {
                    yield return myMonoBehaviour.StartCoroutine(Move(tank.tankStats.hiroPosition.TransformHiro.position));
                }
                else
                {

                }


            }
        }

        public IEnumerator Atack()
        {

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
                if (tank.tankStats.NavMeshAgent.remainingDistance < 2)
                {
                    yield break;
                }
                yield return wait;
            }
        }
        public IEnumerator MoveSquad(Transform lead)
        {
            SetDestinationTank(lead.position);
            yield return new WaitForSeconds(0.1f);
            while (true)
            {
                if (tank.tankStats.NavMeshAgent.remainingDistance < 3)
                {
                    yield break;
                }
                else
                {
                    SetDestinationTank(lead.position);
                }
                yield return new WaitForSeconds(0.5f);
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
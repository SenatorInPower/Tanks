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
        public Ram(TankState tank)
        {
           this.tank = tank;   
        }


       
        void SetDestinationTank(Vector3 target)
        {
            tank.tankStats.NavMeshAgent.SetDestination(target);
        }
        void StopAgent()
        {
            tank.tankStats.NavMeshAgent.isStopped = true;
        }
        public IEnumerator Update()
        {
            yield return null; //двигается на врага и таранит его
        }

        public IEnumerator Atack()
        {
            throw new System.NotImplementedException(); // таранит врага
        }

        public IEnumerator Move()
        {
            while (true)  //двигается на врага 
            {
                if (!(NavMeshPathStatus.PathComplete == tank.tankStats.NavMeshAgent.pathStatus))
                {
                    SetDestinationTank(tank.tankStats.hiroPosition.TransformHiro.position);
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}
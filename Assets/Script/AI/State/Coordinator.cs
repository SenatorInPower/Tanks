
using Script.AI.Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Script.AI.States
{

    public class Coordinator : ITankState
    {

       private TankState tank;
        static bool theLead;
        //private static Coordinator Coordinators { get; set; }
        static List<TankState> tanks;


        public Coordinator(List<TankState> tanks, TankState tankCoordinator)
        {

            this.tank = tankCoordinator;

        }
      

    
        void SetDestinationTank(Vector3 target)
        {
            tank.tankStats.NavMeshAgent.SetDestination(target);
        }
        void StopAgent()
        {
            tank.tankStats.NavMeshAgent.isStopped=true;
        }
        public IEnumerator Update()
        {
            yield return null;  //���� �������� => ���������� �����
        }

        public IEnumerator Atack()
        {
             //�������� ����� ���������, ����� ������������ ������ �������
        }

        public IEnumerator Move()
        {
           //��������� � ������� ����� ����� �������
           //���������� � ����������� ��������� ������� �� �����
        }
    }
}
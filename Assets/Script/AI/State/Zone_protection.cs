using Script.AI.Controller;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace Script.AI.States
{
    public class Zone_protection : ITankState
    {   
        
        private TankState tank;
        public Zone_protection(TankState tank)
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
        public IEnumerator Atack()
        {
            throw new System.NotImplementedException();  //�������� ����� �������� � ���� ��
                                                         //���� ��������� ,���� ��
                                                         //������� �������� ������ ���
                                                         //� ������� ������
        }

        public IEnumerator Move()
        {
            throw new System.NotImplementedException();// ��������� � �������������� ��������
        }

        public IEnumerator Update()
        {
            yield return null;// ������ � ������� , ��������,������ �������
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Script.AI.Controller;
using TankInterface;
using UnityEngine;
namespace Script.AI.States
{
    public class Distance_attack : ITankState
    {
       
        private TankState tank;
        public Distance_attack(TankState tank)
        {         
            this.tank = tank;
        }
        void MoveToPoint()
        {

        }
        public IEnumerator Update()
        {
            throw new System.NotImplementedException();//стреляет на определенной дистации и меняет позицию
        }

        public IEnumerator Atack()
        {
            throw new System.NotImplementedException();// стреляет на своей дистанции если попадут в ответ ,то сменить позицию
        }

        public IEnumerator Move()
        {
            throw new System.NotImplementedException();// меняет позицию после попадания
        }
    }
}

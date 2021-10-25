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
            throw new System.NotImplementedException();
        }
    }
}

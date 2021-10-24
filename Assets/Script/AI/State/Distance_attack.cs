using Assets.Script.AI;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace TankState
{
    public class Distance_attack : ITankState, IHP, IAtack, IMove
    {
        private Tank tank;
        public Distance_attack(Tank tank)
        {
            this.tank = tank;
        }

        public IEnumerator Update()
        {
            throw new System.NotImplementedException();
        }
    }
}

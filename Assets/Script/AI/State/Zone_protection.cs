using Assets.Script.AI;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace TankState
{
    public class Zone_protection : ITankState, IHP, IAtack, IMove
    {

        private Tank tank;
        public Zone_protection(Tank tank)
        {
            this.tank = tank;
        }

        public IEnumerator Update()
        {
            
        }
    }
}
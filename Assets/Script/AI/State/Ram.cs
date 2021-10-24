using Assets.Script.AI;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace TankState
{
    public class Ram : ITankState, IHP, IMove
    {
        private Tank tank;
        public Ram(Tank tank)
        {
            this.tank = tank;   
        }

        IEnumerator ITankState.Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
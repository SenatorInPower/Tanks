using Script.AI.Controller;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace Script.AI.States
{
    public class Ram : ITankState
    {
       

        private TankState tank;
        public Ram(TankState tank)
        {
            this.tank = tank;   
        }

        IEnumerator ITankState.Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
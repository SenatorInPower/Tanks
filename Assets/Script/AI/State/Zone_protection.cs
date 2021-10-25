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

        public IEnumerator Update()
        {
            yield return null;
        }
    }
}
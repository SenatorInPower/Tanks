using Assets.Script.AI;
using System;
using System.Collections;
using System.Collections.Generic;
using TankInterface;

namespace TankState
{
    public class Coordinator : ITankState
    {
       
        private Tank tank;
        static bool theLead;
        //private static Coordinator Coordinators { get; set; }
        static List<Tank> tanks;
     

        public Coordinator(List<Tank> tanks, Tank tankCoordinator )
        {
            
            this.tank = tankCoordinator;
          
        }

        public IEnumerator Update()
        {
            yield return null;
        }
    }
}
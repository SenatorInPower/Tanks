
using Script.AI.Controller;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Script.AI.States
{
    public class Coordinator : ITankState
    {
       
        private TankState tank;
        static bool theLead;
        //private static Coordinator Coordinators { get; set; }
        static List<TankState> tanks;
     

        public Coordinator(List<TankState> tanks, TankState tankCoordinator )
        {
            
            this.tank = tankCoordinator;
          
        }

        public IEnumerator Update()
        {
            yield return null;
        }
    }
}
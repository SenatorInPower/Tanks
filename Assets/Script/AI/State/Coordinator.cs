using Assets.Script.AI;
using System.Collections;
using System.Collections.Generic;
using TankInterface;

namespace TankState
{
    public class Coordinator : ITankState, IHP, IAtack, IMove
    {
        private List<Collision> collisions;
        private Tank tank;
        static bool theLead;
        //private static Coordinator Coordinators { get; set; }
        static List<Tank> tanks;
        public Coordinator(List<Tank> tanks, Tank tankCoordinator,List<Collision> collisions)
        {
            this.tank = tankCoordinator;
            this.collisions = collisions;
        }

        public IEnumerator Update()
        {
            yield return null;
        }
    }
}
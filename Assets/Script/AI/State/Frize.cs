using Script.AI;
using Script.AI.Controller;
using System.Collections;
using UnityEngine;

namespace Script.AI.States
{
    public class Frize : ITankState
    {
        private TankState tank;

        public Frize(TankState tank)
        {
            this.tank = tank;
        }

        public IEnumerator Atack()
        {
           yield break;

        }

        public IEnumerator Move()
        {
           yield break;
        }

        public IEnumerator Update()
        {
           yield break;

        }
    }
}
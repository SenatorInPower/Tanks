using Assets.Script.AI;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace TankState
{
    public class Distance_attack : ITankState, IHP
    {
        private int _HP;
        public int HP { get => _HP; set => _HP = value; }

        private int _maxHP;
        public int MaxHP { get => _maxHP; set => _maxHP = value; }
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

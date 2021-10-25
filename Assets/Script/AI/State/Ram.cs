using Assets.Script.AI;
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace TankState
{
    public class Ram : ITankState, IHP
    {
        private int _HP;
        public int HP { get => _HP; set => _HP = value; }

        private int _maxHP;
        public int MaxHP { get => _maxHP; set => _maxHP = value; }

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
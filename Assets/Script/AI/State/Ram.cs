
using System.Collections;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
namespace Script.AI.States
{
    public class Ram : ITankState, IHP
    {
        private int _HP;
        public int HP { get => _HP; set => _HP = value; }

        private int _maxHP;
        public int MaxHP { get => _maxHP; set => _maxHP = value; }

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
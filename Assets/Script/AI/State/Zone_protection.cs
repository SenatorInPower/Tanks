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

        public IEnumerator Atack()
        {
            throw new System.NotImplementedException();  //стреляет после возьезда в зону на
                                                         //свою дистанцию ,если не
                                                         //дастает стреляет просто так
                                                         //в сторону игрока
        }

        public IEnumerator Move()
        {
            throw new System.NotImplementedException();// двигается к оборонительным позициям
        }

        public IEnumerator Update()
        {
            yield return null;// пришел в позицию , стреляет,меняет позицию
        }
    }
}
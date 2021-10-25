using Assets.Script.AI.Controller;
using Controller.CollisionControl;
using Script.AI;
using System;
using TankInterface;
using UnityEngine;

namespace Script.AI.Controller
{
    public struct Stats
    {
        public int Speed;
        public int HP;
        public int Damage;
    }

    public struct DamageForElement
    {
        public int LeftCaterpillar;
        public int RightCaterpillar;
        public int Frame;
        public int Tower;
    }

    public class TankStats : IDisposable, IHP, IMove
    {
        

        [SerializeField]
        private DamageForElement damageForElement;

        [SerializeField]
        private Stats stats;

        private Action<DamageType, int> actionDamage;

 

        public int Speed { get => stats.Speed; set => stats.Speed = value; }
        public int HP { get => stats.HP; set { stats.HP = value; if (stats.HP < 1) { Dead(); } } }
        public int MaxHP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        public TankStats(Stats stats, DamageForElement damageForElement, CollisionAction collisionAction) 
        {

            this.stats = stats;
            this.damageForElement = damageForElement;
            actionDamage += actionDamage;
            collisionAction.Init(damageForElement, actionDamage);

        }

    

        public void Dispose()
        {
            actionDamage -= actionDamage;
        }

        void ActionDamage(DamageType damageType, int damage)
        {
            switch (damageType)
            {
                case DamageType.Projectile:
                    stats.HP = -damage;
                    break;
                case DamageType.Ram:
                    stats.HP = 0;
                    break;
                default:
                    break;
            }
        }
        void Dead()
        {

        }
    }
}
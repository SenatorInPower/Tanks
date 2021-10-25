using Controller.CollisionControl;
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
        private DamageForElement DamageForElement;

        [SerializeField]
        private Stats Stats;

        private Action<DamageType, int> actionDamage;


        public int Speed { get => Stats.Speed; set => Stats.Speed = value; }
        public int HP { get => Stats.HP; set { Stats.HP = value; if (Stats.HP < 1) { Dead(); } } }
        public int MaxHP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TankStats(Stats Stats, DamageForElement DamageForElement, CollisionAction collisionAction)
        {

            this.Stats = Stats;
            this.DamageForElement = DamageForElement;
            actionDamage += actionDamage;
            collisionAction.Init(DamageForElement, actionDamage);

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
                    Stats.HP = -damage;
                    break;
                case DamageType.Ram:
                    Stats.HP = 0;
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
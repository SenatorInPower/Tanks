using Controller.CollisionControl;
using System;
using TankInterface;
using UnityEngine;
using UnityEngine.AI;

namespace Script.AI.Controller
{
    public struct Stats
    {
        public short Speed;
        public short HP;
        public short Damage;
    }

    public struct DamageForElement
    {
        public byte LeftCaterpillar;
        public byte RightCaterpillar;
        public byte Frame;
        public byte Tower;
    }

    public class TankStats : IDisposable, IHP, IMove, IDamage
    {
        internal IHiroPosition hiroPosition;
        //[SerializeField]
        //private DamageForElement DamageForElement;
        internal NavMeshAgent NavMeshAgent;
        [SerializeField]
        private Stats Stats;

        private Action<DamageType, int> actionDamage;


        public short Speed { get => Stats.Speed; set => Stats.Speed = value; }
        public short HP { get => Stats.HP; set { Stats.HP = value; if (Stats.HP < 1) { Dead(); } } }
        public short MaxHP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public short Damage { get => Stats.Damage; set => Stats.Damage = value; }


        public TankStats(Stats Stats, NavMeshAgent NavMeshAgent, IHiroPosition hiroPosition, DamageForElement DamageForElement, CollisionAction collisionAction)
        {
            this.NavMeshAgent = NavMeshAgent;
            this.Stats = Stats;
            //  this.DamageForElement = DamageForElement;
            actionDamage += actionDamage;
            collisionAction.Init(DamageForElement, actionDamage);

        }
        public void Dispose()
        {
            actionDamage -= actionDamage;
        }

        void ActionDamage(DamageType damageType, short damage)
        {
            switch (damageType)
            {
                case DamageType.Projectile:
                    Stats.HP = (short)-damage;
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
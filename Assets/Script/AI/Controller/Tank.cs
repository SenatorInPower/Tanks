using Controller.CollisionControl;
using System;
using TankInterface;
using TankState;
using UnityEngine;
public enum State
{
    Coordinator,
    Distance_attack,
    Ram,
    Zone_protection
}
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
namespace Assets.Script.AI
{
    public class Tank : IDisposable, IHP, IMove
    {


        [SerializeField]
        private DamageForElement damageForElement;

        [SerializeField]
        private Stats stats;

        [SerializeField]
        private State condition;

        private Action<DamageType, int> actionDamage;

        private ITankState _IState;

        public int Speed { get => stats.Speed; set => stats.Speed = value; }
        public int HP { get => stats.HP; set { stats.HP = value; if (stats.HP < 1) { Dead(); } } }
        public int MaxHP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Tank(State state,Stats stats, DamageForElement damageForElement, CollisionAction collisionAction)
        {
            condition = state;
            this.stats = stats;
            this.damageForElement = damageForElement;
            actionDamage += actionDamage;
            collisionAction.Init(damageForElement, actionDamage);
            StateInit(state);
        }

        
        void SetStait(ITankState tankState)
        {
            _IState = tankState;
        }
        void StateInit(State state)
        {
            switch (state)
            {
                case State.Coordinator:
                    _IState = new Distance_attack(this);
                    break;
                case State.Distance_attack:
                    _IState = new Coordinator(list, this,  );
                    break;
                case State.Ram:
                    _IState = new Ram(this);
                    break;
                case State.Zone_protection:
                    _IState = new Zone_protection(this);
                    break;
                default:
                    break;
            }
        }
        void Dead()
        {

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

    }
}
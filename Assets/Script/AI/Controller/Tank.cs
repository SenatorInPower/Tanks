using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TankInterface;
using TankState;
using UnityEngine;
public enum State {
    Coordinator,
    Distance_attack,
    Ram,
    Zone_protection
}

namespace Assets.Script.AI
{
    public class Tank
    {     
        private static List<Tank> list = new List<Tank>();

        [SerializeField]
        private State State;

        ITankState _IState;
        // Use this for initialization
        void Awake()
        {
            StateInit();
        }
        void SetStait(ITankState tankState)
        {
            _IState = tankState;
        }
        void StateInit()
        {
            list.Add(this);

            switch (State)
            {
                case State.Coordinator:
                    _IState = new Distance_attack(this);
                    break;
                case State.Distance_attack:
                    _IState = new Coordinator(list,this, InitCollision());
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
        List<Collision> InitCollision(GameObject root)
        {
            List<Collision> collisions = new List<Collision>();
            collisions=root.GetComponentsInChildren<Collision>().ToList();
            return collisions;
        }
    }
}
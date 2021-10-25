using Controller.CollisionControl;
using Script.AI.States;
using System;
using TankInterface;
using UnityEngine;

namespace Script.AI
{
    public enum State
{
    Coordinator,
    Distance_attack,
    Ram,
    Zone_protection
}


    public class TankState
    {


       
        [SerializeField]
        private State condition;

       

        private ITankState _IState;


        public TankState(State state)
        {
            condition = state;
            
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
      
      

    }
}
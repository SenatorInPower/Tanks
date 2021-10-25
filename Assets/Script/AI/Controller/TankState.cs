using Script.AI.States;
using UnityEngine;

namespace Script.AI.Controller
{
    public enum State
    {
        Coordinator,
        Distance_attack,
        Ram,
        Zone_protection,
        Frize
    }


    public class TankState
    {
        [SerializeField]
        private State State;

        internal TankStats tankStats;

        internal LevelInfo levelInfo;

        internal ITankState _IState;


        public TankState(State State, TankStats tankStats, LevelInfo levelInfo)
        {
            this.State = State;
            this.tankStats = tankStats;
            this.levelInfo = levelInfo;

            StateInit(State);
        }


        void SetStait(ITankState tankState)
        {
            _IState = tankState;
        }
        public void StateInit(State state)
        {
            switch (state)
            {
                case State.Coordinator:
                    _IState = new Distance_attack(this);
                    break;
                case State.Distance_attack:
                    // _IState = new Coordinator(list, this,  );
                    break;
                case State.Ram:
                    _IState = new Ram(this);
                    break;
                case State.Zone_protection:
                    _IState = new Zone_protection(this);
                    break;
                    case State.Frize:
                        _IState = new Frize(this);
                default:
                    break;
            }
        }





    }
}
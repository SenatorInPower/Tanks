using Script.AI.States;
using UnityEngine;

namespace Script.AI.Controller
{
    public enum State
    {    
        Distance_attack,
        Ram,
        Zone_protection,
        Coordinator,
        Frize
    }


    public class TankState
    {
        [SerializeField]
        private State State;

        internal TankStats tankStats;

        internal LevelInfo levelInfo;

        private ITankState _IState;

        internal BallAtack BallAtack;
        public TankState(State State, TankStats tankStats, LevelInfo levelInfo)
        {
            this.State = State;
            this.tankStats = tankStats;
            this.levelInfo = levelInfo;
            BallAtack.CreateListBall();
            StateInit(State);
        }


       private void SetStait(ITankState tankState)
        {
            _IState = tankState;
        }
        internal void StateInit(State state)
        {
            switch (state)
            {
                case State.Distance_attack:
                     _IState = new Distance_attack(this);
                    break;
                case State.Ram:
                    _IState = new Ram(this);
                    break;
                case State.Zone_protection:
                    _IState = new Zone_protection(this);
                    break;
                case State.Coordinator:
                    _IState = new Coordinator(this);
                    break;
                case State.Frize:
                    _IState = new Frize(this);
                    break;
                default:
                    break;
            }
        }

        internal void Update(MonoBehaviour myMonoBehaviour)
        {
            myMonoBehaviour.StartCoroutine(_IState.Update(myMonoBehaviour));
        }



    }
}
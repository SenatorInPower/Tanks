using Controller.CollisionControl;
using Script.AI.Controller;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using TankInterface;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.AI.Controller
{
    public class AITankCreator : SerializedMonoBehaviour
    {

        internal IHiroPosition hiroPosition;

        internal static Dictionary<byte, TankState> EnemysTanks;

        [SerializeField]
        private Dictionary<State, byte> CriateEnemysTankAtState;

        [SerializeField]
        private LevelInfo LevelInfo;

        [SerializeField]
        private GameObject TankEnemys;

        //[SerializeField]
        //[Range(0f, 10f)]
        //private int countEnemys;

        [BoxGroup("Stats")]
        [ShowIf("NullCheck")]

        [SerializeField]
        private DamageForElement damageForElement;

        [BoxGroup("Stats")]
        [ShowIf("NullCheck")]
        [SerializeField]
        private Stats stats;

        private bool NullCheck()
        {
            if (TankEnemys != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Button]
        void SetState(State state, byte tankID)
        {
            if (EnemysTanks[tankID] != null)
            {
                EnemysTanks[tankID].StateInit(state);
            }
        }

        void CriateEnemys()
        {
            EnemysTanks = new Dictionary<byte, TankState>();
            byte tankID = 0;
            foreach (var item in CriateEnemysTankAtState)
            {
                for (byte i = 0; i < item.Value; i++)
                {


                    GameObject enemysTank = Instantiate(TankEnemys, LevelInfo.RandomPositionInTerritory(), Quaternion.identity);
                    CollisionAction collisionAction = enemysTank.GetComponent<CollisionAction>();
                    NavMeshAgent navMeshAgent = enemysTank.GetComponent<NavMeshAgent>();
                    TankStats tankStats = new TankStats(stats, navMeshAgent, hiroPosition, damageForElement, collisionAction);
                    TankState tankState = new TankState(item.Key, tankStats, LevelInfo);

                    tankID++;
                    EnemysTanks.Add(tankID, tankState);
                }
            }

        }
        private void UpdateAllTank()
        {
            foreach (TankState tank in EnemysTanks.Values)
            {
                StartCoroutine(tank._IState.Update());
            }
        }

    }
}
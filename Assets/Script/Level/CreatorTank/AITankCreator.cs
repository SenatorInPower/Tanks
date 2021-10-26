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

        internal static Dictionary<short, TankState> EnemysTanks;

        [SerializeField]
        private Dictionary<State, short> CriateEnemysTankAtState;

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
        [ShowIf("CreateCheck")]
        [Button]
        void SetState(State state, byte tankID)  // изменить состояние у одного
        {
           
            if (EnemysTanks[tankID] != null)
            {
                EnemysTanks[tankID].StateInit(state);
                EnemysTanks[tankID].Update(this);
            }
        }
       
       

     
        [Button]
        [HideIf("CreateCheck")]

        void CreateEnemys()
        {
            EnemysTanks = new Dictionary<short, TankState>();
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
            UpdateAllTank();   //запустить обновления

        }
        [ShowIf("CreateCheck")]
        [Button]
        private void UpdateAllState()
        {
            foreach (var item in CriateEnemysTankAtState)
            {
                for (byte i = 0; i < item.Value; i++)
                {
                    if (EnemysTanks[i] != null)
                    {
                        EnemysTanks[i].StateInit(item.Key);
                    }
                } 
            
            }
                
            
        }
      
        private void UpdateAllTank()   // not use in loop!
        {
            foreach (TankState tank in EnemysTanks.Values)
            {
               tank.Update(this);
            }
        }
        private bool CreateCheck()
        {
            if (EnemysTanks != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
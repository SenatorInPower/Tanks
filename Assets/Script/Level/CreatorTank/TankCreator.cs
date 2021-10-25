using Controller.CollisionControl;
using Script.AI.Controller;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.AI.Controller
{
    public class TankCreator : SerializedMonoBehaviour
    {
        

        internal static Dictionary<byte, TankState> Tanks;

        [SerializeField]
        private Dictionary<State, byte> CriateTankAtState;

        [SerializeField]
        private LevelInfo LevelInfo;

        [SerializeField]
        private GameObject TankPlayer;


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
            if (TankPlayer!=null&& TankEnemys!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void CriateEnemys()
        {
            byte tankID = 0;
            foreach (var item in CriateTankAtState)
            {
                for (byte i = 0; i < item.Value; i++)
                {
                   
                  
                    GameObject enemysTank = Instantiate(TankEnemys, LevelInfo.RandomPositionInTerritory(), Quaternion.identity);
                    CollisionAction collisionAction = enemysTank.GetComponent<CollisionAction>();
                    NavMeshAgent navMeshAgent=enemysTank.GetComponent<NavMeshAgent>();  
                    TankStats tankStats = new TankStats(stats, navMeshAgent, damageForElement, collisionAction);
                    TankState tankState = new TankState(item.Key, tankStats, LevelInfo) ;

                    tankID++;
                    Tanks.Add(tankID, tankState);
                }
            }        

        }

    }
}
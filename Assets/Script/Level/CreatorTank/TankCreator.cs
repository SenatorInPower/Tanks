using Controller.CollisionControl;
using Script.AI.Controller;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.AI.Controller
{
    public class TankCreator : SerializedMonoBehaviour
    {
        

        internal static Dictionary<int, TankState> Tanks;

        [SerializeField]
        private Dictionary<State, int> CriateTankAtState;

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
            int tankID = 0;
            foreach (var item in CriateTankAtState)
            {
                for (int i = 0; i < item.Value; i++)
                {
                   
                  
                    GameObject enemysTank = Instantiate(TankEnemys, LevelInfo.RandomPositionInTerritory(), Quaternion.identity);
                    CollisionAction collisionAction = enemysTank.GetComponent<CollisionAction>();
                    TankStats tankStats = new TankStats(stats, damageForElement, collisionAction);
                    TankState tankState = new TankState(item.Key, tankStats, LevelInfo) ;

                    tankID++;
                    Tanks.Add(tankID, tankState);
                }
            }        

        }

    }
}
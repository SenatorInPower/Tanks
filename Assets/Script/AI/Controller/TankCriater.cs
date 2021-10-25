using Controller.CollisionControl;
using Script.AI.Controller;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.AI.Controller
{
    public class TankCriater : MonoBehaviour
    {
        public Dictionary<State,int> CriateTankAtState;
        internal static Dictionary<int, TankState> Tanks;
        [SerializeField]
        private LevelInfo LevelInfo;

        [SerializeField]
        private GameObject TankPlayer;


        [SerializeField]
        private GameObject TankEnemys;

        //[SerializeField]
        //[Range(0f, 10f)]
        //private int countEnemys;

        [SerializeField]
        private DamageForElement damageForElement;

        [SerializeField]
        private Stats stats;

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
                    

                }
            }        

        }

    }
}
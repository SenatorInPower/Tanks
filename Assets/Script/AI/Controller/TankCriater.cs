using Script.AI.Controller;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.AI.Controller
{
    public class TankCriater : MonoBehaviour
    {
        
        [SerializeField]
        private LevelInfo LevelInfo;

        [SerializeField]
        private GameObject TankPlayer;

        [SerializeField]
        [Range(0f, 10f)]
        private int countEnemys;

        [SerializeField]
        private GameObject TankEnemys;

        [SerializeField]
        private DamageForElement damageForElement;

        [SerializeField]
        private Stats stats;

        void CriateEnemys()
        {
            for (int i = 0; i < countEnemys; i++)
            {

                GameObject enemysTank = Instantiate(TankEnemys, LevelInfo.RandomPositionInTerritory(), Quaternion.identity);

            }
           

        }

    }
}
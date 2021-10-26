using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Script.AI.Controller
{
    public class LevelInfo : SerializedMonoBehaviour
    {
        public const int MaxDistanseShut = 200;

        [SerializeField]
        private _AllSettings AllSettings;
        [SerializeField]

        private State State;
        
        [SerializeField]
        [ShowIf("State", State.Zone_protection)]
        private _ZoneProtaction ZoneProtaction;

        [SerializeField]
        [ShowIf("State", State.Ram)]
        private _Ram Ram;

        [SerializeField]
        [ShowIf("State", State.Distance_attack)]
        private _DistanceAtack DistanceAtack;

        [SerializeField]
        [ShowIf("State", State.Coordinator)]
        private _Coordinator Coordinator;

        private struct _AllSettings
        {
            public BoxCollider territory;
        }
        private struct _ZoneProtaction
        {
            public List<BoxCollider> protectZone;
        }
        private struct _Ram
        {
            public GameObject particleRam;
        }
        private struct _DistanceAtack
        {
            public short MinDistenceAtack;
            public short AtackCount;
        }
        private struct _Coordinator
        {
            public short CoordinatorID;
        }


        #region _AllSettings

        internal Vector3 RandomPositionInTerritory()
        {
            Vector3 posRendom = new Vector3(Random.Range(AllSettings.territory.bounds.min.x, AllSettings.territory.bounds.max.x), transform.position.y, Random.Range(AllSettings.territory.bounds.min.z, AllSettings.territory.bounds.max.z));
            return posRendom;
        }

        #endregion
   
        #region _DistanceAtack
        internal short MinDistenseOveride()
        {
            return DistanceAtack.MinDistenceAtack;
        }
        internal short DistenseAtackCount()
        {
            return DistanceAtack.AtackCount;
        }

        #endregion

        #region _ZoneProtaction


        internal Vector3 RandomPositionInZone()
        {
            int randomZone = Random.Range(0, 3);

            Vector3 posRendom = new Vector3(Random.Range(ZoneProtaction.protectZone[randomZone].bounds.min.x, ZoneProtaction.protectZone[randomZone].bounds.max.x), transform.position.y, Random.Range(ZoneProtaction.protectZone[randomZone].bounds.min.z, ZoneProtaction.protectZone[randomZone].bounds.max.z));
            return posRendom;
        }
        #endregion

        #region _Ram

        internal GameObject Particle()
        {
            return Ram.particleRam;

        }

        #endregion

        #region _Coordinator
        internal short LeadID()
        {
            return Coordinator.CoordinatorID;
        }
        #endregion

    }
}
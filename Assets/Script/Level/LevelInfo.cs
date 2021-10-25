using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Script.AI.Controller
{
    public class LevelInfo : SerializedMonoBehaviour
    {

        public _AllSettings AllSettings;
        public State State;

        [ShowIf("State", State.Coordinator)]
        public _Coordinator Coordinator;

        [ShowIf("State", State.Zone_protection)]
        public _ZoneProtaction ZoneProtaction;

        [ShowIf("State", State.Ram)]
        public _Ram Ram;

        [ShowIf("State", State.Distance_attack)]
        public _DistanceAtack DistanceAtack;

        public struct _AllSettings
        {
            public BoxCollider territory;
        }
        public struct _Coordinator
        {

        }
        public struct _ZoneProtaction
        {
            public List<BoxCollider> protectZone;
        }
        public struct _Ram
        {
            public GameObject particleRam;
        }
        public struct _DistanceAtack
        {
            public int MinDistenceAtack;
        }


        internal Vector3 RandomPositionInTerritory()
        {
            Vector3 posRendom = new Vector3(Random.Range(AllSettings.territory.bounds.min.x, AllSettings.territory.bounds.max.x), transform.position.y, Random.Range(AllSettings.territory.bounds.min.z, AllSettings.territory.bounds.max.z));
            return posRendom;
        }
        internal Vector3 RandomPositionInZone()
        {
            int randomZone = Random.Range(0, 3);

            Vector3 posRendom = new Vector3(Random.Range(ZoneProtaction.protectZone[randomZone].bounds.min.x, ZoneProtaction.protectZone[randomZone].bounds.max.x), transform.position.y, Random.Range(ZoneProtaction.protectZone[randomZone].bounds.min.z, ZoneProtaction.protectZone[randomZone].bounds.max.z));
            return posRendom;
        }

    }
}
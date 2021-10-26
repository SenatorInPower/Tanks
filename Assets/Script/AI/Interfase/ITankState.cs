using Script.AI.Controller;
using System.Collections;
using UnityEngine;

namespace Script.AI
{
    public interface ITankState
    {
        public IEnumerator Update(MonoBehaviour myMonoBehaviour);
        public IEnumerator Atack();
        public IEnumerator Move(Vector3 target);
    }
}
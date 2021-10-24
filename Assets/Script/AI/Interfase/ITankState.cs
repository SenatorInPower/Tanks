using System.Collections;
using UnityEngine;

namespace Assets.Script.AI
{
    public interface ITankState
    {
        public IEnumerator Update();
    }
}
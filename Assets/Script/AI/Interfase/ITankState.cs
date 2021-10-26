using Script.AI.Controller;
using System.Collections;

namespace Script.AI
{
    public interface ITankState
    {
        public IEnumerator Update();
        public IEnumerator Atack();
        public IEnumerator Move();
    }
}
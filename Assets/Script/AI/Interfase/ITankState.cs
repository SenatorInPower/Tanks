using System.Collections;

namespace Script.AI
{
    public interface ITankState
    {
        public IEnumerator Update();
    }
}
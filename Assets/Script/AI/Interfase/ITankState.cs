using System.Collections;

namespace Assets.Script.AI
{
    public interface ITankState
    {
        public IEnumerator Update();
    }
}
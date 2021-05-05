using UnityEngine;

namespace NumbersChallenge
{
    public abstract class ChallengePart : MonoBehaviour
    {
        public abstract void SetUp(Challenge currentChallenge);

        public abstract void Show();
        public abstract void Hide();
    }
}
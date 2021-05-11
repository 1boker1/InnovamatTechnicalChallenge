using UnityEngine;

namespace Challenge
{
    public abstract class ChallengePart : MonoBehaviour
    {
        public abstract void SetUp(global::Challenge.Challenge currentChallenge);

        public abstract void Show();
        public abstract void Hide();
    }
}
using UnityEngine;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public abstract class ChallengePart : MonoBehaviour
    {
        public abstract void SetUp(Challenge currentChallenge);

        public abstract void Show();
        public abstract void Hide();
    }
}
using UnityEngine;

namespace ChallengeStates
{
    public abstract class ChallengeState : MonoBehaviour
    {
        public static ChallengeState CurrentState;
        public abstract void SetUp(Challenge.Challenge challenge);
        public abstract void OnEnterState();
        public abstract void OnExitState();
    }
}
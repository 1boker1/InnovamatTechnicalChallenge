using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace ChallengeStates
{
    public class EnunciateChallengeState : ChallengeState
    {
        [SerializeField]
        Text _enunciate;

        [SerializeField]
        int _timeUntilHidePanel = 2;

        [SerializeField]
        Fade _fade;
        
        public override void SetUp(Challenge.Challenge challenge)
        {
            _enunciate.text = challenge.Enunciate;
        }

        public override void OnEnterState()
        {
            CurrentState = this;
            
            gameObject.SetActive(true);

            _fade.GetFadeIn().Execute();
        }

        public void StartStateChange()
        {
            StartCoroutine(WaitToChangeState());
        }

        private IEnumerator WaitToChangeState()
        {
            yield return new WaitForSeconds(_timeUntilHidePanel);

            OnExitState();
        }

        public override void OnExitState()
        {
            _fade.GetFadeOut().Execute();
        }
    }
}
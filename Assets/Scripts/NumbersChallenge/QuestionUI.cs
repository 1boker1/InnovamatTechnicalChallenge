using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace NumbersChallenge
{
    public class QuestionUI : ChallengePart
    {
        [SerializeField]
        Text _enunciate;

        [SerializeField]
        int _timeUntilHidePanel = 2;

        [SerializeField]
        Animation _canvasAnimation;

        [SerializeField]
        AnimationClip _fadeInAnimation;

        [SerializeField]
        AnimationClip _fadeOutAnimation;

        [SerializeField]
        UnityEvent _onQuestionDisappear;

        public override void SetUp(Challenge currentChallenge)
        {
            _enunciate.text = currentChallenge.Enunciate;
        }

        public override void Show()
        {
            gameObject.SetActive(true);

            PlayAnimation(_fadeInAnimation);
        }

        private IEnumerator WaitToHide()
        {
            yield return new WaitForSeconds(_timeUntilHidePanel);

            Hide();
        }

        public void OnEndFadeIn()
        {
            StartCoroutine(WaitToHide());
        }

        public void OnEndFadeOut()
        {
            _onQuestionDisappear.Invoke();
        }

        public override void Hide()
        {
            PlayAnimation(_fadeOutAnimation);
        }

        private void PlayAnimation(AnimationClip clip)
        {
            _canvasAnimation.clip = clip;
            _canvasAnimation.Rewind();
            _canvasAnimation.Play();
        }
    }
}
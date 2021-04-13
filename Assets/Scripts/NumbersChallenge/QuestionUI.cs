using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace InnovamatTechnicalChallenge.NumberGame
{
    public class QuestionUI : ChallengePart
    {
        public Text enunciate;

        public int timeUntilHidePanel = 2;

        public Animation canvasAnimation;
        public AnimationClip fadeInAnimation;
        public AnimationClip fadeOutAnimation;

        public UnityEvent OnQuestionDissappear;

        public override void SetUp(Challenge currentChallenge)
        {
            enunciate.text = currentChallenge.enunciate;
        }

        public override void Show()
        {
            gameObject.SetActive(true);

            PlayAnimation(fadeInAnimation);
        }

        private IEnumerator WaitToHide()
        {
            yield return new WaitForSeconds(timeUntilHidePanel);

            Hide();
        }

        public void OnEndFadeIn()
        {
            StartCoroutine(WaitToHide());
        }

        public void OnEndFadeOut()
        {
            OnQuestionDissappear.Invoke();
        }

        public override void Hide()
        {
            PlayAnimation(fadeOutAnimation);
        }

        private void PlayAnimation(AnimationClip Clip)
        {
            canvasAnimation.clip = Clip;
            canvasAnimation.Rewind();
            canvasAnimation.Play();
        }
    }
}
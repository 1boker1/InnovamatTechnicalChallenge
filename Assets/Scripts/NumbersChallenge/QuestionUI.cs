using System.Collections;
using UnityEngine;
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

        public override void SetUp(Challenge currentChallenge)
        {
            enunciate.text = currentChallenge.enunciate;
        }

        public override void Show()
        {
            PlayAnimation(fadeInAnimation);
            StartCoroutine(WaitToHide());
        }

        private IEnumerator WaitToHide()
        {
            yield return new WaitForSeconds(timeUntilHidePanel);

            Hide();
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
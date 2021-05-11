using UnityEngine;

namespace Utils
{
    public class Fade : MonoBehaviour
    {
        [SerializeField]
        FadePart _fadeIn;

        [SerializeField]
        FadePart _fadeOut;

        public FadePart GetFadeIn()
        {
            return _fadeIn;
        }

        public FadePart GetFadeOut()
        {
            return _fadeOut;
        }

        public void OnEndFadeIn()
        {
            _fadeIn.OnEnd();
        }

        public void OnEndFadeOut()
        {
            _fadeOut.OnEnd();
        }

        public void Clear()
        {
            _fadeIn.Clear();
            _fadeOut.Clear();
        }
    }
}
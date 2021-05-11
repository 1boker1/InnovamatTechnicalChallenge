using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    [Serializable]
    public class FadePart
    {
        [SerializeField]
        Animation _animation;

        [SerializeField]
        AnimationClip _fadeClip;

        [SerializeField]
        UnityEvent _onEnd;

        public void AddListener(UnityAction function)
        {
            _onEnd.AddListener(function);
        }

        public void OnEnd()
        {
            _onEnd?.Invoke();
        }

        public void Execute()
        {
            _animation.clip = _fadeClip;
            _animation.Rewind();
            _animation.Play();
        }

        public void Clear()
        {
            _onEnd.RemoveAllListeners();
        }
    }
}
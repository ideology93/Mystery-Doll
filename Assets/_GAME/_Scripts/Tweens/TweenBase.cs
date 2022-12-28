using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace NLO.Tweens
{
    public abstract class TweenBase : MonoBehaviour
    {
        [Tooltip("Allows you to identify one of multiple tweens of the same type via GetComponent")]
        public string TweenTag;

        [HideInInspector] public Tweener Tweener;
        [HideInInspector] public bool IsComplete = false;

        [Header("Base Tween Settings")]
        [SerializeField] protected int LoopCount;
        [SerializeField] protected float LoopDuration;
        [SerializeField] protected LoopType LoopType;
        [SerializeField] protected Ease LoopEase;
        [SerializeField] protected float Delay;
        [SerializeField] private bool _playOnAwake;
        [SerializeField] private UnityEvent _eventsOnPlayTween;
        [SerializeField] private UnityEvent _eventsOnComplete;

        protected virtual void Awake()
        {
            if (_playOnAwake) PlayTween();
        }

        public virtual void PlayTween()
        {
            SetTweener();
            Tweener.OnComplete(Complete);

            _eventsOnPlayTween.Invoke();
            Tweener.Play();
        }
        public void PlayBackwards() => Tweener.PlayBackwards();
        public void Rewind() => Tweener.Rewind();
        public void AddDelegateOnComplete(UnityAction callback) => _eventsOnComplete.AddListener(callback);

        protected abstract void SetTweener();
        protected virtual void Complete()
        {
            IsComplete = true;
            _eventsOnComplete.Invoke();
        }
        private void OnDestroy() => Tweener.Kill();
    }
}

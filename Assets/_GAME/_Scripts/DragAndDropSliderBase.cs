using UnityEngine;
using UnityEngine.UI;

namespace Aezakmi
{
    [RequireComponent(typeof(Slider))]
    public abstract class DragAndDropSliderBase : MonoBehaviour
    {
        [SerializeField] private float DragAngle;
        [SerializeField] private float MinimumTravelDistance;

        private Vector2? _startPosition;
        private bool _isAngleFound;
        private bool _isMouseStationary { get { return Input.mousePosition == _startPosition; } set { } }
        private Slider _slider;

        private void Start() => _slider = GetComponent<Slider>();
        private void Update()
        {
            if (Input.GetMouseButton(0) && _startPosition != null && !_isAngleFound)
            {
                if (_isMouseStationary)
                    return;

                CalculateAngle();
            }

            if (Input.GetMouseButtonDown(0))
                _startPosition = Input.mousePosition;
            else if (Input.GetMouseButtonUp(0))
            {
                _startPosition = null;
                _isAngleFound = false;
            }
        }

        protected virtual void Drag()
        {
            _slider.interactable = false;
        }

        protected virtual void Slide()
        {
            _slider.interactable = true;
        }

        private void CalculateAngle()
        {
            Vector2 currentPosition = Input.mousePosition;
            float distanceTravelled = (currentPosition - (Vector2)_startPosition).magnitude;

            if (distanceTravelled < MinimumTravelDistance)
                return;

            Vector2 direction = (currentPosition - (Vector2)_startPosition).normalized;
            var angle = direction.y * 90f;
            _isAngleFound = true;

            if(angle >= (90f - DragAngle))
                Drag();
            else
                Slide();
        }
    }
}
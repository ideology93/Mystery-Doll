namespace Aezakmi
{
    // EXAMPLE SCRIPT
    public class DragControllerExample : DragAndDropSliderBase
    {
        private bool _isDragging;

        private void Update()
        {
            if(!_isDragging)
                return;

            // raycast on UI
            // grab image
            // make image follow cursor
        }

        protected override void Drag()
        {
            base.Drag();
            _isDragging = true;
        }

        protected override void Slide()
        {
            base.Slide();
            _isDragging = false;
        }
    }
}
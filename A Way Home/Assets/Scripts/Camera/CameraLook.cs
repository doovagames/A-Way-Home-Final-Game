using UnityEngine;

namespace Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class CameraLook : MonoBehaviour
    {
        [SerializeField] private Vector2 _sensitivity;
        [SerializeField] private Vector2 _zoomBounds;
        [SerializeField] private Transform _boat;
        [SerializeField] private float _cameraZoom, _zoomSensitivity;
        private Vector3 _eulerAngle;

        private void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                // Camera Zoom.
                var z = Input.GetAxis("Mouse ScrollWheel");
                _cameraZoom -= z * _zoomSensitivity;
                _cameraZoom = Mathf.Clamp(_cameraZoom, _zoomBounds.x, _zoomBounds.y);
            }

            var h = Input.GetAxis("Mouse X") * _sensitivity.x;
            var v = Input.GetAxis("Mouse Y") * _sensitivity.y;
            var movement = new Vector3(-v, h, 0);
            _eulerAngle += movement;
            transform.eulerAngles = _eulerAngle;
            
            // Rotate camera.
            _eulerAngle = transform.eulerAngles;
            
            // Move camera.
            var newPosition = _boat.transform.position - transform.forward * _cameraZoom;
            transform.position = newPosition;
        }
    }
}

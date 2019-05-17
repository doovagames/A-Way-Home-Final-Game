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
        [SerializeField] private Vector2 _pitchBounds;
        private Vector3 _eulerAngle;

        private void Update()
        {
             // Camera Zoom.
            var z = Input.GetAxis("Mouse ScrollWheel") + Input.GetAxis("Controller Zoom");
             _cameraZoom -= z * _zoomSensitivity;
             _cameraZoom = Mathf.Clamp(_cameraZoom, _zoomBounds.x, _zoomBounds.y);

            var h = (Input.GetAxis("Mouse X") - Input.GetAxis("Xbox X Look")) * _sensitivity.x;
            var v = (-Input.GetAxis("Mouse Y") + Input.GetAxis("Xbox Y Look")) * _sensitivity.y;
            var movement = new Vector3(-v, h, 0);
            _eulerAngle += movement;

            // Clamp the pitch.
            var pitch = Mathf.Clamp(_eulerAngle.x, _pitchBounds.x, _pitchBounds.y);
            _eulerAngle.x = pitch;
            
            transform.eulerAngles = _eulerAngle;
            
            // Move camera.
            var newPosition = _boat.transform.position - transform.forward * _cameraZoom;
            transform.position = newPosition;
        }
    }
}

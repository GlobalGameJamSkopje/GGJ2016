using UnityEngine;

namespace Assets.Scripts
{
    public class TreeFaceDirection : MonoBehaviour
    {
        private Camera _camera;
        void Awake()
        {
            _camera = FindObjectOfType<Camera>();
        }

        void Update()
        {
            this.transform.LookAt(_camera.transform);
        }
    }
}

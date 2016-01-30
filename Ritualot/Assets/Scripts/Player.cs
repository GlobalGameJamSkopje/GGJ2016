using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private int _navigationIndex;

        void Awake()
        {
            _navigationIndex = EditorApplication.currentScene.StartsWith("Inverse") ? 1 : -1;
        }
        void Update()
        {
            transform.Translate(Input.GetAxis("Horizontal") * _navigationIndex * 10f * Time.deltaTime, 0, 0);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -6, 6),
                transform.position.y,
                transform.position.z);
        }
    }
}

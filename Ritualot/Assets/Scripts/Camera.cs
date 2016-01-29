using UnityEngine;

namespace Assets.Scripts
{
    public class Camera : MonoBehaviour
    {
        void Update()
        {
            transform.position = new Vector3(
                 transform.position.x,
                 transform.position.y,
                 transform.position.z + GameManager.Instance.GameSpeed * Time.deltaTime);
        }
    }
}

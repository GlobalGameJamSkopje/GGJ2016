using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        private int _navigationIndex;

        void Awake()
        {
            _navigationIndex = SceneManager.GetActiveScene().name == "InverseRunnerScene" ? -1 : 1;
        }
        void Update()
        {
            transform.Translate(Input.GetAxis("Horizontal") * _navigationIndex * 10f * Time.deltaTime, 0, 0);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, -4, 4),
                transform.position.y,
                transform.position.z);
        }

        void OnCollisionEnter(Collision coll)
        {
            Debug.Log("HIT");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

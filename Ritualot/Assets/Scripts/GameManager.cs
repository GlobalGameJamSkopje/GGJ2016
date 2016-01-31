using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public float GameSpeed = 20;

        public bool Finished { get; set; }

        void Awake()
        {
            if (Instance == null)
                Instance = this;

            else if (Instance != this)
                Destroy(this);

            DontDestroyOnLoad(gameObject);
        }
        public void StartPlatformer()
        {
            SceneManager.LoadScene("PlatformerVampireStocking");
        }
        public void StartVonDittaRoom()
        {
            SceneManager.LoadScene("Ditta'sBedChamber");
        }
    }

    
}

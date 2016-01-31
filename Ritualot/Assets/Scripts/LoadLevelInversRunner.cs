using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace Assets.Scripts
{
    public class LoadLevelInversRunner : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadInversRunnerNow()
        {
            SceneManager.LoadScene("InverseRunnerScene");
        }
    }

}

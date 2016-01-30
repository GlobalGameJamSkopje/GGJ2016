using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class RunnerSpawnTrees : MonoBehaviour
    {
        public GameObject Trees;
        public GameObject WoodRunnerBlockage;

        private float _spawnTime = 0.16f;
        private float _currentSpawnTime;

        private float _blockageSpawnTime = 2f;
        private float _currentBlockageSpawnTime;

        private float _endTime = 20f;
        private float _currentTime;

        void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            _currentBlockageSpawnTime += Time.deltaTime;
            _currentTime += Time.deltaTime;

            if (_currentSpawnTime >= _spawnTime)
            {
                InstantiateTrees();
                _currentSpawnTime = 0f;
            }
            if (_currentBlockageSpawnTime >= _blockageSpawnTime)
            {
                Instantiate(
                    WoodRunnerBlockage,
                    new Vector3(
                        this.transform.position.x,
                        this.transform.position.y,
                        this.transform.position.z),
                    new Quaternion());

                _currentBlockageSpawnTime = 0f;
            }
            if (_currentTime > _endTime)
            {
                SceneManager.LoadScene("HomeScene");
            }
        }

        private void InstantiateTrees()
        {
            Instantiate(
                Trees,
                new Vector3(
                    this.transform.position.x - 5.8f,
                    this.transform.position.y,
                    this.transform.position.z),
                new Quaternion());
            Instantiate(
                Trees,
                new Vector3(
                    this.transform.position.x + 5.8f,
                    this.transform.position.y,
                    this.transform.position.z),
                new Quaternion());
        }
    }
}

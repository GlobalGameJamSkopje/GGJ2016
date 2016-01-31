using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public GameObject SideObject;
        public GameObject Blockage;
        public GameObject EndRunPanel;

        public float SpawnTimeSideObject = 0.16f;
        public float BlockageSpawnTime = 1f;
        public float EndTime = 20f;

        private float _currentSpawnTime;
        private float _currentBlockageSpawnTime;
        private float _currentTime;

        void Update()
        {
            _currentSpawnTime += Time.deltaTime;
            _currentBlockageSpawnTime += Time.deltaTime;
            _currentTime += Time.deltaTime;

            if (_currentSpawnTime >= SpawnTimeSideObject)
            {
                InstantiateTrees();
                _currentSpawnTime = 0f;
            }
            if (_currentBlockageSpawnTime >= BlockageSpawnTime)
            {
                Instantiate(
                    Blockage,
                    new Vector3(
                        this.transform.position.x + Random.Range(-3.5f, 3.5f),
                        this.transform.position.y,
                        this.transform.position.z),
                    new Quaternion());

                _currentBlockageSpawnTime = 0f;
            }
            if (_currentTime > EndTime)
            {
                EndRunPanel.SetActive(true);
                var enemies = GameObject.FindGameObjectsWithTag(Enums.Tags.Enemy.ToString());
                foreach (var item in enemies)
                {
                    Destroy(item);
                }
                this.enabled = false;
            }
        }

        private void InstantiateTrees()
        {
            Instantiate(
                SideObject,
                new Vector3(
                    this.transform.position.x - 5.8f,
                    this.transform.position.y,
                    this.transform.position.z),
                new Quaternion());
            Instantiate(
                SideObject,
                new Vector3(
                    this.transform.position.x + 5.8f,
                    this.transform.position.y,
                    this.transform.position.z),
                new Quaternion());
        }
    }
}

using UnityEngine;

namespace Assets.Scripts
{
    public class RunnerSpawnTrees : MonoBehaviour
    {
        public GameObject Trees;

        private float _spawnTime = 0.2f;
        private float _time;

        void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _spawnTime)
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

                _time = 0f;
            }
        }
    }
}

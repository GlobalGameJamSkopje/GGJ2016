using UnityEngine;

namespace Assets.Scripts
{
    public class RunnerSpawnTrees : MonoBehaviour
    {
        public GameObject[] Trees;

        private float _spawnTime = 0.25f;
        private float _time;

        void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _spawnTime)
            {
                int random = Random.Range(0, Trees.Length * 10);
                Instantiate(
                    Trees[random % 3],
                    new Vector3(
                        this.transform.position.x + ((random < Trees.Length * 5) ? -5.5f : 5.5f),
                        this.transform.position.y,
                        this.transform.position.z),
                    new Quaternion());

                _time = 0f;
            }
        }
    }
}

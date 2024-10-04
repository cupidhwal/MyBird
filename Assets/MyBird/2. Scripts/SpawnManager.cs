using UnityEngine;

namespace MyBird
{
    public class SpawnManager : MonoBehaviour
    {
        // 필드
        #region Variables
        private float countdown;

        [SerializeField] private float maxSpawnTimer;
        [SerializeField] private float minSpawnTimer;

        public GameObject pipePrefab;
        #endregion

        private void Update()
        {
            if (countdown <= 0f)
            {

            }
        }

        // 메서드
        #region Methods
        public void GenerateStart()
        {
            InvokeRepeating("GeneratePipe", 1, 2);
        }

        void GeneratePipe()
        {
            float yPos = Random.Range(-1.5f, 3.5f);
            Vector3 spawnPos = new(0, yPos, 0);

            Instantiate(pipePrefab, this.transform.position + spawnPos, Quaternion.identity);
        }
        #endregion
    }
}
using UnityEngine;

namespace MyBird
{
    public class SpawnManager : MonoBehaviour
    {
        #region Variables
        //스폰 프리팹
        public GameObject spawnPrefab;

        //스폰 타이머
        private float spawnTimer = 1.0f;
        private float countdown = 0f;

        private float maxSpawnTimer = 1.05f;
        private float minSpawnTimer = 0.95f;
        public static float levelTime = 0f;


        //스폰 위치
        [SerializeField] private float maxSpawnY = 3.5f;
        [SerializeField] private float minSpawnY = -1.5f;
        #endregion

        private void Start()
        {
            //초기화
            countdown = spawnTimer;
        }

        private void Update()
        {
            //게임 진행 체크
            if (GameManager.IsStart == false || GameManager.IsDeath == true)
                return;

            Debug.Log(countdown);

            //스폰 타이머
            if (countdown <= 0f)
            {
                //스폰
                SpawnPipe();

                //타이머 초기화
                countdown = Random.Range((minSpawnTimer - levelTime), maxSpawnTimer); // 1.05f ~ 0.95f => 1.05f ~ 0.90f
            }
            countdown -= Time.deltaTime;
        }

        void SpawnPipe()
        {
            float spawnY = transform.position.y + Random.Range(minSpawnY, maxSpawnY);
            Vector3 spawnPosition = new(transform.position.x, spawnY, 0f);
            Instantiate(spawnPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

/*using UnityEngine;

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
}*/
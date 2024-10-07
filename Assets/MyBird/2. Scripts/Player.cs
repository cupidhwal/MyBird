using UnityEngine;

namespace MyBird
{
    public class Player : MonoBehaviour
    {
        // 필드
        #region Variables
        // 단순 변수
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] private float jumpSpeed = 5;
        [SerializeField] private float turnSpeed = 100;

        private bool isJump = false;

        // 컴포넌트
        private Rigidbody2D rb2D;

        // 클래스 컴포넌트
        //public SpawnManager spawnManager;

        // 오디오 소스
        private AudioSource audioSource;
        #endregion

        // 속성
        #region Properties
        public float MoveSpeed => moveSpeed;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        private void Update()
        {
            Move();
            Jump();
            Rotation();
            JumpInput();
        }

        private void FixedUpdate()
        {
            Stay();
        }
        #endregion

        // 메서드
        #region Methods
        // 플레이어의 이동 메서드
        private void Move()
        {
            if (GameManager.IsDeath == true) return;

            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right, Space.World);
        }

        // 플레이어의 점프 인풋 메서드
        private void JumpInput()
        {
            /*if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                isJump = true;*/

            if (GameManager.IsDeath == true) return;

#if UNITY_EDITOR
            // 이런 방법도 있다!
            isJump |= Input.GetKeyDown(KeyCode.Space);
            isJump |= Input.GetMouseButtonDown(0);
#else
            // 터치 인풋 처리
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    isJump |= true;
                }
            }
#endif
        }

        // 플레이어의 점프 메서드
        private void Jump()
        {
            if (isJump == false) return;

            // velocity를 사용하는 방법
            rb2D.velocity = jumpSpeed * Vector2.up;
            isJump = false;

            // AddForce를 사용하는 방법
            /*rb2D.AddForce(jumpSpeed * Vector2.up, ForceMode2D.Impulse);
            isJump = false;*/
            // 하지만 이런 간단한 게임에서는 velocity를 사용하는 게 훨씬 직관적이고 조작이 쉽다
        }

        // 플레이어의 점프 시 회전 메서드
        private void Rotation()
        {
            if (GameManager.IsDeath == true) return;

            float rotation = turnSpeed * rb2D.velocity.magnitude * Time.deltaTime;
            rb2D.rotation = Mathf.Clamp(rb2D.rotation, -90f, 30f);

            rb2D.rotation = (rb2D.velocity.y > 0) ? rb2D.rotation + rotation : rb2D.rotation - rotation;
        }

        // 플레이어의 점수 획득 메서드
        private void GetPoint()
        {
            if (GameManager.IsDeath == true) return;

            // 점수 획득
            GameManager.Score++;

            // 포인트 획득 사운드 플레이
            audioSource.Play();

            // 기둥을 10개 통과할 때마다 난이도 상승 - 10점, 20점, 30점, ...
            if (GameManager.Score % 10 == 0)
            {
                SpawnManager.levelTime += 0.05f;
            }
        }

        // 플레이어의 죽음 메서드
        private void Die()
        {
            //두 번 죽음 방지
            if (GameManager.IsDeath == true) return;

            GameManager.IsDeath = true;
        }

        // 제자리에 대기 메서드
        private void Stay()
        {
            if (GameManager.IsStart == true) return;

            //rb2D.velocity = new Vector2(rb2D.velocity.x, 0);

            rb2D.AddForce(Physics.gravity.magnitude * Vector3.up, ForceMode2D.Force);

            if (Input.anyKey)
            {
                GameManager.IsStart = true;
                //spawnManager.GenerateStart();
            }
        }
#endregion

        // 이벤트 메서드
        #region Event Methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Point")
                GetPoint();

            else if (collision.tag == "Pipe")
                Die();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
                Die();
        }
        #endregion
    }
}
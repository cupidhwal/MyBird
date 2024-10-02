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
        private bool isStart = false;

        // 속성
        #region Properties
        public float MoveSpeed => moveSpeed;
        #endregion

        // 컴포넌트
        private Rigidbody2D rb2D;
        #endregion

        #region Life Cycle
        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            Move();
            JumpInput();
        }

        private void FixedUpdate()
        {
            Jump();
            Rotation();

            Stay();
        }
        #endregion

        #region Methods
        // 플레이어의 이동 메서드
        private void Move()
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right, Space.World);
        }

        // 플레이어의 점프 인풋 메서드
        private void JumpInput()
        {
            /*if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                isJump = true;*/

            // 이런 방법도 있다!
            isJump |= Input.GetKeyDown(KeyCode.Space);
            isJump |= Input.GetMouseButtonDown(0);
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
            float rotation = turnSpeed * rb2D.velocity.magnitude * Time.deltaTime;
            rb2D.rotation = Mathf.Clamp(rb2D.rotation, -90f, 30f);
            
            rb2D.rotation = (rb2D.velocity.y > 0) ? rb2D.rotation + rotation : rb2D.rotation - rotation;
        }

        // 제자리에 대기 메서드
        private void Stay()
        {
            if (isStart == true) return;

            //rb2D.velocity = new Vector2(rb2D.velocity.x, 0);

            rb2D.AddForce(Physics.gravity.magnitude * Vector3.up, ForceMode2D.Force);

            if (Input.anyKey)
                isStart = true;
        }
        #endregion
    }
}
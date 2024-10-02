using UnityEngine;

namespace MyBird
{
    public class CameraControler : MonoBehaviour
    {
        // 필드
        #region Variables
        public Transform player;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        void LateUpdate()
        {
            FollowPlayer();
        }
        #endregion

        // 메서드
        #region Methods
        void FollowPlayer()
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }
        #endregion

        /*
        // 필드
        #region Variables
        private float moveSpeed;

        public Player player;
        #endregion

        // 라이프 사이클
        #region Life Cycle
        private void Start()
        {
            moveSpeed = player.MoveSpeed;
        }

        void Update()
        {
            FollowPlayer();
        }
        #endregion

        // 메서드
        #region Methods
        void FollowPlayer()
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right, Space.World);
        }
        #endregion
         */
    }
}
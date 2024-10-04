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
            transform.position = new Vector3(player.transform.position.x + 2, transform.position.y, transform.position.z);
        }
        #endregion
    }
}
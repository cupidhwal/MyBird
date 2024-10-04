using UnityEngine;

namespace MyBird
{
    public class GroundMove : MonoBehaviour
    {
        public Player player;

        void Update()
        {
            if (GameManager.IsDeath == true) return;

            MoveBackground();
        }

        void MoveBackground()
        {
            transform.Translate(player.MoveSpeed * Time.deltaTime * Vector3.left, Space.World);

            if (transform.localPosition.x <= -8.4f)
                transform.localPosition = new Vector3(transform.localPosition.x + 8.4f, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
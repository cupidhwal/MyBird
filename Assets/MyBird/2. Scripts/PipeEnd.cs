using UnityEngine;

namespace MyBird
{
    public class PipeEnd : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}
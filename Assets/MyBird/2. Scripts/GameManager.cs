using UnityEngine;
using TMPro;

namespace MyBird
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        public static bool IsStart { get; set; }
        public static bool IsDeath { get; set; }
        public static int Score { get; set; }
        public static int BestScore { get; set; }

        //게임 UI
        public GameObject readyUI;
        public GameObject playUI;
        public GameObject resultUI;
        public TextMeshProUGUI score;
        #endregion

        private void Start()
        {
            //초기화
            IsStart = false;
            IsDeath = false;
            Score = 0;
        }

        private void Update()
        {
            if (IsStart)
            {
                readyUI.SetActive(false);
                playUI.SetActive(true);
            }

            if (IsDeath)
            {
                playUI.SetActive(false);
                resultUI.SetActive(true);
            }

            score.text = Score.ToString();
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MyBird
{
    public class GameOverUI : MonoBehaviour
    {
        #region Variables
        private string loadToScene = "TitleScene";

        public TextMeshProUGUI bestScoreText;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI newText;
        #endregion

        private void OnEnable()
        {
            //게임 데이터 저장
            GameManager.BestScore = PlayerPrefs.GetInt("BestScore", 0);
            if (GameManager.Score > GameManager.BestScore)
            {
                GameManager.BestScore = GameManager.Score;
                PlayerPrefs.SetInt("BestScore", GameManager.Score);
                
                newText.text = "New";
            }

            else if (GameManager.Score > GameManager.BestScore)
            {
                newText.text = "Same";
            }

            else
            {
                newText.text = "";
            }

            //UI 연결
            bestScoreText.text = GameManager.BestScore.ToString();
            scoreText.text = GameManager.Score.ToString();
        }

        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Menu()
        {
            SceneManager.LoadScene(loadToScene);
        }
    }
}
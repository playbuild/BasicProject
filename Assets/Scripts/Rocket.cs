using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

namespace TMpro
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentScoreTxt;
        [SerializeField] private TextMeshProUGUI HighScoreTxt;

        private Rigidbody2D _rb2d;
        private float fuel = 100f;

        private readonly float SPEED = 5f;
        private readonly float FUELPERSHOOT = 10f;

        int Score = 0;
        int HighScore = 0;

        void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
            // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        }

        public void Shoot()
        {
            if (fuel >= FUELPERSHOOT)
            {
                _rb2d.AddForce(Vector2.up * SPEED, ForceMode2D.Impulse);
                fuel -= FUELPERSHOOT;
                // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
            }
            else
            {

            }

        }
        private void AddScore()
        {
            Score = (int)transform.position.y;

        }
        private void Update()
        {
            Vector2 pos;
            pos = this.gameObject.transform.position;
            AddScore();
            if (pos.y > Score)
            {
                PlayerPrefs.SetInt(currentScoreTxt.text, Score);
                if (Score >= HighScore)
                {
                    HighScore = Score;
                    PlayerPrefs.SetInt(HighScoreTxt.text, Score);
                }
            }

            currentScoreTxt.text = $"{Score}M";
            HighScoreTxt.text = $"{HighScore}M";
        }
        public void ReTxt()
        {
            SceneManager.LoadScene("RocketLauncher");
        }
    }
}

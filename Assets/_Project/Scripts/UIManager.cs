using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltimateTTT
{
    public class UIManager : Singleton<UIManager>
    {
        public Sprite cross;
        public Sprite circle;

        public Image currentPlayer;
        // Start is called before the first frame update
        void Start()
        {
            currentPlayer.sprite = cross;
        }

        public void ChangeCurrentPlayerImage(int player)
        {
            if (player ==1)
            {
                currentPlayer.sprite = cross;
            }
            else
            {
                currentPlayer.sprite = circle;
            }
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}

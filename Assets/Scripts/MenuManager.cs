using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public InputField playerName;
    public Button startGameButton;

    private void Awake()
    {
        startGameButton.enabled = false;
        startGameButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        startGameButton.enabled = playerName.text.Length > 0;
    }

    private void StartGame()
    {
        ScoreManager.Instance.CurrentScore.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public AudioManager audioManager;
    public void GoToCharacterSelection()
    {
        audioManager.PlayBackgroundMusic();
        SceneManager.LoadScene("CharacterSelection");
    }

    public void StartGame()
    {
        audioManager.PlayBackgroundMusic();
        SceneManager.LoadScene("Game");
    }
    public void StartFight()
    {
        audioManager.PlayBackgroundMusic();
        SceneManager.LoadScene("Boxing");
    }

    void Start()
    {
        audioManager.PlayBackgroundMusic();
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ResetToMenu();
        }
    }
}

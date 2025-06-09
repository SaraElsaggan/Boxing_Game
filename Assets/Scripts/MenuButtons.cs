using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void GoToCharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelection");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void StartFight()
    {
        SceneManager.LoadScene("Boxing");
    }

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ResetToMenu();
        }
    }
}

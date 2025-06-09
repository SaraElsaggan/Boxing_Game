using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterButton : MonoBehaviour
{
    public int characterIndex;

    public void SelectCharacter()
    {
        CharacterSelectionManager.Instance.selectedCharacterIndex = characterIndex;
        SceneManager.LoadScene("Menu_scene");
    }
}

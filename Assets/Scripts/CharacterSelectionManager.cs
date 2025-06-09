using UnityEngine;

public class CharacterSelectionManager : MonoBehaviour
{
    public static CharacterSelectionManager Instance;

    public GameObject[] characters;
    public int selectedCharacterIndex;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetSelectedCharacter()
    {
        return characters[selectedCharacterIndex];
    }
}

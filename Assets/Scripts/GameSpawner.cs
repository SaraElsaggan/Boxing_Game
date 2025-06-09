
using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject defaultCharacterPrefab;
    public TrainingManager trainingManager;

    void Start()
    {
        GameObject characterToSpawn = null;

        if (CharacterSelectionManager.Instance != null)
        {
            characterToSpawn = CharacterSelectionManager.Instance.GetSelectedCharacter();
        }

        if (characterToSpawn == null)
        {
            characterToSpawn = defaultCharacterPrefab;
        }

        // Instantiate the selected character
        GameObject spawnedCharacter = Instantiate(characterToSpawn, spawnPoint.position, spawnPoint.rotation);

        // Assign the spawned character's Animator to TrainingManager
        Animator animator = spawnedCharacter.GetComponent<Animator>();
        if (trainingManager != null && animator != null)
        {
            trainingManager.SetAnimator(animator);
        }

    }
}

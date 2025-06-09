using UnityEngine;

public class TrainingManager : MonoBehaviour
{
    [HideInInspector]
    public Animator playerAnimator;

    void ResetAllTriggers()
    {
        if (playerAnimator == null) return;

        playerAnimator.ResetTrigger("StartTraining1");
        playerAnimator.ResetTrigger("StartTraining2");
        playerAnimator.ResetTrigger("StartTraining3");
        playerAnimator.ResetTrigger("StartTraining4");
    }

    public void SetAnimator(Animator animator)
    {
        playerAnimator = animator;
        if (playerAnimator == null)
        {
            Debug.LogWarning("TrainingManager: No Animator assigned!");
        }
    }

    public void StartTraining1()
    {
        ResetAllTriggers();
        playerAnimator.Play("idleBoxing");
        AudioManager.Instance.PlayTrainingAudio(AudioManager.Instance.training1Audio);
        playerAnimator.SetTrigger("StartTraining1");
    }

    public void StartTraining2()
    {
        ResetAllTriggers();
        playerAnimator.Play("idleBoxing");
        AudioManager.Instance.PlayTrainingAudio(AudioManager.Instance.training2Audio);
        playerAnimator.SetTrigger("StartTraining2");
    }

    public void StartTraining3()
    {
        ResetAllTriggers();
        playerAnimator.Play("idleBoxing");
        AudioManager.Instance.PlayTrainingAudio(AudioManager.Instance.training3Audio);
        playerAnimator.SetTrigger("StartTraining3");
    }

    public void StartTraining4()
    {
        ResetAllTriggers();
        playerAnimator.Play("idleBoxing");
        AudioManager.Instance.PlayTrainingAudio(AudioManager.Instance.training4Audio);
        playerAnimator.SetTrigger("StartTraining4");
    }
}

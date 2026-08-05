using UnityEngine;

public class NPCInteraction : MonoBehaviour, IInteract
{
    [SerializeField] private NPCAnimationController npcAnimationController;
    [SerializeField] private NPCRewardSystem npcRewardSystem;
    public string InteractionPrompt => throw new System.NotImplementedException();

    public void Interact()
    {
        npcAnimationController.Talk();
        npcRewardSystem.correctAnswers = 2;
        npcRewardSystem.GiveReward();
    }
}

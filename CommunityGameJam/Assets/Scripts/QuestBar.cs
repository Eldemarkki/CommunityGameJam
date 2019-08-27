using TMPro;
using UnityEngine;

public class QuestBar : MonoBehaviour
{
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private TMP_Text questText;
    [SerializeField] private GameManager gameManager;

    private Quest currentQuest;


    private void Awake()
    {
        SetQuest(CreateRandomQuest());
    }

    public void PressAnswer(bool userAnswer)
    {
        if (userAnswer != currentQuest.CorrectAnswer)
        {
            gameManager.ReduceHealth(1);
        }

        SetQuest(CreateRandomQuest());
    }

    private void SetQuest(Quest quest)
    {
        currentQuest = quest;
        questText.text = quest.GetText();
    }

    Quest CreateRandomQuest()
    {
        if (Random.value <= 0.5f)
        {
            // Create a true quest

            // Check that the item is not a root item (no recipe)
            Item item = itemManager.GetRandomItem();
            while (item.recipe1 == null || item.recipe2 == null)
            {
                item = itemManager.GetRandomItem();
            }
            
            return new Quest(item);
        }
        else
        {
            // TODO: Maybe have a quest with {item1.recipe1, randomItem, item1} so it's more difficult
            // Create a false quest
            return new Quest(itemManager.GetRandomItem(), itemManager.GetRandomItem(), itemManager.GetRandomItem());
        }
    }
}

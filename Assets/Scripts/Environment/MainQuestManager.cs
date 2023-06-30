using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainQuestManager : Singleton<MainQuestManager>
{
    [SerializeField]
    private List<VegetableInteractionController> quests;
    [SerializeField]
    private GameObject indicatorPrefab;

    private GameObject indicator;

    private IEnumerator Start()
    {
        if (quests.Count > 0)
        {
            foreach (var quest in quests)
            {
                quest.QuestCompleteEvent += OnQuestComplete;
            }
            indicator = Instantiate(indicatorPrefab);
            indicator.transform.position = quests[0].transform.position;
            yield return null;

            quests[0].StartQuest();
        }
    }

    private void OnQuestComplete(object obj, System.EventArgs args)
    {
        VegetableInteractionController controller = (VegetableInteractionController)obj;
        if (quests.Contains(controller))
        {
            bool wasGood = quests[0] = controller;
            quests.Remove(controller);
            if (wasGood)
            {
                if (quests.Count > 0)
                {
                    indicator.transform.position = quests[0].transform.position;
                    quests[0].StartQuest();
                }
                else
                {
                    UIPopUp.Instance.PopUp(UIPopUp.PopUpType.TheEnd);
                    Destroy(indicator);
                }

            }
        }
        controller.QuestCompleteEvent -= OnQuestComplete;
    }
}

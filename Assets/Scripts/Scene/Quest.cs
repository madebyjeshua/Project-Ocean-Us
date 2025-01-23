using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    private int[] ids, maxCounts, counts, questCounts;
    private string[] items;
    private Text questItem1, questItem2, questTurtle;
    private GameObject check1, check2, check3;
    private bool[] isQuestDone;

    public GameObject questUI;

    private void Awake()
    {
        questItem1 = GameObject.Find("QuestItem1").GetComponent<Text>();
        questItem2 = GameObject.Find("QuestItem2").GetComponent<Text>();
        questTurtle = GameObject.Find("QuestTurtle").GetComponent<Text>();

        check1 = GameObject.Find("Checklist1");
        check2 = GameObject.Find("Checklist2");
        check3 = GameObject.Find("Checklist3");
    }

    private void Start()
    {
        SetLists();
        SetQuests();
        SetQuestCounts();
        RefreshUI();
    }
    public void CheckId(int id)
    {
        for (int i = 0; i < 3; i++)
        {
            if (ids[i] == id && !isQuestDone[i])
            {
                counts[i]++;
                if (counts[i] >= questCounts[i])
                {
                    isQuestDone[i] = true;
                }
            }
        }
        RefreshUI();
    }
    private void RefreshUI()
    {
        questItem1.text = items[ids[0]] + " (" + counts[0] + "/" + questCounts[0] + ")";
        questItem2.text = items[ids[1]] + " (" + counts[1] + "/" + questCounts[1] + ")";
        questTurtle.text = items[ids[2]] + " (" + counts[2] + "/" + questCounts[2] + ")";

        if (isQuestDone[0])
        {
            check1.SetActive(true);
        }
        else
        {
            check1.SetActive(false);
        }

        if (isQuestDone[1])
        {
            check2.SetActive(true);
        }
        else
        {
            check2.SetActive(false);
        }

        if (isQuestDone[2])
        {
            check3.SetActive(true);
        }
        else
        {
            check3.SetActive(false);
        }

        if(isQuestDone[0] && isQuestDone[1] && isQuestDone[2])
        {
            GameObject questUI = GameObject.Find("QuestUI");
            questUI.SetActive(true);
        }
    }

    private void SetQuests()
    {
        ids = new int[3]
        {
            Random.Range(0, 5),
            Random.Range(0, 5),
            5
        };

        while (ids[1] == ids[0])
        {
            ids[1] = Random.Range(0, 5);
        }

        counts = new int[3]
        {
            0,
            0,
            0
        };

        isQuestDone = new bool[3]
        {
            false,
            false,
            false
        };
    }

    private void SetQuestCounts()
    {
        questCounts = new int[3]
        {
            Random.Range(1, maxCounts[ids[0]] + 1),
            Random.Range(1, maxCounts[ids[1]] + 1),
            Random.Range(1, maxCounts[ids[2]] + 1)
        };
    }

    private void SetLists()
    {
        items = new string[]{
            "Barrel",
            "Bottle",
            "Bottle Binder",
            "Can",
            "Plastic",
            "Save The Turtle"
        };

        maxCounts = new int[]
        {
            2,
            5,
            3,
            5,
            5,
            3
        };
    }

     public void OpenQuestUI()
    {
        if (questUI != null)
        {
            questUI.SetActive(true);
        }
    }

    public void CloseQuestUI()
    {
        if (questUI != null)
        {
            questUI.SetActive(false);
        }
    }
}


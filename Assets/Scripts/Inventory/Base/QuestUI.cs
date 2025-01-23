using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public void OnClick()
    {
        PlayerData playerData = FindFirstObjectByType<PlayerData>();

        playerData.money += 500;

        GameObject questUI = GameObject.Find("QuestUI");
        questUI.SetActive(false);

    }
}

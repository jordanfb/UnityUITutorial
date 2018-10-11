using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    int[] playerStats;
    //Money Sloth Strength Fun Fruit Disease Sleep
    string[] statNames = { "Money", "Sloth", "Strength", "Fun", "Fruit", "Disease", "Sleep" };

    [SerializeField]
    private GameObject statParent;
    [SerializeField]
    private Text[] statNamesUI; // the bars to shrink
    [SerializeField]
    private Text[] statValuesUI; // the bars to shrink

    public void SetStats(int[] stats)
    {
        playerStats = stats;
        for (int i = 0; i < playerStats.Length; i++)
        {
            statNamesUI[i].text = statNames[i]+ ":";
            statValuesUI[i].text = " " + playerStats[i];
        }
    }

    public void ShowStats()
    {
        statParent.SetActive(true);
    }

    public void HideStats()
    {
        statParent.SetActive(false);
    }
}

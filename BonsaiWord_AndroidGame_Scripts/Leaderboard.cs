using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {

    public GridLayoutGroup _leaderboardGrid;
    public List<LeaderboardEntry> _entries = new List<LeaderboardEntry>();
    public GameObject _leaderboardEntryPrefab;

	void Start () 
    {

    }
	
	public void GetLeaderboard(bool isFB, DataPersist dataPersist)
    {
        bool fbFailed = false;

        for(int i = 0; i < _entries.Count; i++)
        {
            Destroy(_entries[i]);
        }

        _entries.Clear();


        if (isFB)
        {
            try
            {
                new LeaderboardDataRequest_highScoreLeaderboard().SetEntryCount(10).Send((response) => {

                    foreach (var entry in response.Data)
                    {
                        GameObject go = Instantiate(_leaderboardEntryPrefab);
                        go.transform.SetParent(_leaderboardGrid.transform, false);
                        LeaderboardEntry leaderboardEntry = go.GetComponent<LeaderboardEntry>() as LeaderboardEntry;

                        leaderboardEntry.rankString = entry.Rank.ToString();
                        leaderboardEntry.usernameString = entry.UserName.ToString();
                        leaderboardEntry.scoreString = entry.GetNumberValue("score").ToString();
                        leaderboardEntry.UpdateText();
                        _entries.Add(leaderboardEntry);
                    }

                });
            } 
            catch
            {
                fbFailed = true;
            }
        } 
        else
        {
            GameObject go = Instantiate(_leaderboardEntryPrefab);
            go.transform.SetParent(_leaderboardGrid.transform, false);
            LeaderboardEntry leaderboardEntry = go.GetComponent<LeaderboardEntry>() as LeaderboardEntry;

            string entry = dataPersist.readStringFromFile("scores");
            string[] entries = dataPersist.parseFileString(entry);

            leaderboardEntry.rankString = "1";
            leaderboardEntry.usernameString = entries[0].ToString();
            leaderboardEntry.scoreString = entries[1].ToString();
            _entries.Add(leaderboardEntry);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    //private List<HighscoreEntry> highscoreEntryList;

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        //highscoreEntryList = new List<HighscoreEntry>() {
        //    new HighscoreEntry{ score = 1000, name = "SUSY"},
        //    new HighscoreEntry{ score = 500, name = "DAVID"},
        //    new HighscoreEntry{ score = 143, name = "LALO"},
        //    new HighscoreEntry{ score = 10220, name = "SOFI"},
        //    new HighscoreEntry{ score = 2300, name = "ALAN"},
        //    new HighscoreEntry{ score = 94040, name = "NELVA"},
        //    new HighscoreEntry{ score = 50012, name = "MANUEL"},
        //};

        AddHighscoreEntry(10000, "Just me");
        string json = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(json);


        //Sort entry list by score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        
        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        //string json = JsonUtility.ToJson(highscores);
        //PlayerPrefs.SetString("highscoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> TransformList) {
        float templateHeight = 50f;

        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * TransformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = TransformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;
        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;
        TransformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name) {
        //create highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        //load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //add new entry to highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        //save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private class Highscores 
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}

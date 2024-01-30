using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public string name;
    public int score;

    public HighScoreData(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

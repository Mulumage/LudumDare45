using System;
using System.Collections.Generic;

[Serializable]
public class Dreamlo
{
    public Leaderboard leaderboard;
}

[Serializable]
public class Leaderboard
{
    public List<Entry> entry = new List<Entry>();
}

[Serializable]
public class Entry
{
    public string name;
    public int score;
}
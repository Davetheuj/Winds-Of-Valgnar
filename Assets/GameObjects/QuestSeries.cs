
using System;

[Serializable]
public class QuestSeries 
{
    public int countInSeries;
    public string seriesName;

    public QuestSeries(string name)
    {
        countInSeries = 1;
        seriesName = name;
    }
   
}
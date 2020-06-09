using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StoryProgressionManager
{
    //map progression
    private static int mapSizeCurrent, mapSizeMax, mapSizeMaxUnlocked;

    //enemy progression
    private static int maxEnemyUnlock;
    private static int difficulty;

    //time progression
    private static int currentTimeHours, totalElapsedTimeHours, elapsedTimeDays, elapsedTimeMonths, elapsedTimeYears;

    //skill unlocking progression
    public static Requirements currentRequirementProgress;

    public static void Initialize()
    {
        mapSizeMax = 25;
        mapSizeMaxUnlocked = 5;
        mapSizeCurrent = mapSizeMaxUnlocked;

        maxEnemyUnlock = 6;
        difficulty = Mathf.Clamp(10, 0, 10);

        currentTimeHours = 0;
        UpdateElapsedTime();

        currentRequirementProgress = new Requirements();
        currentRequirementProgress.FullInitialize();
    }

    //Map progression
    public static int GetMapSizeMax()
    {
        return mapSizeMax;
    }
    public static int GetMapSizeMaxUnlocked()
    {
        return mapSizeMaxUnlocked;
    }
    public static int GetMapSize()
    {
        return mapSizeCurrent;
    }
    public static void SetMapSize(int size)
    {
        mapSizeCurrent = Mathf.Clamp(size, 1, mapSizeMaxUnlocked);
    }
    public static int IncrementMapSize(int incrementBy)
    {
        mapSizeCurrent = Mathf.Clamp(mapSizeCurrent + incrementBy, 1, mapSizeMaxUnlocked);
        return mapSizeCurrent;
    }

    //enemy progression
    public static int GetMaxEnemyUnlocked()
    {
        return maxEnemyUnlock;
    }
    public static int GetDifficulty()
    {
        return difficulty;
    }

    //time progression
    private static void UpdateElapsedTime()
    {
        while (currentTimeHours > 24)
        {
            totalElapsedTimeHours += 24;
            currentTimeHours -= 24;
        }
        elapsedTimeDays=Mathf.FloorToInt(totalElapsedTimeHours/24);
        elapsedTimeMonths = Mathf.FloorToInt(elapsedTimeDays / 30);
        elapsedTimeYears = Mathf.FloorToInt(elapsedTimeMonths / 12);
    }
    public static int AddTime(int value)
    {
        currentTimeHours += value;
        UpdateElapsedTime();
        return currentTimeHours;
    }
    public static int GetTimeHours()
    {
        UpdateElapsedTime();
        return totalElapsedTimeHours+currentTimeHours;
    }
    public static int GetTimeDays()
    {
        UpdateElapsedTime();
        return elapsedTimeDays;
    }
    public static int GetTimeMonths()
    {
        UpdateElapsedTime();
        return elapsedTimeMonths;
    }
    public static int GetTimeYears()
    {
        UpdateElapsedTime();
        return elapsedTimeYears;
    }
    public static int GetCurrentTimeHours()
    {
        UpdateElapsedTime();
        return currentTimeHours;
    }
}

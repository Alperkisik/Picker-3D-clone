using System;
using UnityEngine;

public class Custom_Event_Manager : MonoBehaviour
{
    public static Custom_Event_Manager Instance { get; private set; }

    public event EventHandler OnLevelStart;
    public event EventHandler OnLevelFinish;
    public event EventHandler OnLevelStartTap;
    public event EventHandler OnLevelLoaded;
    public event EventHandler OnLevelFailed;
    public event EventHandler OnLevelComplited;

    public event EventHandler OnPlayerReachedPassage;
    public event EventHandler OnPassageBallRequirementFullfilled;
    public event EventHandler OnPlayerClearedPassage;

    public event EventHandler OnPlayerHitClock;

    public event EventHandler OnPlayerReachFinishLine;
    public event EventHandler OnScoreBoardTimerFinished;

    public event EventHandler OnScoreChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }
    public void Event_OnLevelStart()
    {
        OnLevelStart?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnLevelFinish()
    {
        OnLevelFinish?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnLevelTap()
    {
        OnLevelStartTap?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnOnLevelLoaded()
    {
        OnLevelLoaded?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnLevelFailed()
    {
        OnLevelFailed?.Invoke(this, EventArgs.Empty);
        Event_OnLevelFinish();
    }
    public void Event_OnLevelComplited()
    {
        OnLevelComplited?.Invoke(this, EventArgs.Empty);
        Event_OnLevelFinish();
    }
    public void Event_OnPlayerReachedPassage()
    {
        OnPlayerReachedPassage?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnPassageBallRequirementFullfilled()
    {
        OnPassageBallRequirementFullfilled?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnPlayerClearedPassage()
    {
        OnPlayerClearedPassage?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnPlayerHitClock()
    {
        OnPlayerHitClock?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnPlayerReachFinishLine()
    {
        OnPlayerReachFinishLine?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnScoreBoardTimerFinished()
    {
        OnScoreBoardTimerFinished?.Invoke(this, EventArgs.Empty);
    }
    public void Event_OnScoreChanged()
    {
        OnScoreChanged?.Invoke(this, EventArgs.Empty);
    }
}

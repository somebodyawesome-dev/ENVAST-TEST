using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "attemptsCounter", menuName = "ScriptableObjects/attempts counter", order = 1)]
public class AttemptsCounter : ScriptableObject
{
    public int attempts;
    public void addAttempt()
    {
        attempts++;
    }
    public void setAttempts(int i)
    {
        attempts = i;
    }
}

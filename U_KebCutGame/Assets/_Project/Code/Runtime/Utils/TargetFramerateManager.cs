using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFramerateManager : MonoBehaviour
{
    [SerializeField] private int targetFrameRate = 60;

    void Awake()
    {
        Application.targetFrameRate = targetFrameRate;

        Debug.LogWarning($"Target FPS: {Application.targetFrameRate}");
    }

}

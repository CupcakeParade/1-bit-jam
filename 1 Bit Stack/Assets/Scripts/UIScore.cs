using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    private int score;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameManager.OnCubeSpawned += GameManager_OnCubeSpawned;
    }

    private void OnDestroy()
    {
        GameManager.OnCubeSpawned -= GameManager_OnCubeSpawned;
    }
    private void GameManager_OnCubeSpawned()
    {
        score ++;
        text.text = "Score: " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScoreCount : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreCount;

    private void OnEnable()
    {
        _player.ScoreZoneEntered += ScoreCountChanged;
    }

    private void OnDisable()
    {
        _player.ScoreZoneEntered -= ScoreCountChanged;
    }

    private void ScoreCountChanged(int currentCount)
    {
        _scoreCount.text = currentCount.ToString();
    }
}
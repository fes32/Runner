using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _openPanel;
    [SerializeField] private GameObject _closePanel;
    [SerializeField] private Button _resetButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _player.Dying += GameOver;
        _resetButton.onClick.AddListener(OnResetButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Dying -= GameOver;
        _resetButton.onClick.RemoveListener(OnResetButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _closePanel.SetActive(false);
        _openPanel.SetActive(true);
        _score.text = _player.Score.ToString();
    }

    public void OnResetButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
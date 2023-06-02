using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreValueText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Health.OnPlayerDeath += ActivateGameOject;
        Health.OnEnemyDeath += CountScore;
        this.gameObject.SetActive(false);
    }

    private void OnDestroy() {
        Health.OnPlayerDeath -= ActivateGameOject;
        Health.OnEnemyDeath -= CountScore;
    }

    public void RetrunToMenu() {
        SceneManager.LoadScene(0);
    }

    private void CountScore() {
        score++;
    }

    private void ActivateGameOject() {
        this.gameObject.SetActive(true);
        scoreValueText. text = score.ToString();
    }
}

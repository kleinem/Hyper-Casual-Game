using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    
    public int score = 0;
    public Animator Game;
    public GameObject pellet;
    public Vector3 menuPosition = Vector3.zero;
    public Vector3 gamePosition = Vector3.zero;
    public TextMeshProUGUI comboText;
    bool spawning = false;
    float nextSpawn = 0f;


    Vector3 targetPosition = new Vector3();

    void Start() {

        targetPosition = menuPosition;

    }

    void Update() {

        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        if (spawning && Time.time >= nextSpawn) {

            GameObject tmp = Instantiate(pellet, new Vector3(Random.Range(-2.3f, 2.3f), 8, -0.1f), Quaternion.identity);
            nextSpawn = Random.Range(0.6f,2.2f) + Time.time;

        }

    }

    public void registerHit() {

        score++;
        if (score <= PlayerPrefs.GetInt("highScore")) {

            comboText.SetText("COMBO : " + score + "\n" + "(MAX " + PlayerPrefs.GetInt("highScore") + ")");
            Debug.Log("COMBO : " + score + "\n" + "(MAX " + PlayerPrefs.GetInt("highScore") + ")");

        }
        else {

            comboText.SetText("COMBO : " + score + "\n" + "(RECORD!)");
            Debug.Log("COMBO : " + score + "\n" + "(RECORD!)");
            PlayerPrefs.SetInt("highScore", score);

        }

    }

    public void registerMiss() {

        score = 0;
        comboText.SetText("COMBO : " + score + "\n" + "(MAX " + PlayerPrefs.GetInt("highScore") + ")");

    }

    public void startGame() {

        StartCoroutine(gameSequence());

    }

    private IEnumerator gameSequence() {

        yield return new WaitForSeconds(0.5f);
        gameCam(true);
        yield return new WaitForSeconds(1.0f);
        Game.SetTrigger("Display Hints");
        yield return new WaitForSeconds(7.0f);
        Game.SetTrigger("Hide Hints");
        spawning = true;

    }

    public void quitGame() {

        gameCam(false);

    }

    void gameCam(bool isInGame_) {

        if (isInGame_) {

            targetPosition = gamePosition;

        }
        else {

            targetPosition = menuPosition;

        }

    }

    
}

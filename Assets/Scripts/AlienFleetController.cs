using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AlienFleetController : MonoBehaviour
{
    [SerializeField]
    float moveTime = 2f, speed = 0.3f;
    int moveCounter = 0, moveDir;
    public bool isGameRunning = false;
    GameObject[] rows;
    public TMP_Text endText, reloadText;
    Leader leader;

    private void Start()
    {
        leader = GameObject.FindGameObjectWithTag("AlienLeader")
            .GetComponent<Leader>();
        endText.gameObject.SetActive(false);
        reloadText.gameObject.SetActive(false);
        rows = GameObject.FindGameObjectsWithTag("rows");
        moveDir = 1;
        StartGame();
    }
    public void StartGame()
    {
        InvokeRepeating("Move", moveTime / 16, moveTime / 16);
        leader.StartLeader();
        isGameRunning = true;
    }
    private bool AreAllRowsDead()
    {
        foreach(GameObject row in rows)
        {
            if(row.transform.childCount != 0)
            {
                return false;
            }
        }
        return true;
    }
    private void Update()
    {
        if (AreAllRowsDead() && isGameRunning)
        {
            StopGame(true);
        }
        if (!isGameRunning && Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(0);
    }
    private void Move()
    {
        Vector3 move = new Vector3(speed * moveDir /16, 0f, 0f);
        transform.position += move;
        moveCounter += moveDir;

        if (moveCounter >= 40 || moveCounter <= -40)
        {
            moveDir *= -1;
            transform.position -= new Vector3(0f / 6, speed / 6, 0f);
        }
    }
    public void StopGame(bool isWinning)
    {
        Debug.Log($"The game has ended. Player won: {isWinning}");
        string text = isWinning ? "Win!" : "Lose!";
        endText.SetText(text);
        endText.gameObject.SetActive(true);
        reloadText.gameObject.SetActive(true);
        leader.StopLeader();

        CancelInvoke("Move");
        isGameRunning = false;
    }
}

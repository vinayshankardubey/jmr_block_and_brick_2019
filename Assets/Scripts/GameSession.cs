using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config params

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f; // initialized at 1f; Range allows it to be a slider in the inspector in Unity
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText; // allows us to link to the text within Unity Inspector
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] TextMeshProUGUI levelTitleText;
    [SerializeField] bool isControllerEnabled = false;

    // State variables

    [SerializeField] int currentScore = 0;

    // this comes from studying the Unity game loop Awake happens before Start
    private void Awake() // this implements the singleton pattern
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;  //there's an 's' this time. Plural objects
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false); // this is needed to prevent weird bugs in the singleton.
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        scoreText.text = currentScore.ToString();
        levelTitleText.text = FindObjectOfType<Level>().GetLevelTitle();
        Debug.Log(Options.mouse);
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        levelTitleText.text = FindObjectOfType<Level>().GetLevelTitle();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    //this allows score to reset when the game restarts
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}

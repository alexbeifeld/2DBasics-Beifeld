using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private int count;
    private int maxPickups = 10;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private Text countText;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForWin();
    }

    void CheckForWin()
    {
        count = player.GetComponent<PlayerController>().Count;
        UpdateUI();

        if (count >= maxPickups)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void UpdateUI()
    {
        countText.text = "Count: " + count.ToString() + "/" + maxPickups.ToString(); ;
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

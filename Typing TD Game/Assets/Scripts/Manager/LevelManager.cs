using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        CheckLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckLevel()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);

        for(int i = 0;i < levelButtons.Length;i++)
        {
            if(levelReached < i + 1)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void GoToLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

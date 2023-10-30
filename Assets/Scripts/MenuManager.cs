using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//#if UNITY_EDITOR
//using UnityEditor;
//# endif  

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TMP_InputField inputFieldName;
    private string nameID;
    private int bestScore;
    public Button startButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        bestScore = DataPersistanceManager.Instance.BestScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputFieldName.text != "" || nameID != null)
        {
            TitleTextChange();
        }
    }

    public void ReadUserInput(string userInputName) 
    {
        nameID = userInputName;
    }

    public void TitleTextChange() 
    {
        titleText.text = "Best score : " + nameID+ " : " +bestScore;
        DataPersistanceManager.Instance.NameID = nameID;
    }

    public void StartGame() 
    {
        if (inputFieldName.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame() 
    {
//#if UNITY_EDITOR
//        EditorApplication.ExitPlaymode();
//#else
    Application.Quit();
    }
}

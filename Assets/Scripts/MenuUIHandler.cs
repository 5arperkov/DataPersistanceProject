using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_Text player;
    public void StartTheGame()
    {
        Menu.Instance.playerName = player.text;
        SceneManager.LoadScene(1);
        // Debug.Log("Player name is "+player.text);
        // Debug.Log(Menu.Instance.playerName);
    }

    public void Exit()
    {
# if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
# else
    Application.Quit();
# endif
    }
}

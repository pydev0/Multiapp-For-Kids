using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ButtonsController : MonoBehaviour
{

    public GameObject settingsPanel;
    public string nameScene;

    public Animation wrongAnswerAnim;
    public Animation inviseAnim;
    public Animation winPanelAnim;

    public Button[] buttonsBigLess;

    public int levelToUnlock;
    int numberOfUnlockedLevels;

    public string key;

    public AudioSource winAudio;
    public AudioSource wrongAudio;

    public void Buttons()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void SettingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void ExitSettingsButton()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void WrongTextButton()
    {
        wrongAudio.Play();
        inviseAnim.Play();
        wrongAnswerAnim.Play();

        StartCoroutine(DelayCheckButton());
    }

    public void WinButton()
    {
        winAudio.Play();
        winPanelAnim.Play();

        for (int i = 0; i < buttonsBigLess.Length; i++)
        {
            buttonsBigLess[i].interactable = false;
        }

        numberOfUnlockedLevels = PlayerPrefs.GetInt(key);

        if (numberOfUnlockedLevels <= levelToUnlock)
        {
            PlayerPrefs.SetInt(key, numberOfUnlockedLevels + 1);
        }
    }

    IEnumerator DelayCheckButton()
    {
        for (int i = 0; i < buttonsBigLess.Length; i++)
        {
            buttonsBigLess[i].interactable = false;
        }
        
        yield return new WaitForSeconds(3);

        for (int i = 0; i < buttonsBigLess.Length; i++)
        {
            buttonsBigLess[i].interactable = true;
        }
    }
}

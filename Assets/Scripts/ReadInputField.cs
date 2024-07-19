using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadInputField : MonoBehaviour
{
    public Button checkButton;
    public TMP_InputField inputUser;

    public GameObject winPanel;
    
    public Animation wrongAnswerAnim;
    public Animation inviseAnim;
    public Animation winPanelAnim;

    public string answer;

    public int levelToUnlock;
    int numberOfUnlockedLevels;

    public string key;

    public AudioSource winAudio;
    public AudioSource wrongAudio;

    private void Start()
    {
        checkButton.onClick.AddListener(ReadStringInput);
    }

    public void ReadStringInput()
    {
        if (inputUser.text.ToLower() == answer)
        {
            winAudio.Play();
            winPanelAnim.Play();
            checkButton.interactable = false;

            numberOfUnlockedLevels = PlayerPrefs.GetInt(key);

            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt(key, numberOfUnlockedLevels + 1);
            }
        }
        else
        {
            wrongAudio.Play();
            inviseAnim.Play();
            wrongAnswerAnim.Play();
           
            StartCoroutine(DelayCheckButton());
        }
    }

    IEnumerator DelayCheckButton()
    {
        checkButton.interactable = false;
        yield return new WaitForSeconds(3);
        checkButton.interactable = true;
    }
}

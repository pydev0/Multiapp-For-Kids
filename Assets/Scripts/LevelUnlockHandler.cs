using UnityEngine;
using UnityEngine.UI;


public class LevelUnlockHandler : MonoBehaviour
{
    public Button[] buttons;
    public int unlockedLevelsNumber;

    public string key;

    private void Start()
    {
        if (!PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.SetInt(key, 1);
        }

        unlockedLevelsNumber = PlayerPrefs.GetInt(key);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    private void Update()
    {
        unlockedLevelsNumber = PlayerPrefs.GetInt(key);
        
        for (int i = 0; i < unlockedLevelsNumber; i++)
        {
            buttons[i].interactable = true;
        }
    }
}

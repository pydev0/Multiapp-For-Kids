using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider slider;
    public AudioSource audios;
    public GameObject bgMusic;
    public GameObject[] objs11;

    private void Awake()
    {
        objs11 = GameObject.FindGameObjectsWithTag("Sound");

        if (objs11.Length == 0) 
        { 
            bgMusic = Instantiate(bgMusic);
            bgMusic.name = "bgMusic";
            DontDestroyOnLoad(bgMusic.gameObject);
        }
        else
        {
            bgMusic = GameObject.Find("bgMusic");
        }
    }

    private void Start()
    {
        audios = bgMusic.GetComponent<AudioSource>();
    }

    private void Update()
    {
        audios.volume = slider.value;
    }
}

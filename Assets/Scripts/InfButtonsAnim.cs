using UnityEngine;
using UnityEngine.Video;

public class InfButtonsAnim : MonoBehaviour
{
    public Animation NextSlideAnim1;
    public Animation NextSlideAnim2;
    public Animation PreviousSlideAnim1;
    public Animation PreviousSlideAnim2;

    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public void NextSlide()
    {
        audioSource1.Stop();
        NextSlideAnim1.Play();
        NextSlideAnim2.Play();
        audioSource2.Play();
    }
}

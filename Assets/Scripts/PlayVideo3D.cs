using UnityEngine;
using UnityEngine.Video;

public class Play : MonoBehaviour
{
    [SerializeField]
    GameObject video;

    [SerializeField]
    bool isPlaying;

    public void OnPlayVideo()
    {
        VideoPlayer videoPlayer = video.GetComponent<VideoPlayer>();

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            isPlaying = false;
        }
        else
        {
            videoPlayer.Play();
            isPlaying = true;
        }
    }
}

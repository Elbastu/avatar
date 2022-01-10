using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public interface InterfaceTelechargerMedia
{
    public void LoadMedia(string urlVideo, VideoPlayer videoPlayer, string urlAudio,
        string UrlImage,RawImage _rawImage, AudioSource audioSource,GameObject viewImage_video);
}

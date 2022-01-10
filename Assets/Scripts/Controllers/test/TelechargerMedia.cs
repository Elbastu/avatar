using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class TelechargerMedia : Telecharger_cours,InterfaceTelechargerMedia
{

    public UnityEvent newQuestion;

    //    InterfaceAfficherQuestion interfaceAfficherQuestion;
    InterfaceAnimerAvatar interfaceAnimerAvatar;
    InterfaceVerifyResponse interfaceVerifyResponse;
    public void LoadMedia(string urlVideo, VideoPlayer videoPlayer, 
        string urlAudio, string urlImage, RawImage _rawImage,
        AudioSource audioSource, GameObject viewImage_video)
    {
        viewImage_video.SetActive(false);
        if(urlVideo != "none")
        {
            viewImage_video.SetActive(true);
            LoadVideo(urlVideo, videoPlayer,_rawImage);
        }
        else if (urlImage != "none")
        {
            viewImage_video.SetActive(true);
            LoadImage(urlImage, _rawImage);
        }
        else if(urlAudio != "none")
        {
            LoadAudio(urlAudio, audioSource);
        }
    }

    public void LoadVideo(string urlVideo, VideoPlayer videoPlayer,RawImage rawImage)
    {
        videoPlayer.url = urlVideo;
        videoPlayer.loopPointReached += CheckOver;
    }
    void CheckOver(VideoPlayer videoPlayer)
    {
        //Debug.Log("la vidéo est terminée");
        MediaFinished();
    }
    public void LoadAudio(string urlAudio,AudioSource audioSource)
    {
        StartCoroutine(DownloadAudio(urlAudio,audioSource));
    }
    IEnumerator DownloadAudio(string urlAudio,AudioSource audioSource)
    {
        UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(urlAudio, AudioType.MPEG);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            StartCoroutine(DownloadAudio( urlAudio,  audioSource));
        }
        else
        {
            AudioClip clip;
            clip = DownloadHandlerAudioClip.GetContent(request);
            audioSource.clip = clip;
            audioSource.Play();
            // control the end of the audio
            Invoke("MediaFinished", audioSource.clip.length);
        }
    }
    public void LoadImage(string urlImage, RawImage _rawImage)
    {
        StartCoroutine(DownloadImage(urlImage,  _rawImage));
    }
    IEnumerator DownloadImage(string urlImage, RawImage _rawImage)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(urlImage);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            StartCoroutine(DownloadImage(urlImage, _rawImage));
        }
        else
        {
            Debug.Log("image telechargée");
            _rawImage.texture = DownloadHandlerTexture.GetContent(request);
            // wait 5.0 secondes after loading Image
            Invoke("MediaFinished", 6.0f);
        }
    }
    public abstract void MediaFinished(); // class need question in Mainview
   
    // Gerer la réponse de l'utilisateur
    public void RequestIdentification(string myInput,string myRealAnswer, Animator animator)
    {
        Debug.Log(myInput);
        if (myInput.Contains("?"))
        {
            Debug.Log("request sent to chatbot ... ...");
        }
        else
        {
            Debug.Log("verifier la réponse ... ...");
            interfaceVerifyResponse = new VerifyResponse();
            //interfaceVerifyResponse.sendToInterpreter(myInput);
            interfaceAnimerAvatar = new AnimerAvatar();
            if (interfaceVerifyResponse.isCorrectAnswer(myInput,myRealAnswer))
            {
                Debug.Log("bonne réponse");
                interfaceAnimerAvatar.Animer_avatar("good_response", animator);
                newQuestion.Invoke();
            }
            else
            {
                Debug.Log("mauvaise réponse");
                interfaceAnimerAvatar.Animer_avatar("bad_response", animator);
            }
        }
    }


}

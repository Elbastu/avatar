using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Telecharger_cours : MonoBehaviour
{

    static string URL = "http://localhost:8000/test.json";
    public FormatCours formatCours;

    public void Telechargement_cours()
    {
        StartCoroutine(DownloadMyJson(URL));
    }

    IEnumerator DownloadMyJson(object url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(URL))
        {
            yield return www.SendWebRequest();
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                DownloadMyJson(url);
            }
            else
            {
                var text = www.downloadHandler.text;
                Debug.Log(text);
                formatCours = JsonUtility.FromJson<FormatCours>(text);
            }
        }
    }
}


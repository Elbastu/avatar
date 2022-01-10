using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine;

public class MainView : TelechargerMedia
{
    int i = 0;

   // public Text textQuestion;
    public VideoPlayer videoPlayer;
    public static string videoURL;
    public GameObject viewImage_video;
    public InputField userEntry;
    public Animator animator;
    public RawImage _rawImage;
    public AudioSource audioSource;
    public Text textQuestion;
    public string currentQuestion;
    public string realAnswer;
    private Texture tex;

    // Awake is called after Start()
    public void Awake()
    {
        Telechargement_cours();
    }
    // Start is called before the first frame update
    void Start()
    {

        tex = videoPlayer.targetTexture;
        // lancer la m�dia
        /*   LoadMedia(formatCours.cours[0].videoURL, videoPlayer, formatCours.cours[0].audioURL, formatCours.cours[0].imageURL, _rawImage, audioSource, viewImage_video);
           // A la fin de la m�dia , Poser la question
        /*  currentQuestion = formatCours.cours[0].question;
           // LoadQuestion(formatCours.cours[0].question, textQuestion);
        /*  realAnswer = formatCours.cours[0].reponse;*/
        // r�cup�rer la r�ponse avec l'evenement onEndEdit
        // lancer l'animation appropri�e en fonction de l'animation
        NextQuestion();
        

    }

    
    public void  NextQuestion()
    {
        if (i < formatCours.cours.Count)
        {
            viewImage_video.SetActive(true);
            // lancer la m�dia
            LoadMedia(formatCours.cours[i].videoURL, videoPlayer, formatCours.cours[i].audioURL,
                formatCours.cours[i].imageURL, _rawImage, audioSource, viewImage_video);
            // A la fin de la m�dia , Poser la question
            currentQuestion = formatCours.cours[i].question;
            // LoadQuestion(formatCours.cours[0].question, textQuestion);
            realAnswer = formatCours.cours[i].reponse;
            // r�cup�rer la r�ponse avec l'evenement onEndEdit
            // lancer l'animation appropri�e en fonction de l'animation
            i = i + 1;
        }
        else
        {
            Debug.Log("le cours est termin� !");
        }

    }


    // declarer dans TelechargerMedia pour l'affichage
    public override void MediaFinished()
    {
        _rawImage.texture = tex;
        Debug.Log("hello abstract");
        textQuestion.text = currentQuestion;
        userEntry.onEndEdit.RemoveAllListeners();
        //suivre l'evenemt entr�e de l'utilisateur
        //userEntry.onEndEdit.AddListener(RequestIdentification);
        userEntry.onEndEdit.AddListener(delegate { RequestIdentification(userEntry.text,realAnswer,animator); });
        viewImage_video.SetActive(false);


    }
  

}

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
        // lancer la média
        /*   LoadMedia(formatCours.cours[0].videoURL, videoPlayer, formatCours.cours[0].audioURL, formatCours.cours[0].imageURL, _rawImage, audioSource, viewImage_video);
           // A la fin de la média , Poser la question
        /*  currentQuestion = formatCours.cours[0].question;
           // LoadQuestion(formatCours.cours[0].question, textQuestion);
        /*  realAnswer = formatCours.cours[0].reponse;*/
        // récupérer la réponse avec l'evenement onEndEdit
        // lancer l'animation appropriée en fonction de l'animation
        NextQuestion();
        

    }

    
    public void  NextQuestion()
    {
        if (i < formatCours.cours.Count)
        {
            viewImage_video.SetActive(true);
            // lancer la média
            LoadMedia(formatCours.cours[i].videoURL, videoPlayer, formatCours.cours[i].audioURL,
                formatCours.cours[i].imageURL, _rawImage, audioSource, viewImage_video);
            // A la fin de la média , Poser la question
            currentQuestion = formatCours.cours[i].question;
            // LoadQuestion(formatCours.cours[0].question, textQuestion);
            realAnswer = formatCours.cours[i].reponse;
            // récupérer la réponse avec l'evenement onEndEdit
            // lancer l'animation appropriée en fonction de l'animation
            i = i + 1;
        }
        else
        {
            Debug.Log("le cours est terminé !");
        }

    }


    // declarer dans TelechargerMedia pour l'affichage
    public override void MediaFinished()
    {
        _rawImage.texture = tex;
        Debug.Log("hello abstract");
        textQuestion.text = currentQuestion;
        userEntry.onEndEdit.RemoveAllListeners();
        //suivre l'evenemt entrée de l'utilisateur
        //userEntry.onEndEdit.AddListener(RequestIdentification);
        userEntry.onEndEdit.AddListener(delegate { RequestIdentification(userEntry.text,realAnswer,animator); });
        viewImage_video.SetActive(false);


    }
  

}


using System.Collections.Generic;

[System.Serializable]
public class FormatCours
{
    public List < Cours > cours;
}
[System.Serializable]
public class Cours 
{ 
    public  string question;
    public  string reponse;
    public  string action;
    public  string audioURL;
    public  string videoURL;
    public string imageURL;


}
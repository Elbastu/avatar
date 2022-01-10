using UnityEngine;

public class VerifyResponse : InterfaceVerifyResponse
{
    public bool isCorrectAnswer(string response, string trueResponse)
    {
        if (response == trueResponse) return true;
        else return false;
    }

    public void sendToInterpreter(string response)
    {
        Debug.Log("ma réponse se traite ici !");
    }


}

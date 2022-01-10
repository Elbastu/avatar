using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceVerifyResponse 
{
    public void sendToInterpreter(string response);

    public bool isCorrectAnswer(string response, string trueResponse);
}

using System;
using UnityEngine;

public class Message : MonoBehaviour
{
    // public RectTransform messagePos;
    public void MessageDispatcher(string header, string body, string type)
    {
        switch (type)
        {
            case "ERROR":
                ErrorMessageHandler(header, body);
                break;
            case "WARNING":
                WarningMessageHandler();
                break;
            case "DEBUG":
                DebugMessageHandler();
                break;
            case "CONFIRMATION":
                ConfirmationMessageHandler();
                break;
            case "INFORMATION":
                InformationMessageHandler();
                break;
            default:
                break;
        }

    }

    private void InformationMessageHandler()
    {
        throw new NotImplementedException();
    }

    private void ConfirmationMessageHandler()
    {
        throw new NotImplementedException();
    }

    private void DebugMessageHandler()
    {
        throw new NotImplementedException();
    }

    private void WarningMessageHandler()
    {
        throw new NotImplementedException();
    }

    private void ErrorMessageHandler(string header, string body)
    {
        GetComponent<Error>().ErrorDispatch(header, body);
    }


}




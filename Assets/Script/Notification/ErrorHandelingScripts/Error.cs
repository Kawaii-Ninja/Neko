using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    public GameObject errorMessagePrefab;
    public GameObject notificationContainer;
    private Queue<ErrorNotification> notificatiosQueue = new();
    private bool isDisplayingNotification = false;

    // Dispatch the error message
    public void ErrorDispatch(string header, string body)
    {
        var notification = new ErrorNotification(header, body);
        notificatiosQueue.Enqueue(notification);
        if (!isDisplayingNotification)
        {
            StartCoroutine(DisplayNotificationsCoroutine());
        }
    }

    // Display the Error messages in Queue
    private IEnumerator DisplayNotificationsCoroutine()
    {
        isDisplayingNotification = true;

        while (notificatiosQueue.Count > 0)
        {
            yield return new WaitForSeconds(1f); //wait for 1 sec before displaying the next message.
            var notification = notificatiosQueue.Dequeue();
            DisplayMessage(notification);
        }
        isDisplayingNotification = false;
    }

    // Display individual message
    private void DisplayMessage(ErrorNotification notification)
    {

        GameObject errorInstance = Instantiate(errorMessagePrefab, notificationContainer.transform);
        errorInstance.transform.SetAsFirstSibling();
        ErrorMessage errorMessageComponent = errorInstance.GetComponent<ErrorMessage>();
        errorMessageComponent.errorHeaderText.text = notification.Header;
        errorMessageComponent.errorBodyText.text = notification.Body;
        StartCoroutine(DeleteNotificationAfterDelay(errorInstance));

    }

    // Destroy the error message after a timeout
    IEnumerator DeleteNotificationAfterDelay(GameObject errorNotification)
    {
        yield return new WaitForSeconds(30f);
        ErrorMessage errorMessageComponent = errorNotification.GetComponent<ErrorMessage>();
        errorMessageComponent.animator.SetBool("SlideOut", true);
        yield return new WaitForSeconds(.5f);
        Destroy(errorNotification);
    }
}


[Serializable]
public class ErrorNotification
{
    public string Header;
    public string Body;

    public ErrorNotification(string header, string body)
    {
        Header = header;
        Body = body;
    }
}

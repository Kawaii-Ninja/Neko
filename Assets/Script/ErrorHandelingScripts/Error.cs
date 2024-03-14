using System.Collections;
using UnityEngine;

public class Error : MonoBehaviour
{
    public GameObject errorMessageBox;
    public GameObject notificationBox;
    public void NotificationError(string header, string body)
    {
        GameObject error = Instantiate(errorMessageBox, notificationBox.transform);
        error.GetComponent<ErrorMessage>().errorHeaderText.text = header;
        error.GetComponent<ErrorMessage>().errorBodyText.text = body;
        StartCoroutine(DeletNotification(error));
    }

    IEnumerator DeletNotification(GameObject error)
    {
        yield return new WaitForSeconds(6f);
        Destroy(error);
    }
}

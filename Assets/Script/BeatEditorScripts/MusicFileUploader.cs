using UnityEngine;
using TMPro;
using System.IO;

public class MusicFileUploader : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    static public string audioFilePath;

    public void UploadSong()
    {
        // Open file browser dialog.
        string filePath = UnityEditor.EditorUtility.OpenFilePanel("Select Song", "", "mp3,wav");
        
        // Check if a file was selected.
        if(!string.IsNullOrEmpty(filePath))
        {
            if(filePath.ToLower().EndsWith(".mp3")||filePath.ToLower().EndsWith(".wav"))
            {
                // display feedback to user
                feedbackText.text = "Song uploades: " + Path.GetFileName(filePath);
                audioFilePath = filePath;
                Debug.Log("File Path: " + filePath);
            }
            else
            {
                feedbackText.text = "Invalid file format. Please select an MP3 or WAV file.";
            }
        }
        else
        {
            feedbackText.text = "No file selected.";
        }
    }
}

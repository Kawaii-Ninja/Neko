using UnityEngine;
using TMPro;
// using SFB;
using System.Collections;

public class OldMusicFileUploader : MonoBehaviour
{
    public TextMeshProUGUI feedbackText;
    static public string audioFilePath;
    public AudioSource audioSource;

    public void OpenFileBrowser()
    {
//         var extensions = new[]
//         {
//             new ExtensionFilter("Audio Files", "mp3", "wav", "ogg"),
//         };

//         var paths = StandaloneFileBrowser.OpenFilePanel("Open Audio File", "", extensions, false);

//         if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
//         {
//             // feedbackText.text = paths[0];
//             // audioFilePath = paths[0];
//             Debug.Log("Selected audio file path: " + paths[0]);
//             StartCoroutine(LoadAndPlayAudio(paths[0]));
//         }
//         else
//         {
//             Debug.Log("No audio file selected: ");
//         }
    }

//     private IEnumerator LoadAndPlayAudio(string filePath)
//     {
// //         Debug.Log("Audio Loading......");
// //         using WWW www = new("file://" + filePath);
// //         yield return www;
// //         audioSource.clip = www.GetAudioClip();
// //         audioSource.Play();
// //         Debug.Log("Playing Audio......");
//     }


}

//     // public void UploadSong()
//     // {
//     //     string filePath = null;
//     //     #if UNITY_EDITOR
//     //      filePath = UnityEditor.EditorUtility.OpenFilePanel("Select Song", "", "mp3,wav");
//     //     if (!string.IsNullOrEmpty(filePath))
//     //     {
//     //         if (filePath.ToLower().EndsWith(".mp3") || filePath.ToLower().EndsWith(".wav"))
//     //         {
//     //             // Display feedback to user
//     //             feedbackText.text = "Song uploaded: " + Path.GetFileName(filePath);
//     //             audioFilePath = filePath;
//     //             Debug.Log("File Path: " + filePath);
//     //         }
//     //         else
//     //         {
//     //             feedbackText.text = "Invalid file format. Please select an MP3 or WAV file.";
//     //         }
//     //     }
//     //     else
//     //     {
//     //         feedbackText.text = "No file selected.";
//     //     }
//     //     #else
//     //     feedbackText.text = "File upload not supported in this build.";
//     //     #endif
    // }
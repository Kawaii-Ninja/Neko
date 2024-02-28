// using UnityEngine;
// using UnityEditor;
// using TMPro;
// using System.IO;

// namespace EditorScripts // Add a namespace to avoid naming conflicts
// {
//     [CustomEditor(typeof(MusicFileUploader))]
//     public class MusicFileUploaderEditor : Editor
//     {
//         public override void OnInspectorGUI()
//         {
//             base.OnInspectorGUI();

//             MusicFileUploader uploader = (MusicFileUploader)target;

//             if (GUILayout.Button("Upload Song"))
//             {
//                 string filePath = EditorUtility.OpenFilePanel("Select Song", "", "mp3,wav");
//                 if (!string.IsNullOrEmpty(filePath))
//                 {
//                     if (filePath.ToLower().EndsWith(".mp3") || filePath.ToLower().EndsWith(".wav"))
//                     {
//                         // Display feedback to user
//                         uploader.feedbackText.text = "Song uploaded: " + Path.GetFileName(filePath);
//                         MusicFileUploader.audioFilePath = filePath;
//                         Debug.Log("File Path: " + filePath);
//                     }
//                     else
//                     {
//                         uploader.feedbackText.text = "Invalid file format. Please select an MP3 or WAV file.";
//                     }
//                 }
//                 else
//                 {
//                     uploader.feedbackText.text = "No file selected.";
//                 }
//             }
//         }
//     }
// }

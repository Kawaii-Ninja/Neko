using System.IO;
using UnityEngine;

public class RandomDirectoryCreator : MonoBehaviour
{
    private string basePath;
    private System.Random rnd = new();

    private void Awake()
    {
        basePath = Application.persistentDataPath + "/files";
    }
    public void CreateDirectory()
    {
        if (!Directory.Exists(basePath)) // Ensure the basePath exists before proceeding.
        {
            Directory.CreateDirectory(basePath);
        }

        CheckDirectory();
    }

    // Checks the current state of directories and decides whether to create a new directory or a subdirectory.
    private void CheckDirectory()
    {
        // If there are already folders within basePath, and check each folder to ensure that they have the desired structure.
        if (FolderCounter.CountFolders(basePath) > 0)
        {
            foreach (string folder in Directory.GetDirectories(basePath)) //inside the files directory 
            {
                // If a folder does not have exactly 10 subfolders, create the next subfolder and return.

                if (FolderCounter.CountFolders(folder) != 10)
                {
                    CreateSubFolder(folder);
                    return;
                }
            }

            // If all existing folders have 10 subfolders, create a new directory at the base path.
            CreateNewDirectory(basePath);
        }
        else
        {
            // If there are no folders in basePath, create a new directory.
            CreateNewDirectory(basePath);
        }
    }

    // Creates a new directory with a unique name within the specified path.
    private void CreateNewDirectory(string path)
    {
        string newDirectoryPath = Path.Combine(path, GenerateUniqueRandomDirectoryName());
        Directory.CreateDirectory(newDirectoryPath);
        CreateSubFolder(newDirectoryPath);
    }

    // The directory in which to create the base folder.
    private void CreateSubFolder(string directory)
    {
        int totalfolders = FolderCounter.CountFolders(directory);
        Directory.CreateDirectory(Path.Combine(directory, totalfolders.ToString("D2")));
    }

    // Generates a unique directory name
    private string GenerateUniqueRandomDirectoryName()
    {
        string path;
        do
        {
            char letter1 = (char)rnd.Next(65, 91);
            char letter2 = (char)rnd.Next(65, 91);
            string directoryName = $"{letter1}{letter2}";
            path = Path.Combine(basePath, directoryName);
        }
        while (Directory.Exists(path));

        return Path.GetFileName(path);
    }

}


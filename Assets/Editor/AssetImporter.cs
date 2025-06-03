using UnityEditor;
using UnityEngine;
using System.IO;

public class AssetImporter : EditorWindow
{
    private string sourceFolder = "";
    private string targetFolder = "Assets/";

    [MenuItem("Tools/Asset Importer")]
    public static void ShowWindow()
    {
        GetWindow<AssetImporter>("Asset Importer");
    }

    void OnGUI()
    {
        GUILayout.Label("Bulk Asset Importer", EditorStyles.boldLabel);
        EditorGUILayout.Space(10);

        // Source Folder
        EditorGUILayout.BeginHorizontal();
        sourceFolder = EditorGUILayout.TextField("Source Folder", sourceFolder);
        if (GUILayout.Button("Select", GUILayout.Width(60)))
        {
            sourceFolder = EditorUtility.OpenFolderPanel("Select Source Folder", "", "");
        }
        EditorGUILayout.EndHorizontal();

        // Target Folder
        EditorGUILayout.BeginHorizontal();
        targetFolder = EditorGUILayout.TextField("Target Folder", targetFolder);
        if (GUILayout.Button("Select", GUILayout.Width(60)))
        {
            string path = EditorUtility.SaveFolderPanel("Select Target Folder", "Assets", "");
            if (!string.IsNullOrEmpty(path))
            {
                targetFolder = "Assets" + path.Substring(Application.dataPath.Length);
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(20);

        // Import Button
        if (GUILayout.Button("Import Assets", GUILayout.Height(40)))
        {
            if (Directory.Exists(sourceFolder))
            {
                ImportAssets();
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "Source folder not found!", "OK");
            }
        }
    }

    private void ImportAssets()
    {
        try
        {
            // Get all files (excluding meta files)
            string[] files = Directory.GetFiles(sourceFolder, "*.*", SearchOption.AllDirectories);
            int fileCount = 0;
            int totalFiles = files.Length;

            foreach (string file in files)
            {
                // Skip meta files
                if (file.EndsWith(".meta")) continue;

                string fileName = Path.GetFileName(file);
                string relativePath = file.Substring(sourceFolder.Length).TrimStart(Path.DirectorySeparatorChar);
                string destPath = Path.Combine(targetFolder, relativePath).Replace("\\", "/");

                // Create target directory
                string destDirectory = Path.GetDirectoryName(destPath);
                if (!Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }

                // Copy file (overwrite existing)
                File.Copy(file, destPath, true);
                fileCount++;

                // Show progress
                EditorUtility.DisplayProgressBar("Importing Assets",
                    $"Copying: {fileName}",
                    (float)fileCount / totalFiles);
            }

            // Refresh Unity database
            AssetDatabase.Refresh();

            EditorUtility.ClearProgressBar();
            EditorUtility.DisplayDialog("Success", $"{fileCount} assets imported successfully!", "OK");
        }
        catch (System.Exception e)
        {
            EditorUtility.ClearProgressBar();
            EditorUtility.DisplayDialog("Error", $"Import failed: {e.Message}", "OK");
        }
    }
}
using UnityEditor;
using UnityEngine;

public static class ProjectSetup
{
    [MenuItem("Solace Tools/Setup Project Structure")]
    private static void SetupProjectStructure()
    {
        CreateFolders();
        CreateHierarchy();
    }

    private static void CreateFolders()
    {
        string[] folders = new string[]
        {
            "Assets/Materials",
            "Assets/Prefabs",
            "Assets/Packages",
            "Assets/Scenes",
            "Assets/Scripts",
            "Assets/Scripts/Data",
            "Assets/Scripts/Controllers",
            "Assets/Scripts/Input",
            "Assets/ScriptsManagers",
        };
        foreach (string folder in folders) 
        {
            if (!AssetDatabase.IsValidFolder(folder))
            {
                AssetDatabase.CreateFolder(GetParentFolder(folder), GetFolderName(folder));
            }
        }
        AssetDatabase.Refresh();
    }
    private static string GetParentFolder(string folder)
    {
        return folder.Substring(0, folder.LastIndexOf('/'));
    }
    private static string GetFolderName(string folder) 
    {
        return folder.Substring(folder.LastIndexOf('/')+ 1);
    }

    private static void CreateHierarchy()
    {
        string[] hierarchy = new string[]
        {
            "--- Controllers ---",
            "--- Camera --------",
            "--- Environment ----",
            "--- Lights --------",
            "--- UI ------------",
            "--- Audio ---------",
            "--- Misc ----------",
            "--- Managers ------"
        };
        foreach (string name in hierarchy) 
        {
            if (GameObject.Find(name)==null)
            {
                new GameObject(name);
            }
        }
    }
}

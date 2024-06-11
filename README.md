# Project Setup Unity Package

## Description
The Project Setup Unity Package is designed to automate the creation of a consistent folder structure and organized hierarchy in new Unity projects. This package saves you time and ensures that your projects start off neat and tidy.

## Features
### Create Default Asset Folders:
- Automatically generates essential folders such as `Materials`, `Prefabs`, `Packages`, `Scenes`, and `Scripts` (with subfolders for `Data`, `Controllers`, `Input`, and `Managers`).

### Organize Scene Hierarchy:
- Sets up a clear and organized hierarchy in the scene with GameObjects for `Controllers`, `Camera`, `Environment`, `Lights`, `UI`, `Audio`, `Misc`, and `Managers`.

## Installation

### Download the Package:
- Download the `ProjectSetup.unitypackage` file from the [Releases](https://github.com/tonydpatterson/solacesetup/releases/) page.

### Import the Package into Your Project:
1. Open your Unity project.
2. Go to `Assets -> Import Package -> Custom Package...`.
3. Select the `ProjectSetup.unitypackage` file you downloaded.
4. Click `Import` to add the package to your project.

## Usage

### Open the Project Setup Tool:
- In Unity, go to `Solace Tools -> Setup Project Structure`.

## Customization
- The script can be easily customized to add or remove folders and hierarchy elements according to your project's needs. Simply edit the `ProjectSetup.cs` script located in the `Editor` folder.

## Contribution
- Feel free to fork the repository and submit pull requests with improvements or additional features.

##  License
This project is licensed under the MIT License - see the LICENSE file for details.


##  Code
Here is the core of the `ProjectSetup.cs` script:

```csharp
using UnityEditor;
using UnityEngine;

public class ProjectSetup : MonoBehaviour
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
            "Assets/Scripts/ScriptableObjects",
            "Assets/Scripts/Data",
            "Assets/Scripts/Controllers",
            "Assets/Scripts/Input",
            "Assets/Scripts/Managers"
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
        return folder.Substring(folder.LastIndexOf('/') + 1);
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
            if (GameObject.Find(name) == null)
            {
                new GameObject(name);
            }
        }
    }
}


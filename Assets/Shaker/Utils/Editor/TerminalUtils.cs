using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class TerminalUtils
{

    [MenuItem("Shaker/Open Terminal")]
    static void OpenTerminal()
    {
       
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            System.Diagnostics.Process.Start("CMD.exe", "cd " + GetProjectPath());
        }
        else if(Application.platform == RuntimePlatform.OSXEditor)
        {
            System.Diagnostics.Process.Start(@"/Applications/Utilities/Terminal.app/Contents/MacOS/Terminal", "cd " + GetProjectPath());
        }else{
            Debug.LogWarning("Terminal shortcut is not supported on your plateform");
        }
    }

    public static string GetProjectPath(){
        string path = Application.dataPath;
        path = path.Replace("/Assets", "");
        return path;
    }

#if UNITY_EDITOR_OSX
    [MenuItem("Shaker/Reveal in Finder")]
#else
    [MenuItem("Shaker/Show in Explorer")]
#endif
    static void OpenInFileExplorer()
    {
        EditorUtility.RevealInFinder(GetProjectPath());
    }
}

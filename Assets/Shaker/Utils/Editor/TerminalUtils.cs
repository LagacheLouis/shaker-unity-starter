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
            System.Diagnostics.Process.Start("CMD.exe");
        }
        else
        {
            Debug.Log("Terminal shortcut is not supported on your plateform");
        }
    }

#if UNITY_EDITOR_OSX
    [MenuItem("Shaker/Reveal in Finder")]
#else
    [MenuItem("Shaker/Show in Explorer")]
#endif
    static void OpenInFileExplorer()
    {
        EditorUtility.RevealInFinder(Application.dataPath);
    }
}

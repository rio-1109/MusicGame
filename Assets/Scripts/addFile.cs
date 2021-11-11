using System.Collections;
using UnityEngine;
using System.IO;
using SimpleFileBrowser;


public class addFile : MonoBehaviour {
    Connect connect;
    void Start() {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("mp3", ".mp3"));
        FileBrowser.SetDefaultFilter(".mp3");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine() {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files", "Load Files");
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success) {
            for(int i=0; i<FileBrowser.Result.Length; i++) {
                Debug.Log(FileBrowser.Result[i]);
                // connect.startConnect(FileBrowser.Result[i]);
                connect = GameObject.Find("Connect").GetComponent<Connect>();
                connect.startConnect(FileBrowser.Result[i]);
            }
            
        }
    }
}

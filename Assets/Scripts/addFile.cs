using System.Collections;
using UnityEngine;
using System.IO;
using SimpleFileBrowser;
using UnityEngine.SceneManagement;

public class addFile : MonoBehaviour
{
    void Start() {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("mp3", ".mp3"));
        FileBrowser.SetDefaultFilter(".mp3");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        Debug.Log("ok");
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine() {
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.FilesAndFolders, true, null, null, "Load Files", "Load Files");
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success) {
            for(int i=0; i<FileBrowser.Result.Length; i++) {
                Debug.Log( FileBrowser.Result[i]);
            }
            
        }
        SceneManager.LoadScene("Scene2");
    }
}

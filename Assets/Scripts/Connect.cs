using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using static System.IO.Path;

public class Connect : MonoBehaviour {
    // Start is called before the first frame update
    string URL = "https://music-game-331007.an.r.appspot.com";
    // string URL = "http://127.0.0.1:5000/";
    public string chartsPath = "Assets/Charts/test1.json";
    // public string chartsPath = "Assets/Charts/";
    public string path;
    public string title;
    
     public void  startConnect(string fileBrowserResult) {
        path = fileBrowserResult;
        Debug.Log(path);
        title = Path.GetFileNameWithoutExtension(path);
        Debug.Log(title);
        StartCoroutine("OnSend", URL);
        
    }

     IEnumerator OnSend(string url) {
         WWWForm form = new WWWForm();
         form.AddField("title",title);
         byte[] bytes = File.ReadAllBytes(path);
         form.AddBinaryData("musicFile", bytes, Path.GetFileName(path),"multipart/form-data");
         UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
         yield return webRequest.SendWebRequest();
         if (webRequest.result == UnityWebRequest.Result.ConnectionError) {
             Debug.Log(webRequest.error);
            } else {
                 Debug.Log("Get"+" : "+ webRequest.downloadHandler.text);
                 File.WriteAllText(chartsPath, webRequest.downloadHandler.text);
            }
        SceneManager.LoadScene("Scene2");
    }
}

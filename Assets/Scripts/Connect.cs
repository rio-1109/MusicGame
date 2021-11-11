using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Connect : MonoBehaviour {
    // Start is called before the first frame update
    string URL = "https://music-game-331007.an.r.appspot.com";
    public string chartsPath = "Assets/Charts/test1.json";
    
     public void  startConnect(string fileBrowserResult) {
        string path = fileBrowserResult;
        Debug.Log(path);
        StartCoroutine("OnSend", URL);
        
    }

     IEnumerator OnSend(string url) {
         Debug.Log("!!!!");
        UnityWebRequest webRequest = UnityWebRequest.Get(url);
        Debug.Log("??????");
        yield return webRequest.SendWebRequest();
        Debug.Log("~~~~~~~");

        if (webRequest.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(webRequest.error);
        } else {
            Debug.Log("Get"+" : "+ webRequest.downloadHandler.text);
            File.WriteAllText(chartsPath, webRequest.downloadHandler.text);

        }
        SceneManager.LoadScene("Scene2");
    }
}

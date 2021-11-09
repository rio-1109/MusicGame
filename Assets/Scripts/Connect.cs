using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class Connect : MonoBehaviour
{
    // Start is called before the first frame update
    private const string URL = "https://music-game-331007.an.r.appspot.com";

    void Start()

    {
        Debug.Log("!");
        StartCoroutine("OnSend", URL);
    }

    IEnumerator OnSend(string url) {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError) {
            Debug.Log(webRequest.error);
        } else {
            Debug.Log("Get"+" : "+ webRequest.downloadHandler.text);
        }
    }
}

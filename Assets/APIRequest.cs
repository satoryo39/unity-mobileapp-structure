using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

namespace APIRequest {
  public class GetAPI : MonoBehaviour
  {
    // void Start()
    // {
    //     StartCoroutine(
    //         getRequest(
    //             (JSONNode JSONresponse) =>
    //             {
    //                 HandleAPIresponse(JSONresponse);
    //             }
    //         )
    //     );
    // }
      public static IEnumerator GetRequest(string RequestURL, System.Action<JSONNode> callBack)
      {
          //APIのURI、HTTPメソッド、ヘッダーの設定
          Debug.Log("URL = " + RequestURL);
          UnityWebRequest request = UnityWebRequest.Get(RequestURL);
          request.SetRequestHeader("Content-Type", "application/json");

          //APIのリクエストを送信
          yield return request.SendWebRequest();

          //レスポンスをJSONNode型に格納
          string JSONstring = request.downloadHandler.text;
          JSONNode JSONnode = JSON.Parse(JSONstring);

          //JSONNode型のレスポンスをcallBackに渡す
          callBack(JSONnode);
      }
    }
}

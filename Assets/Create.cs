using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using APIRequest;

public class Create : MonoBehaviour
{
    public RectTransform contentRectTransform;

    GameObject panel;

    void Awake() {
      panel = GameObject.Find("Panel");
    }

    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(
            GetAPI.GetRequest(
                "http://jsonplaceholder.typicode.com/posts",
                (JSONNode JSONresponse) =>
                {
                    HandleAPIresponse(JSONresponse);
                }
            )
        );
    }

    private void HandleAPIresponse(JSONNode data)
    {
        Debug.Log("Data from res is:" + data[0]["title"].Value);

        for(int i = 0; i < data.Count; i++){
            var parent = Instantiate(panel, contentRectTransform);
            var title = parent.transform.Find("Text").GetComponent<Text>();
            var button = parent.transform.Find("Button").GetComponent<Button>();
            title.text = data[i]["title"].Value;
            button.GetComponentInChildren<Text>().text = data[i]["body"].Value;
            button.onClick.AddListener(() => Debug.Log(title.text.ToString()));
        }
    }
}

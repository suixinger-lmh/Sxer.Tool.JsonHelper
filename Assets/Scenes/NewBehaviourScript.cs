using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Sxer.Tool;

public class NewBehaviourScript : MonoBehaviour
{
    public TextAsset jsonFile;
    // Start is called before the first frame update
    void Start()
    {
        LitJson.JsonData jd = JsonHelper.JsonStr2JsonData(jsonFile.text);

        Debug.Log(jd[0]["FirstImagePath"]);
        Debug.Log(
            jd.IsArray);
        Debug.Log(JsonHelper.JsonData2JsonStr(jd));
        Debug.Log(jd.ToJson());

        string temp = JsonHelper.GetEasyJsonStr(new string[] { "title", "name", "age" }, new object[] { "标题1", null, 18 });
        jd = JsonHelper.JsonStr2JsonData(temp);
        Debug.Log(jd["age"]);
        Debug.Log(jd["title"]);
        Debug.Log(jd["name"]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class PushFinish : MonoBehaviour
{

    public InputField titleInputField;
    public InputField contextInputField;
    public InputField userInputField;
    public Text titleText;
    public Text contextText;
    public Text userText;
    public Text ClockText;

    void Start () {

        //Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://iky-urutest01.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        //ClockText = GetComponentInChildren<Text>();
        //Componentを扱えるようにする
        titleInputField = titleInputField.GetComponent<InputField> ();
        titleText = titleText.GetComponent<Text> ();

        contextInputField = contextInputField.GetComponent<InputField> ();
        contextText = contextText.GetComponent<Text> ();
        
        userInputField = userInputField.GetComponent<InputField> ();
        userText = userText.GetComponent<Text> ();

        //ClockText.text = DateTime.Now.ToShortTimeString();

        Debug.Log(DateTime.Now.ToShortTimeString());
    }

    void Update () {
        // ClockText.text = DateTime.Now.ToShortTimeString();
    }

     public void InputText(){
         //テキストにinputFieldの内容を反映
         titleText.text = titleInputField.text;
         contextText.text = contextInputField.text;
 
     }

     public void OnClick() {
        Debug.Log ("clicked");
        FirebaseDatabase.DefaultInstance.GetReference("content1")
            .Child("title")
            .SetValueAsync("テスト1");
        FirebaseDatabase.DefaultInstance.GetReference("content1")
            .Child("date")
            .SetValueAsync("20191031");
        FirebaseDatabase.DefaultInstance.GetReference("content1")
            .Child("message")
            .SetValueAsync("文章を更新");
        FirebaseDatabase.DefaultInstance.GetReference("content1")
            .Child("user")
            .SetValueAsync("mio");
    }

/* 
    GameObject setting;
    public SettingText settingText;
    string title;
    public void OnClick() {
        Debug.Log (title);
    }
    void Start()
    {
        title = "次回の活動について";
        // setting = GameObject.Find ("setting"); 
        // settingText = setting.GetComponent<SettingText>();
    }
    void Update()
    {
        //title = settingText.textToEdit;
        //Debug.Log (title);
    }
*/
}


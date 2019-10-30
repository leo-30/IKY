using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class DatabaseAccess : MonoBehaviour
{
    void Start()
    {
        //Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://iky-urutest01.firebaseio.com/");
    }
    void Update()
    {
        
    }
}


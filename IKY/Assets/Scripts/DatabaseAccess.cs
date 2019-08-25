using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class DatabaseAccess : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://iky-urutest01.firebaseio.com/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

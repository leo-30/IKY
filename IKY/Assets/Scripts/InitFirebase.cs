using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;

public class InitFirebase : MonoBehaviour
{
    //Firebase.Auth.FirebaseAuth auth;
    //Firebase.Auth.FirebaseUser user;
    // Start is called before the first frame update
    void Start()
    {
        //auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        //user = auth.CurrentUser;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitializeFirebase() {
        /*auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);*/
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        /*if (auth.CurrentUser != user) {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null) {
            DebugLog("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn) {
            DebugLog("Signed in " + user.UserId);
            displayName = user.DisplayName ?? "";
            emailAddress = user.Email ?? "";
            photoUrl = user.PhotoUrl ?? "";
            }
        }*/
    }
}


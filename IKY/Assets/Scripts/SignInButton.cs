using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;

public class SignInButton : MonoBehaviour
{
    public InputField addressField;
    public InputField passwordField;
    private string email;
    private string password;
    Firebase.Auth.FirebaseAuth auth;
    private ThreadDispatcher dispatcher;

    // Start is called before the first frame update
    private void Awake()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        addressField = addressField.GetComponent<InputField>();
        passwordField = passwordField.GetComponent<InputField>();
        
        dispatcher = new ThreadDispatcher();
    }

    // Update is called once per frame
    void Update()
    {
        dispatcher.Polljobs();
    }

    public void SignIn(){

        email = addressField.text;
        password = passwordField.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            RunOnMainThread(() =>
            {
                //message.text = "Signed in";
                SceneManager.LoadScene("SignedInScene");
                return 0;
            });
            Debug.Log("Scene loaded");
        });
        /*if (user != null) {
            string name = user.DisplayName;
            string email = user.Email;
            System.Uri photo_url = user.PhotoUrl;
            // The user's Id, unique to the Firebase project.
            // Do NOT use this value to authenticate with your backend server, if you
            // have one; use User.TokenAsync() instead.
            string uid = user.UserId;
        }*/
    }

    public TResult RunOnMainThread<TResult>(System.Func<TResult> f)
    {
        return dispatcher.Run(f);
    }

    
}

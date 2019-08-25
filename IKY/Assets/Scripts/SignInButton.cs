using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;

public class SignInButton : MonoBehaviour
{
    public InputField addressField;
    public InputField passwordField;
    private string email;
    private string password;
    Firebase.Auth.FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        addressField = addressField.GetComponent<InputField>();
        passwordField = passwordField.GetComponent<InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        });
    }
}

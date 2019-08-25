using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;

public class SignUpButton : MonoBehaviour
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

    public void SignUp(){

        email = addressField.text;
        password = passwordField.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            return;
        }

        // Firebase user has been created.
        Firebase.Auth.FirebaseUser newUser = task.Result;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);

        SceneManager.LoadScene("SignedInScene");
        });
    }

}

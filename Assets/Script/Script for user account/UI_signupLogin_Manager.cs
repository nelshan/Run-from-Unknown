using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_signupLogin_Manager : MonoBehaviour
{

    [SerializeField] Text errorText;
    [SerializeField] Canvas canvas;

    string  password, emailAddress;

    void OnEnable() 
    {
        playerAccountManager.OnCreateAccount_Failed.AddListener(OnCreateAccount_Failed);
        playerAccountManager.OnLogin_Success.AddListener(OnLogin_Success);
    }

    void OnDisable() 
    {
        playerAccountManager.OnCreateAccount_Failed.RemoveListener(OnCreateAccount_Failed);
        playerAccountManager.OnLogin_Success.RemoveListener(OnLogin_Success);
    }

    void OnCreateAccount_Failed(string error)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = error;
    }
    void OnLogin_Success()
    {
        canvas.enabled = false;
    }

    public void UpdateEmail ( string _emailAddress)
    {
        emailAddress = _emailAddress;
    }
    public void UpdatePassward (string _password)
    {
        password = _password;
    }
    public void CreateAccount()
    {
        playerAccountManager.Instance.CreateAccount( emailAddress, password);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_login_Manager : MonoBehaviour
{
    [SerializeField] Text errorText;
    [SerializeField] Canvas canvas;

    string password, emailAddress;

    void OnEnable()
    {
        playerAccountManager.OnLogin_Failed.AddListener(OnLogin_Failed);
        playerAccountManager.OnLogin_Success.AddListener(OnLogin_Success);
    }

    void OnDisable()
    {
        playerAccountManager.OnLogin_Failed.RemoveListener(OnLogin_Failed);
        playerAccountManager.OnLogin_Success.AddListener(OnLogin_Success);
    }

    void OnLogin_Failed(string error)
    {
        errorText.gameObject.SetActive(true);
        errorText.text = error;
    }
    void OnLogin_Success()
    {
        canvas.enabled = false;
    }

    
    public void UpdateEmail(string _emailAddress)
    {
        emailAddress = _emailAddress;
    }
    public void UpdatePassward(string _password)
    {
        password = _password;
    }
    public void Login()
    {
        playerAccountManager.Instance.Login(emailAddress,password);
    }
}

using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class playerAccountManager : MonoBehaviour
{   
    public static playerAccountManager Instance;

    public static UnityEvent OnLogin_Success = new UnityEvent();

    public static UnityEvent<string> OnLogin_Failed = new UnityEvent<string>();

    public static UnityEvent<string> OnCreateAccount_Failed = new UnityEvent<string>();

    void Awake() {
        Instance = this;
    }
    
    public void CreateAccount( string emailAddress, string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(
            new RegisterPlayFabUserRequest()
            {
                Email = emailAddress,
                Password = password,
                RequireBothUsernameAndEmail = false
            },
            request => {
                Debug.Log($"Successful Account Creation:  {emailAddress}");
                Login (emailAddress, password);
                SceneManager.LoadScene("Main Menu");
            },
            error =>{
                Debug.Log($"Unsuccessful Account Creation:  {emailAddress} \n {error.ErrorMessage}");
                OnCreateAccount_Failed.Invoke(error.ErrorMessage);
            }
        );
    }

    public void Login(string emailAddress, string password)
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest(){
                Email = emailAddress,
                Password = password
            },
            request => {
                Debug.Log($"Successful Account Login:  {emailAddress}");
                OnLogin_Success.Invoke();
                SceneManager.LoadScene("Main Menu");
            },
            error =>{
                Debug.Log($"Unsuccessful Account Login:  {emailAddress} \n \n {error.ErrorMessage}");
                OnLogin_Failed.Invoke(error.ErrorMessage);
            }
        );
    }
}
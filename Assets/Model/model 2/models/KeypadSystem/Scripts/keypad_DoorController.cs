using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypad_DoorController : MonoBehaviour
{
    public Text textOB;
    public string dialogue = "I need the keycode to open the door";
    public float timer = 2f;
    public bool lockedByPassword;

    private Animator anim;
    private Text textComponent;
    private AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        textComponent = textOB.GetComponent<Text>();
        textComponent.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void OpenClose()
    {
        if (lockedByPassword && !string.IsNullOrEmpty(dialogue))
        {
            textComponent.enabled = true;
            textComponent.text = dialogue;
            StartCoroutine(DisableText());
            return;
        }

        anim.SetTrigger("Door");
        audioSource.Play();
    }

    private IEnumerator DisableText()
    {
        yield return new WaitForSecondsRealtime(timer);
        textComponent.enabled = false;
    }
}

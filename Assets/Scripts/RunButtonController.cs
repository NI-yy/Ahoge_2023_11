using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunButtonController : MonoBehaviour
{
    int clickCount = 0;
    int clickth = 20;
    public static int inputNum = 0;
    public static float SumTime = 0f;

    public GameObject Image_hallway;
    public GameObject Image_effect;
    public GameObject Image_door;
    public GameObject caret_1;
    public GameObject caret_2;
    public GameObject caret_3;
    public GameObject inputField;
    public GameObject TextController;
    public AudioClip sound1;
    public AudioClip sound2;
    public GameObject SceneCanvas;
    AudioSource audioSource;

    private void Start()
    {
       audioSource = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        clickCount++;
        if(clickCount == 1)
        {
            caret_1.SetActive(false);
            caret_2.SetActive(false);
            caret_3.SetActive(false);
            Image_hallway.SetActive(true);
            Image_effect.SetActive(true);
        }
        audioSource.PlayOneShot(sound1);
        Image_hallway.transform.localScale += new Vector3(0.1f, 0.1f, 0f);
        if(clickCount == (clickth - 1))
        {
            Image_door.SetActive(true);
        }
        else if(clickCount > (clickth - 1))
        {
            string inputText = inputField.GetComponent<InputFieldController>().getText();
            inputNum = int.Parse(inputText);
            float time = TextController.GetComponent<TextController>().GetTime();
            SumTime = Mathf.Floor(time * 1000) / 1000f;
            audioSource.PlayOneShot(sound2);
            //SceneManager.LoadScene("ResultScene");
            SceneCanvas.GetComponent<FadeSceneLoader>().CallCoroutine();
        }
    }
}

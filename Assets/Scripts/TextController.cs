using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text Text; // インスペクターからアサインする
    public int startCount = 3; // 開始する秒数
    public static int targetValue;
    public GameObject Fukidashi_player;
    public GameObject inputfield;
    public GameObject text_desune;
    public GameObject runButton;
    public GameObject caret_1;
    public GameObject caret_2;
    public GameObject caret_3;
    public GameObject DotSound;
    public GameObject TargetNumSound;
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;

    bool isStarted = false;
    float time = 0f;

    private void Start()
    {
        targetValue = Random.Range(100, 1000);
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartCountdown());
    }

    private void Update()
    {
        if (isStarted)
        {
            time += Time.deltaTime;
        }
    }

    IEnumerator StartCountdown()
    {
        int count = startCount;

        while (count > 0)
        {
            yield return new WaitForSeconds(1);
            audioSource.PlayOneShot(sound1);
            Text.text += "・";
            
            count--;
        }

        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound2);
        Text.text = targetValue.ToString() + "です";
        ActivatePlayerObject();
    }

    void ActivatePlayerObject()
    {
        Fukidashi_player.SetActive(true);
        inputfield.SetActive(true);
        text_desune.SetActive(true);
        runButton.SetActive(true);
        caret_1.SetActive(true);
        caret_2.SetActive(true);
        caret_3.SetActive(true);

        isStarted = true;
    }

    public float GetTime()
    {
        return time;
    }
}

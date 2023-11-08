using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class ScoreManager : MonoBehaviour
{
    public Text text_time_cal;
    public Text text_error_cal;
    public Text text_score_value;
    public AudioClip sound1;
    public AudioClip sound2;
    public GameObject RetryButton;
    AudioSource audioSource;
    float score;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        score = 100 / (RunButtonController.SumTime + Mathf.Abs(TextController.targetValue - RunButtonController.inputNum));
        UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound1);
        text_time_cal.text = $"{RunButtonController.SumTime.ToString("F2")}";
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound1);
        text_error_cal.text = $"|{TextController.targetValue.ToString()}-{RunButtonController.inputNum.ToString()}|";
        yield return new WaitForSeconds(1);
        audioSource.PlayOneShot(sound2);
        text_score_value.text = score.ToString("F10");

        RetryButton.SetActive(true);
    }
}

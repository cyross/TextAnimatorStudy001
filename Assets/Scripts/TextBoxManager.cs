using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public TextAnimatorPlayer _player;
    public Button nextButton;
    public AudioSource aSource;
    public AudioClip clipClick;
    public AudioClip clipImpact;
    public string[] textLines;
    
    int line_cnt;

    private void Awake()
    {
        _player.textAnimator.onEvent += OnEvent;
    }

    // Start is called before the first frame update
    void Start()
    {
        nextButton.gameObject.SetActive(false);
        line_cnt = 0;
        ShowText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TextAnimatonPlayerから渡ってきたイベントハンドラ
    private void OnEvent(string message)
    {
        switch (message)
        {
            case "pause":
                nextButton.gameObject.SetActive(true);
                break;
            case "click":
                aSource.PlayOneShot(clipClick);
                break;
            case "impact":
                aSource.PlayOneShot(clipImpact);
                break;
        }
    }

    // ボタンを押したときの挙動
    public void OnClickNextButton()
    {
        if(nextButton != null && nextButton.gameObject.activeSelf)
        {
            line_cnt++;
            ShowText();
            nextButton.gameObject.SetActive(false);
        }
    }

    // textAnimatorPlayerを介してテキストを表示
    private void ShowText()
    {
        if(line_cnt > textLines.Length)
        {
            // 表示できないので空文字列を表示
            _player.ShowText(string.Empty);
            return;
        }
        _player.ShowText(textLines[line_cnt]);
    }
}

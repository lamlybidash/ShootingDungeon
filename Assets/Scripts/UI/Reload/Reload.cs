using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    private Image _bgReload;
    private TextMeshProUGUI _textReload;
    private float _time;
    void Start()
    {
        _bgReload = transform.Find("bg").GetComponent<Image>();
        _textReload = transform.Find("ReloadText").GetComponent<TextMeshProUGUI>();
    }

    public void ReloadUI(float time)
    {
        _time = time;
        StartCoroutine(reloadBg());
        StartCoroutine(reloadText());
    }
    

    // Background unfill từ trên xuống
    private IEnumerator reloadBg()
    {
        float timeCount;
        timeCount = 0;
        while (timeCount < _time)
        {
            timeCount += Time.deltaTime;
            _bgReload.fillAmount = ((_time - timeCount) / _time);
            yield return null;
        }
    }

    // Text Reload nhấp nháy
    private IEnumerator reloadText()
    {
        //TODO : nhấp nháy
        float timeCount;
        timeCount = 0;
        while (timeCount < _time)
        {
            timeCount += Time.deltaTime;
            yield return null;
        }
    }
}

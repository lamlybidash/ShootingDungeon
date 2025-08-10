using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    private Image _bgReload;
    private Image _bgPerShoot;
    private TextMeshProUGUI _textReload;
    private float _time;
    private Coroutine _coroutinePerShoot;
    public event Action ReloadComplete;
    void Start()
    {
        _bgReload = transform.Find("bg").GetComponent<Image>();
        _textReload = transform.Find("ReloadText").GetComponent<TextMeshProUGUI>();
        _bgPerShoot = transform.parent.Find("bgPerShoot").GetComponent<Image>();
        _bgReload.gameObject.SetActive(false);
        _bgPerShoot.gameObject.SetActive(false);
        _textReload.gameObject.SetActive(false);
    }

    public void ReloadUI(float time)
    {
        _time = time;
        _bgReload.gameObject.SetActive(true);
        _textReload.gameObject.SetActive(true);
        StartCoroutine(reloadBg());
        StartCoroutine(reloadText());
    }
    
    public void UIShoot(float TimePerShoot)
    {
        _bgPerShoot.gameObject.SetActive(true);
        if(_coroutinePerShoot == null)
        {
            _coroutinePerShoot = StartCoroutine(WaitBullet(TimePerShoot));
        }
        else
        {
            StopCoroutine(_coroutinePerShoot);
            _bgPerShoot.gameObject.SetActive(false);
            _bgPerShoot.fillAmount = 1f;
            _coroutinePerShoot = StartCoroutine(WaitBullet(TimePerShoot));
        }
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
        _bgReload.gameObject.SetActive(false);
    }

    // Text Reload nhấp nháy
    private IEnumerator reloadText()
    {
        float timeCount;
        float alpha;
        timeCount = 0;
        while (timeCount < _time)
        {
            timeCount += Time.deltaTime;
            alpha = Mathf.Lerp(0.2f, 1f, Mathf.PingPong(timeCount * 4f, 1f));

            Color c = _textReload.color;
            _textReload.color = new Color(c.r, c.g, c.b, alpha);
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        _textReload.gameObject.SetActive(false);
        ReloadComplete?.Invoke();
    }

    // Nền chờ giữa 2 viên đạn từ phải sang trái
    private IEnumerator WaitBullet(float TimePerShoot)
    {
        float timeCount, tps;
        timeCount = 0;
        tps = TimePerShoot - 0.01f;
        while (timeCount < tps)
        {
            timeCount += Time.deltaTime;
            _bgPerShoot.fillAmount = ((tps - timeCount) / tps);
            yield return null;
        }
        _bgPerShoot.gameObject.SetActive(false);
        _coroutinePerShoot = null;
    }
}

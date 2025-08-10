using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInfor : MonoBehaviour
{
    private TextMeshProUGUI _textBullet;
    private TextMeshProUGUI _nameGun;
    private Image _iconGun;

    private void Awake()
    {
        _textBullet = transform.Find("Bullet").GetComponent<TextMeshProUGUI>();
        _nameGun = transform.Find("NameGun").GetComponent<TextMeshProUGUI>();
        _iconGun = transform.Find("IconGun").GetComponent<Image>();
    }

    public void UpdateTextBullet(int current, int total)
    {
        _textBullet.text = $"{current}/{total}";
    }

}

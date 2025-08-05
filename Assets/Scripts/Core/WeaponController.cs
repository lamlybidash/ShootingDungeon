using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon _weaponCurrent;
    [SerializeField] private List<GameObject> _slots;
    [SerializeField] private Image _imgGun1;    // Icon súng
    [SerializeField] private Image _imgGun2;

    [SerializeField] private TextMeshProUGUI _nameGun1; // Tên súng
    [SerializeField] private TextMeshProUGUI _nameGun2;

    [SerializeField] private TextMeshProUGUI _bulletText1;  // text số đạn súng 1
    [SerializeField] private TextMeshProUGUI _bulletText2;

    [SerializeField] private Reload _reload1; // Gameobject Reload súng 1
    [SerializeField] private Reload _reload2;


    [SerializeField] private Joystick _shootJoystick;
    private List<GameObject> bullets = new List<GameObject>();
    private int i;
    private int selected;   //ô select súng 01 súng 2 dao
    private float _speedGun = 0.3f;
    private bool _canAttack;
    void Start()
    {
        i = 0;
        _speedGun = 0.2f;
        _canAttack = true;
        selected = 2;
        _weaponCurrent.eReload += ReloadUI;
    }

    void Update()
    {
        if (_shootJoystick.Direction.magnitude > 0.1f)
        {
            _weaponCurrent.Shoot(_shootJoystick.Direction);
        }
    }

    private void ReloadUI(float time)
    {
        _reload1.ReloadUI(time);
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Weapon _weaponCurrent;
    [SerializeField] private Weapon _weapon1;
    [SerializeField] private Weapon _weapon2;
    [SerializeField] private Weapon _weapon3;
    [SerializeField] private List<GameObject> _slots;
    [SerializeField] private Image _imgGun1;    // Icon súng
    [SerializeField] private Image _imgGun2;
    [SerializeField] private Image _imgGun;

    [SerializeField] private TextMeshProUGUI _nameGun1; // Tên súng
    [SerializeField] private TextMeshProUGUI _nameGun2;
    [SerializeField] private TextMeshProUGUI _nameGun;

    [SerializeField] private TextMeshProUGUI _bulletText1;  // text số đạn súng 1
    [SerializeField] private TextMeshProUGUI _bulletText2;
    [SerializeField] private TextMeshProUGUI _bulletText;

    [SerializeField] private Reload _reload1; // Gameobject Reload súng 1
    [SerializeField] private Reload _reload2;
    [SerializeField] private Reload _reload;

    [SerializeField] private UIInfor _infor1; // Gameobject Infor súng 1
    [SerializeField] private UIInfor _infor2;
    [SerializeField] private UIInfor _infor;

    [SerializeField] private GameObject Selected1;  //Gameobject khung select
    [SerializeField] private GameObject Selected2;

    [SerializeField] private Button _btGun1;
    [SerializeField] private Button _btGun2;
    [SerializeField] private Button _btKnife;


    [SerializeField] private Joystick _shootJoystick;
    private List<GameObject> bullets = new List<GameObject>();
    private int i;
    private int selected;   //ô select súng 12 súng 3 dao
    private float _speedGun = 0.3f;
    private bool _canAttack;
    void Start()
    {
        i = 0;
        _speedGun = 0.2f;
        _canAttack = true;
        selected = 1;
        _weaponCurrent.eReload += ReloadUI;
        _weaponCurrent.eShoot += UIShoot;
        _reload1.ReloadComplete += ReloadComplete;
        _reload2.ReloadComplete += ReloadComplete;
        UpdateWeaponEquip();
    }

    void Update()
    {
        if (_shootJoystick.Direction.magnitude > 0.1f)
        {
            _weaponCurrent.Shoot(_shootJoystick.Direction);
        }
    }

    private void ReloadComplete()
    {
        int x;
        x = _weaponCurrent.GetMagazineCapacity();
        UpdateTextBullet(x, x);
    }

    private void ReloadUI(float time)
    {
        _reload.ReloadUI(time);
    }
    private void UIShoot(float time, int current, int total)
    {
        _reload.UIShoot(time);
        UpdateTextBullet(current, total);
    }

    private void UpdateTextBullet(int current, int total)
    {
        _infor.UpdateTextBullet(current, total);
    }

    private void UpdateWeaponEquip()
    {
        _btGun1.onClick.AddListener(() => OnGunClick(_weapon1, _reload1, _bulletText1, _nameGun1, _imgGun1, Selected1, _infor1, 1));
        _btGun2.onClick.AddListener(() => OnGunClick(_weapon2, _reload2, _bulletText2, _nameGun2, _imgGun2, Selected2, _infor2, 2));
    }

    public void OnGunClick(Weapon x, Reload reload, TextMeshProUGUI bulletText, TextMeshProUGUI nameGun, Image imgGun, GameObject KhungSelected, UIInfor uiInfor, int i)
    {
        selected = i;
        _weaponCurrent = x;
        _reload = reload;
        _bulletText = bulletText;
        _nameGun = nameGun;
        _imgGun = imgGun;
        _infor = uiInfor;

        Selected1.SetActive(false);
        Selected2.SetActive(false);
        KhungSelected.SetActive(true);
    }
}
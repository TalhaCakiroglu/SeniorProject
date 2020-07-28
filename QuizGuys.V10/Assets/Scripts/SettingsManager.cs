using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour
{
    public Toggle _tamEkran;
    public Dropdown _cozunurluk;
    public Dropdown _kaplamaDetay;
    public Dropdown _antiAlaising;

    public Slider _menuSes;
    public Button uygulaButton;

    public Resolution[] cozunurluk;
    public GameSettings gameSettings;

    public AudioSource menuSesSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onEnable()
    {
        gameSettings = new GameSettings();
        _tamEkran.onValueChanged.AddListener(delegate { onTamEkranToggle(); });
        _cozunurluk.onValueChanged.AddListener(delegate { onCozunurlukDeistir(); });
        _kaplamaDetay.onValueChanged.AddListener(delegate { onKaplamaDetayDeistir(); });
        _antiAlaising.onValueChanged.AddListener(delegate { onAntiAlaisingDeistir(); });
        _menuSes.onValueChanged.AddListener(delegate { onMenuSesDegistir(); });

        cozunurluk = Screen.resolutions;

        foreach (Resolution res in cozunurluk)
        {
            _cozunurluk.options.Add(new Dropdown.OptionData(res.ToString()));
        }
        LoadSettings();
    }
    public void onApplyButton()
    {
        SaveSettings();
    }
    public void onTamEkranToggle()
    {
        gameSettings.tamEkran = Screen.fullScreen = _tamEkran.isOn;
    }
    public void onCozunurlukDeistir()
    {

        Screen.SetResolution(cozunurluk[_cozunurluk.value].width, cozunurluk[_cozunurluk.value].height, Screen.fullScreen);
    }
    public void onKaplamaDetayDeistir()
    {
        QualitySettings.masterTextureLimit = gameSettings.kaplamaDetayi = _kaplamaDetay.value;
    }
    public void onAntiAlaisingDeistir()
    {
        QualitySettings.antiAliasing = gameSettings.antiAlaising = _antiAlaising.value;
    }
    public void onMenuSesDegistir()
    {
        menuSesSource.volume = gameSettings.menuSes = _menuSes.value;
    }
    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings,true);
        File.WriteAllText(Application.persistentDataPath + "/gameSettins.json", jsonData);
    }
    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gameSettins.json"));
        _tamEkran.isOn = gameSettings.tamEkran;
        _cozunurluk.value = gameSettings.cozunurlukIndexx;
        _kaplamaDetay.value = gameSettings.kaplamaDetayi;
        _antiAlaising.value = gameSettings.antiAlaising;
        _menuSes.value = gameSettings.menuSes;

    }
}

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{
    private const float MinValue = 0.0001f;
    private const float MaxValue = 1f;
    private const float LogMultiplier = 20;

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Slider _slider;
    private float _convertValue;
    private string _groupName;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        Init();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeValue);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeValue);
    }

    private void Init()
    {
        _slider.minValue = MinValue;
        _slider.maxValue = MaxValue;
        _groupName = _mixerGroup.name;

        if (PlayerPrefs.HasKey(_groupName))
            _slider.value = SettingsSaver.GetSaveValue(_groupName);

        ChangeValue(_slider.value);
    }

    private void ChangeValue(float value)
    {
        _convertValue = Mathf.Log10(value) * LogMultiplier;
        _mixerGroup.audioMixer.SetFloat(_groupName, _convertValue);

        SettingsSaver.SaveValue(_groupName, _slider.value);
    }
}
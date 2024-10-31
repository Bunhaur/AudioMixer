using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{
    private const float _minValue = 0.0001f;
    private const float _maxValue = 1f;
    private const float _logMultiplier = 20;

    [SerializeField] private AudioMixerGroup _mixerGroup;

    private Slider _slider;
    private string _groupName;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        Init();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float value)
    {
        _mixerGroup.audioMixer.SetFloat(_groupName, Mathf.Log10(value) * _logMultiplier);
    }

    private void Init()
    {
        _slider.minValue = _minValue;
        _slider.maxValue = _maxValue;
        _slider.value = _slider.maxValue;
        _groupName = _mixerGroup.name;
    }
}
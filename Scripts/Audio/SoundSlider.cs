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
        _mixerGroup.audioMixer.SetFloat(_groupName, Mathf.Log10(value) * LogMultiplier);
    }

    private void Init()
    {
        _slider.minValue = MinValue;
        _slider.maxValue = MaxValue;
        _slider.value = _slider.maxValue;
        _groupName = _mixerGroup.name;
    }
}
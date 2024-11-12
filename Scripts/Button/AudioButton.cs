using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(AudioSource))]
public class AudioButton : MonoBehaviour
{
    private Button _button;
    private AudioSource _audioSource;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _audioSource = GetComponent<AudioSource>();

        Init();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void Init()
    {
        _audioSource.playOnAwake = false;
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}
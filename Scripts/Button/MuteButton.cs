using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    private const float MinValue = 0;
    private const float MaxValue = 1;

    [SerializeField] private AudioMixer _mixer;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Mute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Mute);
    }

    private void Mute()
    {
        SettingSaver.ChangeAndSaveMuteValue();

        if (SettingSaver.IsMute())
            AudioListener.volume = MinValue;
        else
            AudioListener.volume = MaxValue;
    }
}
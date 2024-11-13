using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MuteButton : MonoBehaviour
{
    private const string MuteSaveName = "Mute";
    private const float MuteValue = 1;
    private const float UnmuteValue = 0;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();

        Init();
    }

    private void OnEnable()
    {
        _button.onClick?.AddListener(ChangeAndSaveValue);
        _button.onClick?.AddListener(MuteOrUnmute);
    }

    private void OnDisable()
    {
        _button.onClick?.RemoveListener(ChangeAndSaveValue);
        _button.onClick?.RemoveListener(MuteOrUnmute);
    }

    private void Init()
    {
        MuteOrUnmute();
    }

    private void MuteOrUnmute()
    {
        if (SettingsSaver.IsMute(MuteSaveName, MuteValue))
            AudioListener.volume = UnmuteValue;
        else
            AudioListener.volume = MuteValue;
    }

    private void ChangeAndSaveValue()
    {
        if (SettingsSaver.IsMute(MuteSaveName, MuteValue))
            SettingsSaver.SaveValue(MuteSaveName, UnmuteValue);
        else
            SettingsSaver.SaveValue(MuteSaveName, MuteValue);
    }
}
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
        SettingSaver.ChangeAndSaveMuteValue(MuteSaveName, MuteValue, UnmuteValue);

        if (SettingSaver.IsMute(MuteSaveName, MuteValue))
            AudioListener.volume = UnmuteValue;
        else
            AudioListener.volume = MuteValue;
    }
}
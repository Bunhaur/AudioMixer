using UnityEngine;

public static class SettingSaver
{
    private const string SaveMuteName = "Mute";
    private const int ValueMute = 1;
    private const int ValueUnmute = 0;

    public static void SaveValue(string groupName, float value)
    {
        PlayerPrefs.SetFloat(groupName, value);
    }

    public static void SaveValue(string groupName, int value)
    {
        PlayerPrefs.SetInt(groupName, value);
    }

    public static float GetSaveValue(string groupName)
    {
        return PlayerPrefs.GetFloat(groupName);
    }

    public static void ChangeAndSaveMuteValue()
    {
        if (PlayerPrefs.GetInt(SaveMuteName) == ValueMute)
            PlayerPrefs.SetInt(SaveMuteName, ValueUnmute);
        else
            PlayerPrefs.SetInt(SaveMuteName, ValueMute);
    }

    public static bool IsMute()
    {
        return PlayerPrefs.GetInt(SaveMuteName) == ValueMute;
    }
}
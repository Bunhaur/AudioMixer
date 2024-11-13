using UnityEngine;

public static class SettingsSaver
{
    public static void SaveValue(string groupName, float value)
    {
        PlayerPrefs.SetFloat(groupName, value);
    }

    public static float GetSaveValue(string groupName)
    {
        return PlayerPrefs.GetFloat(groupName);
    }

    public static void ChangeAndSaveMuteValue(string saveMuteName, float muteValue, float unmuteValue)
    {
        if (PlayerPrefs.GetFloat(saveMuteName) == muteValue)
            PlayerPrefs.SetFloat(saveMuteName, unmuteValue);
        else
            PlayerPrefs.SetFloat(saveMuteName, muteValue);
    }

    public static bool IsMute(string saveMuteName, float muteValue)
    {
        return PlayerPrefs.GetFloat(saveMuteName) == muteValue;
    }

    public static bool HaveSave(string groupName)
    {
        return PlayerPrefs.HasKey(groupName);
    }
}
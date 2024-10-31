using UnityEngine;
using UnityEngine.Audio;

public class MuteButton : MonoBehaviour
{
    private const string MixerMasterName = "Master";
    private const float MinValue = -80f;
    private const float MaxValue = 0f;

    [SerializeField] private AudioMixerGroup _master;
    [SerializeField] private AudioMixer _mixer;

    private float _volume;

    public void MuteUnmuteAllSounds()
    {
        _mixer.GetFloat(MixerMasterName, out _volume);

        if (_volume > MinValue)
            ChangeValue(MinValue);
        else if (_volume < MaxValue)
            ChangeValue(MaxValue);
    }

    private void ChangeValue(float value)
    {
        _master.audioMixer.SetFloat(MixerMasterName, value);
    }
}
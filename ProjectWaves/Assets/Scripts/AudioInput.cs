using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on https://forum.unity3d.com/threads/check-current-microphone-input-volume.133501/
public class AudioInput : MonoBehaviour {

    public static float MicVolume;

    private string _device;
    private AudioClip _clipRecord = new AudioClip();
    private int _sampleWindow = 12;

    private bool _isInit = false;

    public static bool checkMicrophone()
    {
        return !(Microphone.devices.Length == 0);
    }

    void InitMic()
    {
        if (_device == null) _device = Microphone.devices[0];
        _clipRecord = Microphone.Start(_device, true, 999, 1000);
        _isInit = true;
    }

    void StopMicrophone()
    {
        Microphone.End(_device);
    }

    float LevelMax()
    {
        float levelMax = 0;
        if (!_isInit) return 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null is the first mic
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        // getting the max from the last 128 samples
        float waveSum = 0;
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            /*if (levelMax < wavePeak)
                levelMax = wavePeak;*/
            waveSum += wavePeak;
        }
        return waveSum / (float)_sampleWindow;
    }

    void FixedUpdate()
    {
        MicVolume = LevelMax();
        Debug.Log(MicVolume * 1000);
    }

    private void Start()
    {
        InitMic();
    }

}

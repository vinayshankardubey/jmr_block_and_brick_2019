﻿using UnityEngine;
using JMRSDK;
using TMPro;
using System;

public class JMRDemoDisplayExample : MonoBehaviour
{
    public TMP_Text LogText;
    public TMP_Text EventText;

    private void OnEnable()
    {
        JMRDisplayManager.onError += OnError;
        JMRDisplayManager.onBrightnessChange += OnBrightnessChanged;
        JMRDisplayManager.onContrastChange += OnContrastChanged;
        JMRDisplayManager.onBrightnessModeChange += OnContrastChanged;
        JMRDisplayManager.onConnect += OnConnect;
        JMRDisplayManager.onDisconnect += OnDisconnect;
        JMRDisplayManager.onDisplayModeChange += OnDisplayModeChange;
        JMRDisplayManager.onPowerModeChange += OnPowerModeChange;
        JMRDisplayManager.onPowerStateChange += OnPowerStateChange;

    }

    private void OnDisable()
    {
        JMRDisplayManager.onError -= OnError;
        JMRDisplayManager.onBrightnessChange -= OnBrightnessChanged;
        JMRDisplayManager.onContrastChange -= OnContrastChanged;
        JMRDisplayManager.onBrightnessModeChange += OnBrightnessModeChange;
        JMRDisplayManager.onConnect += OnConnect;
        JMRDisplayManager.onDisconnect += OnDisconnect;
        JMRDisplayManager.onDisplayModeChange += OnDisplayModeChange;
        JMRDisplayManager.onPowerModeChange += OnPowerModeChange;
        JMRDisplayManager.onPowerStateChange += OnPowerStateChange;
    }

    private void OnError(string error)
    {
        ShowEventText(error);
    }

    private void OnBrightnessChanged(int value)
    {
        EventText.text = $"Display Brightness changed : {value}";
    }
    private void OnContrastChanged(int value)
    {
        EventText.text = $"Display Contrast changed : {value}";
    }

    private void OnBrightnessModeChange(int value)
    {
        EventText.text = $"Display Brightness Mode changed : {value}";
    }

    private void OnConnect()
    {
        EventText.text = "Display Connected";
    }

    private void OnDisconnect()
    {
        EventText.text = "Display Disconnected";
    }

    private void OnDisplayModeChange(int value)
    {
        EventText.text = $"Display Mode changed : {value}";
    }
    private void OnPowerModeChange(int value)
    {
        EventText.text = $"Display Power Mode changed : {value}";
    }

    private void OnPowerStateChange(int value)
    {
        EventText.text = $"Display Power State changed : {value}";
    }

    public void ShowEventText(string s)
    {
        EventText.text = $"Display status: {s}";
    }

    private bool iePrevConnected;
    private void LateUpdate()
    {
        if (!Application.isEditor && JMRDisplayManager.Instance != null)
        {
            if (iePrevConnected != JMRDisplayManager.Instance.IsConnected())
            {
                if (JMRDisplayManager.Instance.IsConnected())
                {
                    ShowEventText("Connected");
                }
                else
                {
                    ShowEventText("Disconnected");
                }
            }

            LogText.text = "Display API \n "
                           + "Display \t" + JMRDisplayManager.Instance.GetDisplayMode() + "\n"
                           + "Display Brightness:\t" + (((float)JMRDisplayManager.Instance.GetDisplayBrightness() < 0) ? "Not applicable!" : JMRDisplayManager.Instance.GetDisplayBrightness().ToString()) + "\n"
                           + "Display Power State\t" + (((float)JMRDisplayManager.Instance.GetDisplayPowerState() < 0) ? "Not applicable!" : JMRDisplayManager.Instance.GetDisplayPowerState().ToString()) + "\n"
                           + "Display Power Control Mode \t" + (((float)JMRDisplayManager.Instance.GetDisplayPowerControlMode() < 0) ? "Not applicable!" : JMRDisplayManager.Instance.GetDisplayPowerControlMode().ToString()) + "\n"
                           + "Device Brightness Mode \t" + (((float)JMRDisplayManager.Instance.GetDisplayBrightnessMode() < 0) ? "Not applicable!" : JMRDisplayManager.Instance.GetDisplayBrightnessMode().ToString()) + "\n"
                ;
            iePrevConnected = JMRDisplayManager.Instance.IsConnected();
        }
        else
        {
            LogText.text = "Display Information will displayed here!";
        }
    }
}

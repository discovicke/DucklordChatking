﻿using ChatClient.Core.Application;
using ChatClient.Core.Infrastructure;
using ChatClient.UI.Components.Base;
using ChatClient.UI.Components.Specialized;
using ChatClient.UI.Screens.Common;
using Raylib_cs;

namespace ChatClient.UI.Screens.Options;

/// <summary>
/// Responsible for: calculating layout positions for all UI elements on the options/settings screen.
/// Determines field sizes for account updates and window mode toggle buttons (windowed/fullscreen).
/// </summary>
// TODO Save settings
public class OptionsScreenLogic : ScreenLogicBase
{
    private readonly TextField UserField;
    private readonly TextField PassField;
    private readonly TextField PassConfirmField;
    private readonly Button ConfirmButton;
    private readonly BackButton BackButton;
    private readonly ToggleBox ToggleWindowed;
    private readonly ToggleBox ToggleFullscreen;
    private readonly ToggleBox ToggleMute;

    public OptionsScreenLogic(
        TextField userField,
        TextField passField,
        TextField passConfirmField,
        Button confirmButton,
        BackButton backButton,
        ToggleBox toggleWindowed,
        ToggleBox toggleFullscreen,
        ToggleBox toggleMute)
    {
        UserField = userField;
        PassField = passField;
        PassConfirmField = passConfirmField;
        ConfirmButton = confirmButton;
        BackButton = backButton;
        ToggleWindowed = toggleWindowed;
        ToggleFullscreen = toggleFullscreen;
        ToggleMute = toggleMute;

        // Register fields for automatic tab navigation
        RegisterField(userField);
        RegisterField(passField);
        RegisterField(passConfirmField);
    }

    protected override void UpdateComponents()
    {
        base.UpdateComponents(); // Updates all registered fields with tab navigation
        
        // Use WindowSettings to handle window mode toggles
        WindowSettings.UpdateToggles(ToggleWindowed, ToggleFullscreen);
        
        ToggleMute.Update();
        ConfirmButton.Update();
        BackButton.Update();
        
        HandleMuteToggle();
    }

    protected override void HandleActions()
    {
        if (ConfirmButton.IsClicked())
        {
            SaveSettings();
        }

        if (BackButton.IsClicked())
        {
            Cancel();
        }
    }

    private void HandleMuteToggle()
    {
        if (ToggleMute.IsChecked)
        {
            Raylib.SetMasterVolume(0.0f);
        }
        else
        {
            Raylib.SetMasterVolume(1.0f);
        }
    }

    private void SaveSettings()
    {
        Log.Info($"[OptionsScreenLogic] Settings confirmed - New username: '{UserField.Text}'");
        ClearFields();
        Navigation.NavigateBack();
    }

    private void Cancel()
    {
        Log.Info("[OptionsScreenLogic] Cancelling settings changes");
        ClearFields();
        Navigation.NavigateBack();
    }
}

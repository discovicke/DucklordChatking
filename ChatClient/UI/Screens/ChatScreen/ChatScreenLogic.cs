using ChatClient.Core;
using ChatClient.UI.Components;

namespace ChatClient.UI.Screens;

/// <summary>
/// Simplified logic: only handles back button navigation.
/// Message input/send is now handled by ChatToolbar.
/// </summary>
public class ChatScreenLogic(ChatScreen screen, BackButton backButton) : IScreenLogic
{
    public void HandleInput()
    {
        backButton.Update();
        if (backButton.IsClicked())
        {
            Log.Info("[ChatScreenLogic] Navigating back to start screen");
            screen.StopPolling();
            AppState.CurrentScreen = Screen.Start;
        }
    }
}

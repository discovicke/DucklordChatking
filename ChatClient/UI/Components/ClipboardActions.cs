using ChatClient.Core;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChatClient.UI.Components
{
    public enum ClipboardAction
    {
        None,
        Copy,
        Paste,
        Cut,
        Undo
    }

    public class ClipboardActionsClass 
    {

        public static void BoardActions()
        {
            ClipboardAction action = ClipboardAction.None;
            bool ctrlDown = Raylib.IsKeyDown(KeyboardKey.LeftControl) || Raylib.IsKeyDown(KeyboardKey.RightControl);
            if (ctrlDown)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.C))
                {
                    action = ClipboardAction.Copy;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.V))
                {
                    action = ClipboardAction.Paste;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.X))
                {
                    action = ClipboardAction.Cut;
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Z))
                {
                    action = ClipboardAction.Undo;
                }
            }

            
        }

    }

}

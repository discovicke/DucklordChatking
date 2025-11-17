using Raylib_cs;

namespace ChatClient.UI.Components
{
    /// <summary>
    /// Responsible for: providing base functionality for all UI components with position and bounds management.
    /// Serves as abstract base class defining common interface for Update, Draw, and SetRect methods.
    /// </summary>
    public abstract class UIComponent
    {
        public Rectangle Rect { get; protected set; }

        protected Color BackgroundColor { get; set; }
        protected Color HoverColor { get; set; }
        protected Color TextColor { get; set; }

        // Allow screens/layout to reposition controls without exposing a public setter
        public void SetRect(Rectangle rect) => Rect = rect;

        public abstract void Draw();
        public virtual void Update() { }
    }
}
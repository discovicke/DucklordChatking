using Raylib_cs;

namespace ChatClient.UI.Components
{
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
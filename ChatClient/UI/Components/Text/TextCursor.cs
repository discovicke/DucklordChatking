namespace ChatClient.UI.Components.Text
{
    /// <summary>
    /// Responsible for: managing text cursor position and blinking animation within text fields.
    /// Handles cursor movement (left, right, home, end) and provides visible/invisible blinking feedback.
    /// </summary>
    public class TextCursor
    {
        private int RawPosition { get; set; }
        private float BlinkTimer { get; set; }
        public bool IsVisible { get; private set; } = false;
        private const float BlinkInterval = 0.5f;

        public int Position
        {
            get => RawPosition;
            set => RawPosition = Math.Clamp(value, 0, int.MaxValue);
        }
        
        public void ResetInvisible()
        {
            IsVisible = false;
            BlinkTimer = 0f;
        }

        public void Update(float deltaTime)
        {
            BlinkTimer += deltaTime;
            if (BlinkTimer >= BlinkInterval)
            {
                BlinkTimer = 0f;
                IsVisible = !IsVisible;
            }
        }

        public void ResetBlink()
        {
            BlinkTimer = 0f;
            IsVisible = true;
        }

        public void MoveLeft(int textLength)
        {
            if (RawPosition > 0)
            {
                RawPosition--;
                ResetBlink();
            }
        }

        public void MoveRight(int textLength)
        {
            if (RawPosition < textLength)
            {
                RawPosition++;
                ResetBlink();
            }
        }

        public void MoveToStart()
        {
            RawPosition = 0;
            ResetBlink();
        }

        public void MoveToEnd(int textLength)
        {
            RawPosition = textLength;
            ResetBlink();
        }

        public void Reset()
        {
            RawPosition = 0;
            ResetBlink();
        }
    }
}
using System;
using System.Drawing;

namespace TCPConsole {
    internal class RichTextBoxStyle {
        public String text = null;
        public Color color = Color.Black;
        public Color bgColor = Color.White;
        public bool isNewline = true;

        public RichTextBoxStyle(String text, Color color, bool isNewline) {
            this.text = text;
            this.color = color;
            this.isNewline = isNewline;
        }
        public RichTextBoxStyle(String text, Color color, Color bgColor, bool isNewline) {
            this.text = text;
            this.color = color;
            this.bgColor = bgColor;
            this.isNewline = isNewline;

        }
    }
}

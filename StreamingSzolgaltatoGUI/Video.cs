using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingSzolgaltatoGUI
{
    internal class Video
    {
        public string title;
        public int length;

        public Video(string title, int length)
        {
            this.title = title;
            this.length = length;
        }
    }
}

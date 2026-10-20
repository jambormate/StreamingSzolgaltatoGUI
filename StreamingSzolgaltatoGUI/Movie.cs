using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingSzolgaltatoGUI
{
    internal class Movie : IContent
    {
        public Video video;

        public Movie(Video video)
        {
            this.video = video;
        }

        public string getTitle()
        {
            return video.title;
        }

        public int getLength()
        {
            return video.length;
        }
    }
}

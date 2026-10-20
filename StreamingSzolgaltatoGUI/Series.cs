using System;
using System.Collections.Generic;
using System.Text;

namespace StreamingSzolgaltatoGUI
{
    internal class Series : IContent
    {
        public string title;
        public List<Video> videos;

        public Series(string title, Video video)
        {
            this.title = title;
            videos = new List<Video>();
            videos.Add(video);
        }

        public Series(string title, List<Video> videos)
        {
            this.title = title;
            this.videos = videos;
        }

        public string getTitle()
        {
            return title;
        }

        public int getLength()
        {
            int length = 0;

            foreach (Video video in videos)
            {
                length += video.length;
            }

            return length;
        }
    }
}

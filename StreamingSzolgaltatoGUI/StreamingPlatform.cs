using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StreamingSzolgaltatoGUI
{
    internal class StreamingPlatform
    {
        public List<IContent> contents;

        public StreamingPlatform()
        {
            contents = new List<IContent>();
        }

        public void addContent(IContent content)
        {
            contents.Add(content);
        }

        public IContent getLongest()
        {
            if (contents.Count == 0)
            {
                return null;
            }

            IContent longest = contents[0];

            foreach (IContent content in contents)
            {
                if (content.getLength() > longest.getLength())
                {
                    longest = content;
                }
            }

            return longest;
        }

        public void loadFromFile(string fileName)
        {
            contents.Clear();

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                string[] data = line.Split('|');

                if (data[0] == "Movie")
                {
                    Video video = new Video(
                        data[1],
                        int.Parse(data[2])
                    );

                    Movie movie = new Movie(video);
                    addContent(movie);
                }
                else if (data[0] == "Series")
                {
                    List<Video> videos = new List<Video>();
                    string[] episodes = data[2].Split(',');

                    foreach (string episode in episodes)
                    {
                        string[] episodeData = episode.Split(':');

                        Video video = new Video(
                            episodeData[0],
                            int.Parse(episodeData[1])
                        );

                        videos.Add(video);
                    }

                    Series series = new Series(data[1], videos);
                    addContent(series);
                }
            }
        }
    }
}

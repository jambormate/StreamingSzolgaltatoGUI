using Microsoft.VisualBasic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StreamingSzolgaltatoGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StreamingPlatform platform = new StreamingPlatform();
        List<IContent> filteredContents = new List<IContent>();

        public MainWindow()
        {
            InitializeComponent();

            string fileName = System.IO.Path.Combine(
                AppContext.BaseDirectory,
                "catalog.txt"
            );

            platform.loadFromFile(fileName);
            showContents(platform.contents);
        }

        void showContents(List<IContent> contents)
        {
            filteredContents = contents;

            ContentList.Items.Clear();

            foreach (IContent content in contents)
            {
                ContentList.Items.Add(
                    content.getTitle()
                    + " - "
                    + content.getLength()
                    + " perc"
                );
            }
        }

        private void SearchBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            string search = SearchBox.Text.ToLower();

            List<IContent> result = platform.contents
                .Where(content =>
                    content.getTitle().ToLower().Contains(search))
                .ToList();

            showContents(result);
        }

        private void LongestButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            if (filteredContents.Count == 0)
            {
                InfoText.Text = "Nincs találat.";
                return;
            }

            IContent longest = filteredContents[0];

            foreach (IContent content in filteredContents)
            {
                if (content.getLength() > longest.getLength())
                {
                    longest = content;
                }
            }

            InfoText.Text = "Leghosszabb: "
                + longest.getTitle()
                + " - "
                + longest.getLength()
                + " perc";

            ContentList.SelectedIndex =
                filteredContents.IndexOf(longest);
        }

        private void ContentList_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (ContentList.SelectedIndex >= 0 &&
                ContentList.SelectedIndex < filteredContents.Count)
            {
                IContent content =
                    filteredContents[ContentList.SelectedIndex];

                InfoText.Text = content.getTitle()
                    + " - "
                    + content.getLength()
                    + " perc";
            }
        }
    }
}

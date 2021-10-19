using evoFlix.WPF.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace evoFlix.WPF.ViewModels
{
    public class SubtitleSettingsViewModel : INotifyPropertyChanged
    {
        private bool chooseButtonIsEnabled;
        public bool ChooseButtonIsEnabled
        {
            get { return chooseButtonIsEnabled; }
            set
            {
                if (chooseButtonIsEnabled != value)
                {
                    chooseButtonIsEnabled = value;
                    NotifyPropertyChanged(nameof(ChooseButtonIsEnabled));
                }
            }
        }

        private ObservableCollection<ListBoxItem> availableSubtitles;
        public ObservableCollection<ListBoxItem> AvailableSubtitles
        {
            get { return availableSubtitles; }
            set
            {
                if (availableSubtitles != value)
                {
                    availableSubtitles = value;
                    NotifyPropertyChanged(nameof(AvailableSubtitles));
                }
            }
        }

        private ListBoxItem EmptyItem = new ListBoxItem { Content = "No Subtitle Found...", ToolTip = "" };

        private const int MaxListBoxItemLength = 30;

        public DropShadowEffect DefaultTextShadow = new DropShadowEffect { ShadowDepth = 1, BlurRadius = 5, Opacity = 1, Direction = 180 };

        private DropShadowEffect textShadow;
        public DropShadowEffect TextShadow
        {
            get { return textShadow; }
            set
            {
                if (textShadow != value)
                {
                    textShadow = value;
                    NotifyPropertyChanged("TextShadow");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public SubtitleSettingsViewModel()
        {
            AvailableSubtitles = new ObservableCollection<ListBoxItem>();
            TextShadow = new DropShadowEffect { ShadowDepth = 1, BlurRadius = 5, Opacity = 1, Direction = 180 };

            if (Heap.SubManager.AvailableSubtitlePaths.Count == 0)
            {
                AvailableSubtitles.Add(EmptyItem);
                ChooseButtonIsEnabled = false;
            }
            else
            {
                ChooseButtonIsEnabled = true;
                foreach (var subtitle in Heap.SubManager.AvailableSubtitlePaths)
                    AddItemToAvailableSubtitles(subtitle);
            }

        }

        public void AddItemToAvailableSubtitles(string subtitle)
        {

            if (!AvailableSubtitles.Contains(EmptyItem))
            {
                var listOfItems = new List<string>();
                foreach (var subtitleItem in AvailableSubtitles)
                    listOfItems.Add(subtitleItem.ToolTip.ToString());

                if (listOfItems.Contains(subtitle))
                    return;
            }
            else
                AvailableSubtitles = new ObservableCollection<ListBoxItem>();

            ChooseButtonIsEnabled = true;
            ListBoxItem item = new ListBoxItem();
            item.ToolTip = subtitle;
            if (subtitle.Length <= MaxListBoxItemLength)
                item.Content = subtitle;
            else
                item.Content = Regex.Replace(subtitle, @"^(?<begin>.{30}).*(?<ext>\" + System.IO.Path.GetExtension(subtitle) + ")$", @"${begin} ... ${ext}");

            AvailableSubtitles.Add(item);
        }


    }
}

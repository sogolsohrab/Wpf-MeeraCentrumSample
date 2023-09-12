using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Effects;
using WpfTestSample2MeeraCentrum.Properties;

namespace WpfTestSample2MeeraCentrum
{
    public class TreeModel : PropertyChangedBase
    {
        private string title;
        public string Title
        {
            get => this.title;
            set
            {
                this.title = value;
                OnPropertyChanged("Title");
            }
        }

        public string DisplayedImagePath { get; set; }
        public ObservableCollection<TreeModel> Items { get; set; }

        public CollectionView ItemsView { get; set; }

        public TreeModel(string value, string displayedImagePath)
        {
            Items = new ObservableCollection<TreeModel>();
            ItemsView = new ListCollectionView(Items)
            {
                SortDescriptions =
                    {
                        new SortDescription("Title",ListSortDirection.Ascending)
                    }
            };
            Title = value;
            DisplayedImagePath = displayedImagePath;
        }
    }
}

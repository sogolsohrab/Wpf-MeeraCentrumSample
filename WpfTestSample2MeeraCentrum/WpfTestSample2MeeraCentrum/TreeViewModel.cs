using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;
using WpfTestSample2MeeraCentrum.Properties;

namespace WpfTestSample2MeeraCentrum
{
    public class TreeViewModel : PropertyChangedBase
    {
        public TreeModel SelectedItem { get; set; }

        public ObservableCollection<TreeModel> Items { get; set; }

        public ICollectionView ItemsView { get; set; }
        

        public TreeViewModel()
        {
            Items = new ObservableCollection<TreeModel>();
            ItemsView = new ListCollectionView(Items)
            {
                SortDescriptions =
                    {
                        new SortDescription("Title", ListSortDirection.Ascending)
                    }
            };
        }


    }
}

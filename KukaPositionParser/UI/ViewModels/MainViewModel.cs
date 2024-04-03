using CommunityToolkit.Mvvm.ComponentModel;
using HelixToolkit.Wpf;
using KukaPositionParser.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace KukaPositionParser.UI.ViewModels
{
    internal partial  class MainViewModel:ObservableObject,IFileDragDropTarget
    {
        [ObservableProperty]
        private OptionsViewModel _options = new OptionsViewModel();


        public ObservableCollection<E6POS> Points { get; set; } = new ObservableCollection<E6POS>();
        [ObservableProperty]
        private Point3DCollection _locations = new Point3DCollection();
        public void OnFileDrop(string[] filepaths)
        {

            Points.Clear();
            Locations.Clear();

           
            var positions=filepaths.SelectMany(PositionParser.ParsePositions);

            foreach(var position in positions.OfType<E6POS>())
            {
                Points.Add(position);

                
                var point = new Point3D(position.X, position.Y, position.Z);
               Locations.Add(point);
            }

        }

        public MainViewModel()
        {
            const string path = @"C:\Users\admin\Desktop\697123\KRC\R1\Program\Production";

            OnFileDrop(new[] { path });
        }
    }
}

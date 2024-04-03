using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaPositionParser.UI.ViewModels
{
    internal partial class OptionsViewModel:ObservableObject
    {
        [ObservableProperty]
        private bool _infinateSpin = true;

        [ObservableProperty]
        private bool _showFrameRate = true;
    }
}

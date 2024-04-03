using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelixToolkit.Wpf;
using System.Windows;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
namespace KukaPositionParser.UI.ViewModels
{
    public partial class OptionsViewModel:ObservableObject 
    {
        private const string OPTIONS_FILE_NAME = "PositionParserOptions.xml";

        internal static OptionsViewModel Load()
        {
            var exists = File.Exists(OPTIONS_FILE_NAME);
            if(!exists)
            {
                Save(new OptionsViewModel());
            }

            var serializer = GetSerializer();
            using var reader = new StreamReader(OPTIONS_FILE_NAME);
            var result = serializer.Deserialize(reader) as OptionsViewModel??throw new NotImplementedException();

            return result;


        }

        private static XmlSerializer GetSerializer()
        {
            var result = new XmlSerializer(typeof(OptionsViewModel));

            return result;
        }

        internal static void Save(OptionsViewModel? value)
        {
            if (value == null) return;

            var serializer = GetSerializer();


            using var writer = new StreamWriter(OPTIONS_FILE_NAME);
            serializer.Serialize(writer,value);
        }

       
 

        [ObservableProperty]
        private double _opacity = 100.0;
        [ObservableProperty]
        private bool _infinateSpin = true;

        [ObservableProperty]
        private bool _showFrameRate = true;

        [ObservableProperty]
        private int _alternationCount = 0;

        [ObservableProperty]
        private double _cameraInertiaFactor = 0.93;
        [ObservableProperty]
        private bool _calculateCursorPosition = false;

        [ObservableProperty]
        private  CameraMode _cameraMode = CameraMode.Inspect;

        [ObservableProperty]
        private CameraRotationMode _cameraRotationMode = CameraRotationMode.Turntable;

    

        [ObservableProperty]
        private bool _fixedRotationPointEnabled;

        [ObservableProperty]
        private bool isChangeFieldOfViewEnabled=true;
 

        [ObservableProperty]
        private bool _isInertiaEnabled = false;

        [ObservableProperty]
        private bool _isManipulationEnabled = false;

        [ObservableProperty]
        private bool _isMoveEnabled = false;

        [ObservableProperty]
        private bool _isPanEnabled = false;

        [ObservableProperty]
        private bool _isRotationEnabled = false;

        [ObservableProperty]
        private bool _isZoomEnabled = false;
    }
}

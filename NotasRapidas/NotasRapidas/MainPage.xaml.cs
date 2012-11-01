using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Callisto.Controls;
using NotasRapidas.Acerca;
using NotasRapidas.Clases;
using Windows.UI;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotasRapidas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private BDManager bdAcciones;
        private Color _background = Color.FromArgb(255, 0, 77, 96);
        public MainPage()
        {
            this.InitializeComponent();

            Windows.Graphics.Display.DisplayProperties.AutoRotationPreferences = Windows.Graphics.Display.DisplayOrientations.Landscape | Windows.Graphics.Display.DisplayOrientations.LandscapeFlipped;
            Windows.Graphics.Display.DisplayProperties.OrientationChanged += new Windows.Graphics.Display.DisplayPropertiesEventHandler(DisplayProperties_OrientationChanged);


            bdAcciones = new BDManager();
            bdAcciones.CreateDataTable();

           SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            //SettingsPane.GetForCurrentView().CommandsRequested -= OnCommandsRequested;
            args.Request.ApplicationCommands.Clear();
            var about = new SettingsCommand("about", "Acerca de...", (handler) =>
            {
                var settings = new SettingsFlyout();
                settings.Content = new AcercaNotasRapidas();
                settings.HeaderBrush = new SolidColorBrush(_background);
                settings.HeaderText = "Acerca de Notas Rapidas";
                settings.IsOpen = true;
            });
            args.Request.ApplicationCommands.Add(about);
        }

        /// <summary>
        /// Orientacion
        /// </summary>
        /// <param name="sender"></param>
        private void DisplayProperties_OrientationChanged(object sender)
        {
            if (Windows.Graphics.Display.DisplayProperties.CurrentOrientation == Windows.Graphics.Display.DisplayOrientations.Landscape
                || Windows.Graphics.Display.DisplayProperties.CurrentOrientation == Windows.Graphics.Display.DisplayOrientations.LandscapeFlipped)
            {
                Output.Visibility = Visibility.Visible;
            }
            else
            {
                Output.Visibility = Visibility.Collapsed;
                MostrarMensaje();
            }
        }

        /// <summary>
        /// Mensaje de alerta landScape
        /// </summary>
        public async void MostrarMensaje()
        {
            MessageDialog msg = new MessageDialog("Solo se puede visualizar en LandScape.","Orientacion");
            await msg.ShowAsync();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

    }
}

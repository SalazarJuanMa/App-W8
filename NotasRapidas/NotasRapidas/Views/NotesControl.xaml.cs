using System;
using System.Collections.Generic;
using System.Linq;
using NotasRapidas.Clases;
using NotasRapidas.ViewModel;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NotasRapidas.Views
{
    public sealed partial class NotesControl : UserControl
    {
        private MainViewModel viewModel;

        public NotesControl()
        {
            viewModel = new MainViewModel();
            this.DataContext = viewModel;

            this.InitializeComponent();

          
        }

        private void btnAdd_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(viewModel.DatoNota))
                Alerta(); 
        }

        private void btnDelete_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if(viewModel.NotaSeleccionada == null)
                AlertaSeleccion();
        }

        private async void AlertaSeleccion()
        {
            MessageDialog msg = new MessageDialog("Debe seleccionar una nota");
            msg.ShowAsync();
        }


        private async void Alerta()
        {
            MessageDialog msg = new MessageDialog("Debe de contener titulo y cuerpo de nota");
            msg.ShowAsync();
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            viewModel.Titulo = txt.Text;
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            viewModel.DatoNota = txt.Text;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NotasRapidas.Clases;
using NotasRapidas.Model;

namespace NotasRapidas.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ModeloNotasRapidas modelo;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
                modelo = new ModeloNotasRapidas();
                modelo.PropertyChanged += ModeloOnPropertyChanged;
                modelo.RetornarNotasRapidas();
                NotaSeleccionadaCommand = new RelayCommand<TablaNota>(ExecuteNotaSeleccionadaAsync);
            }
        }

        #endregion

        #region CambioPropiedad
        private void ModeloOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "NotaCreada":
                    modelo.RetornarNotasRapidas();
                    RaisePropertyChanged("NotaCreada");
                    break;
                case "RemoverNota":
                    modelo.RetornarNotasRapidas();
                    RaisePropertyChanged("RemoverNota");
                    break;
                case "ListaNotas":
                    RaisePropertyChanged("ListaNotas");
                    break;
            }
        }
        #endregion

        #region Propiedades
        public List<TablaNota> ListaNotas
        {
            get
            {
                return modelo.ListaNotas;
            }
        }

        public TablaNota notaSeleccionada;
        public TablaNota NotaSeleccionada
        {
            get
            {
                return notaSeleccionada;
            }

            set
            {
                notaSeleccionada = value;
                RaisePropertyChanged("NotaSeleccionada");
            }
        }

        public string datoNota;
        public string DatoNota
        {
            get
            {
                return datoNota;
            }

            set
            {
                datoNota = value;
                RaisePropertyChanged("DatoNota");
            }
        }

        public string titulo;
        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
                RaisePropertyChanged("Titulo");
            }
        }
        #endregion

        #region Comandos
        /// <summary>
        /// Gets AgregarNotaCommand.
        /// </summary>
        public RelayCommand AgregarNotaCommand
        {
            get { return new RelayCommand(ExecuteAgregarNota); }
        }

        /// <summary>
        /// Gets EliminarNotaCommand.
        /// </summary>
        public RelayCommand EliminarNotaCommand
        {
            get { return new RelayCommand(ExecuteEliminarNota); }
        }

        public ICommand NotaSeleccionadaCommand
        {
            get;
            private set;
        }
        #endregion

        #region Accion
        private void ExecuteNotaSeleccionadaAsync(TablaNota obj) { }

        /// <summary>
        /// Ejecuta la acción Agregar Nota.
        /// </summary>
        private void ExecuteAgregarNota()
        {
            if(!string.IsNullOrEmpty(DatoNota))
            {
                modelo.CrearNotaRapida(Titulo, DatoNota);
                Titulo = "Titulo";
                DatoNota = "";
            }         
        }

        /// <summary>
        /// Ejecuta accion Eliminar nota
        /// </summary>
        private void ExecuteEliminarNota()
        {
            if (NotaSeleccionada != null)
                modelo.EliminarNotaRapida(NotaSeleccionada);
        }
        #endregion

    }
}
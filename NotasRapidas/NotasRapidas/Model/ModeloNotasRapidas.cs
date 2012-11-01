using System.Collections.Generic;
using System.ComponentModel;
using NotasRapidas.Clases;

namespace NotasRapidas.Model
{
    public class ModeloNotasRapidas : INotifyPropertyChanged
    {
  
        #region Propiedades
        public BDManager bdmanager = new BDManager();
        public List<TablaNota> listanotas;
        public List<TablaNota> ListaNotas
        {
            get
            {
                return listanotas;
            }
            set
            {
                listanotas = value;
                RaisePropertyChanged("ListaNotas");
            }
        }

        public bool notaCreada;
        public bool NotaCreada
        {
            get
            {
                return notaCreada;
            }
            set
            {
                notaCreada = value;
                RaisePropertyChanged("NotaCreada");
            }
        }

        public bool removerNota;
        public bool RemoverNota
        {
            get
            {
                return removerNota;
            }
            set
            {
                removerNota = value;
                RaisePropertyChanged("RemoverNota");
            }
        }

        #endregion

        #region Metodos
        public async void CrearNotaRapida(string titulo, string dato)
        {
           NotaCreada = await  bdmanager.CreateNote(titulo, dato);
        }

        public async void RetornarNotasRapidas()
        {
            ListaNotas =  await bdmanager.ReturnNotes();
          

            if( ListaNotas == null || ListaNotas.Count == 0)
                CrearNotaRapida("Titulo","");
        }

        public  void EliminarNotaRapida(TablaNota dataNotes)
        {
           RemoverNota =  bdmanager.RemoveNote(dataNotes);
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

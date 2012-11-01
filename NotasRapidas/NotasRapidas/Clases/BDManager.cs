using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace NotasRapidas.Clases
{
    public class BDManager
    {
        string _path;
        string _connectionString;
        private const string DatabaseName = "notasrapidas.sqlite";
        /// <summary>
        /// Base de datos
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private SQLiteAsyncConnection GetConnection(ref string path)
        {
                path = _path;
                _connectionString = DatabaseName;
                _path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, DatabaseName);
                return new SQLiteAsyncConnection(_connectionString);
        }

        /// <summary>
        /// Crear tablas
        /// </summary>
        public async void CreateDataTable()
        {
            string path = null;
            var conn = GetConnection(ref path);
            await conn.CreateTableAsync<TablaNota>();
        }

        /// <summary>
        /// Crear Nota
        /// </summary>
        /// <param name="title"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> CreateNote(string title, string data)
        {
            bool valNote = false;
            try
            {
                string path = null;
                var conn = GetConnection(ref path);

                    TablaNota insertaNota = new TablaNota()
                    {
                        Titulo = title,
                        Dato = data,
                        Fecha = String.Format("{0:dd/MM/yyyy}", DateTime.Now),
                    };

                    await conn.InsertAsync(insertaNota);
                    valNote = true;
                
            }
            catch (Exception exception)
            {
                return false;
            }
            return valNote;
        }

        /// <summary>
        /// Lista de Notas Existentes
        /// </summary>
        /// <returns></returns>
        public async Task<List<TablaNota>> ReturnNotes()
        {
            List<TablaNota> result = new List<TablaNota>();
          try
            {
                string path = null;
                var conn = GetConnection(ref path);
                var query =  conn.Table<TablaNota>();
                result = await query.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Eliminar Nota
        /// </summary>
        /// <param name="dataNotes"></param>
        /// <returns></returns>
        public bool RemoveNote(TablaNota dataNotes)
        {
            bool valNote = false;
            try
            {
                string path = null;
                var conn = GetConnection(ref path);
                conn.DeleteAsync(dataNotes);
                valNote = true;

            }
            catch (Exception)
            {
                return false;
            }

            return valNote;
        }
    }
}

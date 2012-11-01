using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace NotasRapidas.Clases
{
    public class TablaNota
    {
        #region Data
        /// <summary>
        /// PrimaryKey Identificator
        /// </summary>
        [AutoIncrement, PrimaryKey]
        public int IdNota { get; set; }
        /// <summary>
        /// Title Note
        /// </summary>
        [MaxLength(50)]
        public string Titulo { get; set; }
        /// <summary>
        /// Data Note
        /// </summary>
        [MaxLength(2500)]
        public string Dato { get; set; }
        /// <summary>
        /// Date Note
        /// </summary>
        public string Fecha { get; set; }
        #endregion
    }
}

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace jmantillaS7
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string  Usuario { get; set; }
        [MaxLength(100)]
        public string Contrasena { get; set; }
    }
}

using System;

namespace ControlLibrosLeídos
{
    class Libro
    {
        public string Titulo{ get; set; }
        public string Autor{ get; set; }
        public bool Fav { get; set; } 

        public Libro(string titulo, string autor)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Fav = false;
        }
    }
}

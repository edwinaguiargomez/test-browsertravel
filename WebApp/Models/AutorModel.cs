using Entities;
using Logic;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class AutorModel
    {
        public Autor Autor { get; set; } = new Autor();
        public List<Libro> ListLibros { get; set; } = new List<Libro>();
        public List<Autor> ListAutor { get; set; } = new List<Autor>();
    }
}

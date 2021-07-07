using Entities;
using Logic;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class LibroModel
    {
        public Libro Libro { get; set; } = new Libro();
        public List<Libro> ListLibros { get; set; } = new List<Libro>();
        public List<Editorial> ListEditoriales { get; set; } = new List<Editorial>();

    }
}

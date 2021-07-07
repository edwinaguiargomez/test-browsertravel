using Entities;
using Logic;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class EditorialModel
    {
        public Editorial Editorial { get; set; } = new Editorial();
        public List<Libro> ListLibros { get; set; } = new List<Libro>();
        public List<Editorial> ListEditorial { get; set; } = new List<Editorial>();
    }
}

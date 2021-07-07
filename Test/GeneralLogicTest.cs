using AssemblyStructure;
using Entities;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class GeneralLogicTest
    {
        [TestMethod]
        public void Test01Get()
        {
            List<Libro> resultLibro = new LibroLogic().Get();
            Assert.IsInstanceOfType(resultLibro, typeof(List<Libro>));

            List<Autor> resultAutor = new AutorLogic().Get();
            Assert.IsInstanceOfType(resultAutor, typeof(List<Autor>));

            List<Editorial> resultEditorial = new EditorialLogic().Get();
            Assert.IsInstanceOfType(resultEditorial, typeof(List<Editorial>));
        }

        [TestMethod]
        public void Test02Create()
        {
            Libro typeLibro = new Libro
            {
                Id = 0,
                Titulo = "El hombre invisible",
                NPaginas = "143",
                EditorialId = 1,                
                Sinopsis = "La historia es narrada en primera persona por un protagonista anónimo que dice que es una persona invisible."
            };
            Libro resultLibro = new LibroLogic().Create(typeLibro);
            Assert.IsInstanceOfType(resultLibro, typeof(Libro));

            Autor typeAutor = new Autor
            {
                Id = 0,
                Nombres = "Edwin Antonio",
                Apellidos = "Aguiar Gomez"
            };
            Autor resultAutor = new AutorLogic().Create(typeAutor);
            Assert.IsInstanceOfType(resultAutor, typeof(Autor));

            Editorial typeEditorial = new Editorial
            {
                Id = 0,
                Nombre = "Edwin AG",
                Sede = "Tulua"
            };
            Editorial resultEditorial = new EditorialLogic().Create(typeEditorial);
            Assert.IsInstanceOfType(resultEditorial, typeof(Editorial));
        }

        [TestMethod]
        public void Test03Update()
        {
            Libro typeLibro = new LibroLogic().GetById(x => x.Titulo.Equals("El hombre invisible"));
            Libro resultLibro = new LibroLogic().Update(typeLibro);
            Assert.IsInstanceOfType(resultLibro, typeof(Libro));

            Autor typeAutor = new AutorLogic().GetById(x => x.Nombres.Equals("Edwin Antonio"));
            Autor resultAutor = new AutorLogic().Update(typeAutor);
            Assert.IsInstanceOfType(resultAutor, typeof(Autor));

            Editorial typeEditorial = new EditorialLogic().GetById(x => x.Nombre.Equals("Edwin AG"));
            Editorial resultEditorial = new EditorialLogic().Update(typeEditorial);
            Assert.IsInstanceOfType(resultEditorial, typeof(Editorial));

        }

        [TestMethod]
        public void Test04Remove()
        {
            Libro typeLibro = new LibroLogic().GetById(x => x.Titulo.Equals("El hombre invisible"));
            Libro resultLibro = new LibroLogic().Remove(typeLibro);
            Assert.IsInstanceOfType(resultLibro, typeof(Libro));

            Autor typeAutor = new AutorLogic().GetById(x => x.Nombres.Equals("Edwin Antonio"));
            Autor resultAutor = new AutorLogic().Remove(typeAutor);
            Assert.IsInstanceOfType(resultAutor, typeof(Autor));

            Editorial typeEditorial = new EditorialLogic().GetById(x => x.Nombre.Equals("Edwin AG"));
            Editorial resultEditorial = new EditorialLogic().Remove(typeEditorial);
            Assert.IsInstanceOfType(resultEditorial, typeof(Editorial));
        }
    }
}

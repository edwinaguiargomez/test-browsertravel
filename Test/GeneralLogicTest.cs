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

        private DBConfig dBConfig = new DBConfig { PathDB = "../../../../TravelDB.mdf" };

        [TestMethod]
        public void Test01Get()
        {
            List<Libro> resultLibro = new LibroLogic(dBConfig).Get();
            Assert.IsInstanceOfType(resultLibro, typeof(List<Libro>));

            List<Autor> resultAutor = new AutorLogic(dBConfig).Get();
            Assert.IsInstanceOfType(resultAutor, typeof(List<Autor>));

            List<Editorial> resultEditorial = new EditorialLogic(dBConfig).Get();
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
            Libro resultLibro = new LibroLogic(dBConfig).Create(typeLibro);
            Assert.IsInstanceOfType(resultLibro, typeof(Libro));

            Autor typeAutor = new Autor
            {
                Id = 0,
                Nombres = "Edwin Antonio",
                Apellidos = "Aguiar Gomez"
            };
            Autor resultAutor = new AutorLogic(dBConfig).Create(typeAutor);
            Assert.IsInstanceOfType(resultAutor, typeof(Autor));

            Editorial typeEditorial = new Editorial
            {
                Id = 0,
                Nombre = "Edwin AG",
                Sede = "Tulua"
            };
            Editorial resultEditorial = new EditorialLogic(dBConfig).Create(typeEditorial);
            Assert.IsInstanceOfType(resultEditorial, typeof(Editorial));
        }

        [TestMethod]
        public void Test03Update()
        {
            Libro typeLibro = new LibroLogic(dBConfig).GetById(x => x.Titulo.Equals("El hombre invisible"));
            Libro resultLibro = new LibroLogic(dBConfig).Update(typeLibro);
            Assert.IsInstanceOfType(resultLibro, typeof(Libro));

            Autor typeAutor = new AutorLogic(dBConfig).GetById(x => x.Nombres.Equals("Edwin Antonio"));
            Autor resultAutor = new AutorLogic(dBConfig).Update(typeAutor);
            Assert.IsInstanceOfType(resultAutor, typeof(Autor));

            Editorial typeEditorial = new EditorialLogic(dBConfig).GetById(x => x.Nombre.Equals("Edwin AG"));
            Editorial resultEditorial = new EditorialLogic(dBConfig).Update(typeEditorial);
            Assert.IsInstanceOfType(resultEditorial, typeof(Editorial));

        }

        [TestMethod]
        public void Test04Remove()
        {
            Libro typeLibro = new LibroLogic(dBConfig).GetById(x => x.Titulo.Equals("El hombre invisible"));
            Libro resultLibro = new LibroLogic(dBConfig).Remove(typeLibro);
            Assert.IsInstanceOfType(resultLibro, typeof(Libro));

            Autor typeAutor = new AutorLogic(dBConfig).GetById(x => x.Nombres.Equals("Edwin Antonio"));
            Autor resultAutor = new AutorLogic(dBConfig).Remove(typeAutor);
            Assert.IsInstanceOfType(resultAutor, typeof(Autor));

            Editorial typeEditorial = new EditorialLogic(dBConfig).GetById(x => x.Nombre.Equals("Edwin AG"));
            Editorial resultEditorial = new EditorialLogic(dBConfig).Remove(typeEditorial);
            Assert.IsInstanceOfType(resultEditorial, typeof(Editorial));
        }
    }
}

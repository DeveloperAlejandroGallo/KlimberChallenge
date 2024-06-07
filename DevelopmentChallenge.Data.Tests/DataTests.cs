﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            IIdiomaSalida idioma = new Castellano();
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                ImpresorReporte.Imprimir(new List<IFormaGeometrica>(), idioma));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            IIdiomaSalida idioma = new Ingles();
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                ImpresorReporte.Imprimir(new List<IFormaGeometrica>(), idioma));
        }


        [TestCase]
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            IIdiomaSalida idiomaItaliano = new Italiano();
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                ImpresorReporte.Imprimir(new List<IFormaGeometrica>(), idiomaItaliano));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<IFormaGeometrica> {new Cuadrado(5)};
            IIdiomaSalida idiomaCastellano = new Castellano();

            var resumen = ImpresorReporte.Imprimir(cuadrados, idiomaCastellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };

            IIdiomaSalida idiomaIngles = new Ingles();

            var resumen = ImpresorReporte.Imprimir(cuadrados, idiomaIngles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            IIdiomaSalida idiomaIngles = new Ingles();

            var resumen = ImpresorReporte.Imprimir(formas, idiomaIngles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            IIdiomaSalida idiomaCastellano = new Castellano();

            var resumen = ImpresorReporte.Imprimir(formas, idiomaCastellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            IIdiomaSalida idiomaCastellano = new Italiano();

            var resumen = ImpresorReporte.Imprimir(formas, idiomaCastellano);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}

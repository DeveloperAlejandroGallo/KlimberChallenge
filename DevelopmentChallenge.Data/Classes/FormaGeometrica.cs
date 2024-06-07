/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        void Incrementar();
    }

    public interface IIdiomaSalida
    {
        string InicioReporte(bool any);
        string Datos();
        string FinReporte();

    }

    //Formas
    public abstract class FormaGeometrica : IFormaGeometrica
    {
        public decimal _lado;

        protected FormaGeometrica(decimal lado)
        {
            _lado = lado;
        }

        public abstract decimal CalcularArea();

        public abstract decimal CalcularPerimetro();
        public abstract void Incrementar();
    }


    public class Cuadrado : FormaGeometrica
    {

        public Cuadrado(decimal lado) : base(lado)
        {

        }

        public override decimal CalcularArea()
        {
            var area = _lado * _lado;

            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var perimetro = _lado * 4;

            return perimetro;
        }

        public override void Incrementar()
        {
            Total.Cuadrados++;
            Total.PerimetroCuadrados += CalcularPerimetro();
            Total.AreaCuadrados += CalcularArea();
        }


    }


    public class Circulo : FormaGeometrica
    {
        public static int Cantidad = 0;
        public Circulo(decimal radio) : base(radio) { }

        public override decimal CalcularArea()
        {
            var area = (decimal)Math.PI * (_lado / 2) * (_lado / 2);
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var perimetro = (decimal)Math.PI * _lado;
            return perimetro;

        }

        public override void Incrementar()
        {
            Total.Circulos++;
            Total.PerimetroCirculos += CalcularPerimetro();
            Total.AreaCirculos += CalcularArea();
        }

    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        public TrianguloEquilatero(decimal lado) : base(lado) { }

        public override decimal CalcularArea()
        {
            var area = ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var perimetro = _lado * 3;
            return perimetro;
        }

        public override void Incrementar()
        {
            Total.Triangulos++;
            Total.PerimetroTriangulos += CalcularPerimetro();
            Total.AreaTriangulos += CalcularArea();
        }


    }


    public class Trapecio : FormaGeometrica
    {
        private decimal _baseMenor;
        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura) : base(baseMayor)
        {
            _baseMenor = baseMenor;
            _lado = altura;
        }

        public override decimal CalcularArea()
        {
            var area = ((_baseMenor + _lado) / 2) * _lado;
            return area;
        }

        public override void Incrementar()
        {
            Total.Trapecios++;
            Total.AreaTrapecios += CalcularArea();
            Total.PerimetroTrapecios += CalcularPerimetro();

        }

        public override decimal CalcularPerimetro()
        {
            var perimetro = _lado + _baseMenor + _lado + _lado;
            return perimetro;
        }

    }


    public class Rectangulo : FormaGeometrica
    {
        private decimal _base;
        public Rectangulo(decimal altura, decimal baseMenor) : base(altura)
        {
            _base = baseMenor;
        }

        public override decimal CalcularArea()
        {
            var area = _base * _lado;
            return area;
        }

        public override decimal CalcularPerimetro()
        {
            var perimetro = (_lado * 2) + (_base * 2);
            return perimetro;

        }

        public override void Incrementar()
        {
            Total.Rectangulos++;
            Total.AreaRectangulos += CalcularArea();
            Total.PerimetroRectangulos += CalcularPerimetro();
        }

       
    }

    public static class Total
    {
        public static int Cuadrados { get; set; }
        public static decimal AreaCuadrados { get; set; }
        public static decimal PerimetroCuadrados { get; set; }

        public static int Circulos { get; set; }
        public static decimal AreaCirculos { get; set; }
        public static decimal PerimetroCirculos { get; set; }

        public static int Triangulos { get; set; }
        public static decimal AreaTriangulos { get; set; }
        public static decimal PerimetroTriangulos { get; set; }

        public static int Trapecios { get; set; }
        public static decimal AreaTrapecios { get; set; }
        public static decimal PerimetroTrapecios { get; set; }

        public static int Rectangulos { get; set; }
        public static decimal AreaRectangulos { get; set; }
        public static decimal PerimetroRectangulos { get; set; }



        public static void Reset()
        {
            Cuadrados = 0;
            AreaCuadrados = 0;
            PerimetroCuadrados = 0;

            Circulos = 0;
            AreaCirculos = 0;
            PerimetroCirculos = 0;

            Triangulos = 0;
            AreaTriangulos = 0;
            PerimetroTriangulos = 0;

            Trapecios = 0;
            AreaTrapecios = 0;
            PerimetroTrapecios = 0;

            Rectangulos = 0;
            AreaRectangulos = 0;
            PerimetroRectangulos = 0;

        }
    }

    //Idiomas
    public class Castellano : IIdiomaSalida
    {
        public string InicioReporte(bool any) => any ? "<h1>Reporte de Formas</h1>" : "<h1>Lista vacía de formas!</h1>";
        public string Datos()
        {
            var sb = new StringBuilder();


            if (Total.Cuadrados > 0)
                sb.Append($"{Total.Cuadrados} {(Total.Cuadrados > 1 ? "Cuadrados" : "Cuadrado")} | Area {Total.AreaCuadrados:#.##} | Perimetro {Total.PerimetroCuadrados:#.##} <br/>");

            if (Total.Circulos > 0)
                sb.Append($"{Total.Circulos} {(Total.Circulos > 1 ? "Círculos" : "Círculo")} | Area {Total.AreaCirculos:#.##} | Perimetro {Total.PerimetroCirculos:#.##} <br/>");

            if (Total.Triangulos > 0)
                sb.Append($"{Total.Triangulos} {(Total.Triangulos > 1 ? "Triángulos" : "Triángulo")} | Area {Total.AreaTriangulos:#.##} | Perimetro {Total.PerimetroTriangulos:#.##} <br/>");

            if (Total.Trapecios > 0)
                sb.Append($"{Total.Trapecios} {(Total.Trapecios > 1 ? "Trapecios" : "Trapecio")} | Area {Total.AreaTrapecios:#.##} | Perimetro {Total.PerimetroTrapecios:#.##} <br/>");

            if (Total.Rectangulos > 0)
                sb.Append($"{Total.Rectangulos} {(Total.Rectangulos > 1 ? "Rectangulos" : "Rectangulo")} | Area {Total.AreaRectangulos:#.##} | Perimetro {Total.PerimetroRectangulos:#.##} <br/>");

            return sb.ToString();
        }


        public string FinReporte()
        {
            var sb = new StringBuilder();

            var cantidadFormas = Total.Cuadrados + Total.Circulos + Total.Triangulos + Total.Trapecios + Total.Rectangulos;
            var perimetroTotal = Total.PerimetroCuadrados + Total.PerimetroTriangulos + Total.PerimetroCirculos + Total.PerimetroTrapecios + Total.PerimetroRectangulos;
            var areaTotal = Total.AreaCuadrados + Total.AreaCirculos + Total.AreaTriangulos + Total.AreaTrapecios + Total.AreaRectangulos;

            sb.Append("TOTAL:<br/>");
            sb.Append(cantidadFormas + " formas ");
            sb.Append("Perimetro " + perimetroTotal.ToString("#.##") + " ");
            sb.Append("Area " + areaTotal.ToString("#.##"));

            return sb.ToString();
        }

    }

    public class Ingles : IIdiomaSalida
    {
        public string InicioReporte(bool any) => any ? "<h1>Shapes report</h1>" : "<h1>Empty list of shapes!</h1>";
        public string Datos()
        {
            var sb = new StringBuilder();


            if (Total.Cuadrados > 0)
                sb.Append($"{Total.Cuadrados} {(Total.Cuadrados > 1 ? "Squares" : "Square")} | Area {Total.AreaCuadrados:#.##} | Perimeter {Total.PerimetroCuadrados:#.##} <br/>");

            if (Total.Circulos > 0)
                sb.Append($"{Total.Circulos} {(Total.Circulos > 1 ? "Circles" : "Circle")} | Area {Total.AreaCirculos:#.##} | Perimeter {Total.PerimetroCirculos:#.##} <br/>");

            if (Total.Triangulos > 0)
                sb.Append($"{Total.Triangulos} {(Total.Triangulos > 1 ? "Triangles" : "Triangle")} | Area {Total.AreaTriangulos:#.##} | Perimeter {Total.PerimetroTriangulos:#.##} <br/>");
                
            if (Total.Trapecios > 0)
                sb.Append($"{Total.Trapecios} {(Total.Trapecios > 1 ? "Trapezoids" : "Trapeze")} | Area {Total.AreaTrapecios:#.##} | Perimeter {Total.PerimetroTrapecios:#.##} <br/>");

            if (Total.Rectangulos > 0)
                sb.Append($"{Total.Rectangulos} {(Total.Rectangulos > 1 ? "Rectangles" : "Rectangle")} | Area {Total.AreaRectangulos:#.##} | Perimeter {Total.PerimetroRectangulos:#.##} <br/>");
                
            return sb.ToString();
        }
        public string FinReporte()
        {
            var sb = new StringBuilder();

            var cantidadFormas = Total.Cuadrados + Total.Circulos + Total.Triangulos + Total.Trapecios + Total.Rectangulos;
            var perimetroTotal = Total.PerimetroCuadrados + Total.PerimetroTriangulos + Total.PerimetroCirculos + Total.PerimetroTrapecios + Total.PerimetroRectangulos;
            var areaTotal = Total.AreaCuadrados + Total.AreaCirculos + Total.AreaTriangulos + Total.AreaTrapecios + Total.AreaRectangulos;

            sb.Append("TOTAL:<br/>");
            sb.Append(cantidadFormas + " shapes ");
            sb.Append("Perimeter " + perimetroTotal.ToString("#.##") + " ");
            sb.Append("Area " + areaTotal.ToString("#.##"));

            return sb.ToString();
        }
    }

    public class Italiano : IIdiomaSalida
    {
        public string InicioReporte(bool any) => any ? "<h1>Rapporto sui moduli</h1>" : "<h1>Elenco vuoto di forme!</h1>";
        public string Datos()
        {
            var sb = new StringBuilder();

            if (Total.Cuadrados > 0)
            sb.Append($"{Total.Cuadrados} {(Total.Cuadrados > 1 ? "Quadrati" : "Quadrato")} | Area {Total.AreaCuadrados:#.##} | Perimetro {Total.PerimetroCuadrados:#.##} <br/>");

            if (Total.Circulos > 0)
            sb.Append($"{Total.Circulos} {(Total.Circulos > 1 ? "Cerchi" : "Cerchio")} | Area {Total.AreaCirculos:#.##} | Perimetro {Total.PerimetroCirculos:#.##} <br/>");

            if (Total.Triangulos > 0)
            sb.Append($"{Total.Triangulos} {(Total.Triangulos > 1 ? "Triangoli" : "Triangolo")} | Area {Total.AreaTriangulos:#.##} | Perimetro {Total.PerimetroTriangulos:#.##} <br/>");

            if (Total.Trapecios > 0)
            sb.Append($"{Total.Trapecios} {(Total.Trapecios > 1 ? "Trapezi" : "Trapezio")} | Area {Total.AreaTrapecios:#.##} | Perimetro {Total.PerimetroTrapecios:#.##} <br/>");

            if (Total.Rectangulos > 0)
            sb.Append($"{Total.Rectangulos} {(Total.Rectangulos > 1 ? "Rettangoli" : "Rettangolo")} | Area {Total.AreaRectangulos:#.##} | Perimetro {Total.PerimetroRectangulos:#.##} <br/>");



            return sb.ToString();

        }

        public string FinReporte()
        {
            var sb = new StringBuilder();

            var cantidadFormas = Total.Cuadrados + Total.Circulos + Total.Triangulos + Total.Trapecios + Total.Rectangulos;
            var perimetroTotal = Total.PerimetroCuadrados + Total.PerimetroTriangulos + Total.PerimetroCirculos + Total.PerimetroTrapecios + Total.PerimetroRectangulos;
            var areaTotal = Total.AreaCuadrados + Total.AreaCirculos + Total.AreaTriangulos + Total.AreaTrapecios + Total.AreaRectangulos;

            sb.Append("TOTAL:<br/>");
            sb.Append(cantidadFormas + " forme ");
            sb.Append("Perimetro " + perimetroTotal.ToString("#.##") + " ");
            sb.Append("Area " + areaTotal.ToString("#.##"));

            return sb.ToString();
        }
    }

    public class ImpresorReporte
    {
        public static string Imprimir(List<IFormaGeometrica> formas, IIdiomaSalida idioma)
        {
            var sb = new StringBuilder();

            Total.Reset();

            if (!formas.Any())
            {
                sb.Append(idioma.InicioReporte(false));
            }
            else
            {
                sb.Append(idioma.InicioReporte(true));

                foreach (var forma in formas)
                {
                    forma.Incrementar();
                }
                sb.Append(idioma.Datos());

                sb.Append(idioma.FinReporte());
            }

            return sb.ToString();
        }
    }


    public class FormaGeometricaOld
    {
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;

        #endregion

        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;

        #endregion

        private readonly decimal _lado;

        public int Tipo { get; set; }

        public FormaGeometricaOld(int tipo, decimal ancho)
        {
            Tipo = tipo;
            _lado = ancho;
        }

        public static string Imprimir(List<FormaGeometricaOld> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (idioma == Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                for (var i = 0; i < formas.Count; i++)
                {
                    if (formas[i].Tipo == Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += formas[i].CalcularArea();
                        perimetroCuadrados += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += formas[i].CalcularArea();
                        perimetroCirculos += formas[i].CalcularPerimetro();
                    }
                    if (formas[i].Tipo == TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += formas[i].CalcularArea();
                        perimetroTriangulos += formas[i].CalcularPerimetro();
                    }
                }

                sb.Append(ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
                sb.Append(ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
                sb.Append(ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Castellano)
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        private static string TraducirForma(int tipo, int cantidad, int idioma)
        {
            switch (tipo)
            {
                case Cuadrado:
                    if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Circulo:
                    if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case TrianguloEquilatero:
                    if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }

        public decimal CalcularArea()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * _lado;
                case Circulo: return (decimal)Math.PI * (_lado / 2) * (_lado / 2);
                case TrianguloEquilatero: return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public decimal CalcularPerimetro()
        {
            switch (Tipo)
            {
                case Cuadrado: return _lado * 4;
                case Circulo: return (decimal)Math.PI * _lado;
                case TrianguloEquilatero: return _lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }
    }
}

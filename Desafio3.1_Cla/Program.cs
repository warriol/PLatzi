using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Desafio3._1_Cla
{
    class Program
    {
        #region Constantes
        // constantes utiles para recuadro mensajes y urls
        const string _MarcoSuperior = "╔═══════════════════════════════════════════════╗";
        const string _MarcoMedio = "╠═══════════════════════════════════════════════╣";
        const string _MarcoInferior = "╚═══════════════════════════════════════════════╝";
        const string _lineaSimple = "--------------------------------------------------";
        const string _lineaDoble = "==================================================";
        const string _lineaSubMenu = "+-------------------------+";
        const string _titulo = "║\t\tInicio del Programa\t\t║";
        const string _crearImagenes = "║\t\t Creo lista de Imagenes \t\t║";
        const string _crearVideos = "║\t\t Creo lista de Videos \t\t║";
        const string _MensajeOpcion = "\n\t ==> Ingresa tu opción: ";
        const string _ErrorOpciones = "║\t\t ERROR: elija un número del 1 al 7.\t\t║";
        const string _Salir = "║\t\t Eligió SALIR. Adios!. \t\t║";
        const string _Continuar = "║    Presione cualquier tecla para continuar...\t║";
        const string _TablaVacia = "║\t La Tabla esta vacia: \t║";
        const string _TablaNoVacia = "║\t La Tabla tiene contenido: \t║";
        const string _urlImagenes = "http://localhost:62033/api/Imagens";
        const string _urlVideos = "http://localhost:62033/api/Videos";
        #endregion

        #region Arrays
        // menu
        public static string[] _Opciones =
        {
            "║\t\t1- Listar Imagenes\t\t║",
            "║\t\t2- Listar Videos\t\t║",
            "║\t\t3- Cargar Imagen\t\t║",
            "║\t\t4- Cargar Video\t\t\t║",
            "║\t\t5- Eliminar Imagen\t\t║",
            "║\t\t6- Eliminar Video\t\t║",
            "║\t\t7- Listar Img Json\t\t║",
            "║\t\t8- Salir\t\t\t║"
        };

        // referencia para crear imagen
        public static string[] _cargarImagen =
        {
            "Nombre de la Imagen: ",
            "Ruta de la Imagen: ",
            "Ancho de la Imagen: ",
            "Alto de la Imagen: ",
            "Formato de la Imagen: "
        };

        // referencia para crear videos
        public static string[] _cargarVideo =
        {
            "Nombre del Video: ",
            "Ruta del Video: ",
            "Ancho del Video: ",
            "Alto del Video: ",
            "Formato del Video: ",
            "Duracion del Video: "
        };

        // lista de Imagenes para crear
        public static string[] _Imagenes =
        {
            "Nombre=WDAImagen1&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen2&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen3&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen4&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen5&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen6&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen7&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen8&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDAImagen9&Patch=ruta/a/imagenes&TamanoWidth=1024&TamanoHeight=900&FormatoImagen=0",
            "Nombre=WDA1Imagen1&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen2&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen3&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen4&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen5&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen6&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen7&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen8&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA1Imagen9&Patch=ruta/a/imagenes1&TamanoWidth=2048&TamanoHeight=1024&FormatoImagen=1",
            "Nombre=WDA2Imagen1&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2",
            "Nombre=WDA2Imagen2&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2",
            "Nombre=WDA2Imagen3&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2",
            "Nombre=WDA2Imagen4&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2",
            "Nombre=WDA2Imagen5&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2",
            "Nombre=WDA2Imagen6&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2",
            "Nombre=WDA2Imagen7&Patch=ruta/a/imagenes2&TamanoWidth=3064&TamanoHeight=2048&FormatoImagen=2"
        };

        // lista de Video para crear
        public static string[] _Videos =
        {
            "Nombre=WDAVideos1&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos2&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos3&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos4&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos5&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos6&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos7&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos8&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDAVideos9&Patch=ruta/a/Videos&TamanoWidth=1024&TamanoHeight=900&FormatoVideo=0&Duracion=125",
            "Nombre=WDA1Videos1&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos2&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos3&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos4&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos5&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos6&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos7&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos8&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA1Videos9&Patch=ruta/a/Videos1&TamanoWidth=2048&TamanoHeight=1024&FormatoVideo=1&Duracion=125",
            "Nombre=WDA2Videos1&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125",
            "Nombre=WDA2Videos2&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125",
            "Nombre=WDA2Videos3&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125",
            "Nombre=WDA2Videos4&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125",
            "Nombre=WDA2Videos5&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125",
            "Nombre=WDA2Videos6&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125",
            "Nombre=WDA2Videos7&Patch=ruta/a/Videos2&TamanoWidth=3064&TamanoHeight=2048&FormatoVideo=2&Duracion=125"
        };
        #endregion

        static void Main(string[] args)
        {
            // Creo lista para Imagenes
            int opcion;//opcion del menu 
            // mantengo la consola en espera de que el usuario elija un opcion
            do
            {
                Console.Clear();//se limpia consola

                opcion = menu();//muestra menu y espera opción

                switch (opcion)
                {
                    case 1:
                        // lista todas las imagenes, si no hay indica que esta vacia la tabla
                        ListarImagen();
                        break;
                    case 2:
                        // lista todos los videos, si no hay indica q la tabal esta vacía
                        ListarVideo();
                        break;
                    case 3:
                        // crea imagenes de acuerdo al array creado al principio
                        CargarImagen();
                        break;
                    case 4:
                        // crea videos de acuerdo al array creado al principio
                        CaragrVideo();
                        break;
                    case 5:
                        // elimna imagenes, se mostrara un lista de ID - NOmbre, y se le pedirá al usario el ID a borrar
                        EliminarImagen();
                        break;
                    case 6:
                        // elimna videos, se mostrara un lista de ID - NOmbre, y se le pedirá al usario el ID a borrar
                        EliminarVideo();
                        break;
                    case 7:
                        // mierda!!! era con json hice cualquier cosa, y ahora no veo como mierda se hace
                        ListarImagenJson();
                        break;
                    case 8: break; // Salir
                    default:
                        // error
                        mensaje(_ErrorOpciones);
                        break;
                }

            }
            while (opcion != 8);

            mensaje(_Salir);
        }

        #region opciones del menu
        // Lista las imagenes
        static void ListarImagen()
        {
            // codigo para listar imagenes
            ListarTablas(_urlImagenes, "Imagenes");
            // mensaje("Listar Imagenes");
        }
        // Listar videos
        static void ListarVideo()
        {
            // codigo para listar videos
            ListarTablas(_urlVideos, "Videos");
            // mensaje("Listar Videos");
        }
        // Carga las imagenes desde HTTPPOST 
        static void CargarImagen()
        {
            // codigo para caragr imagen
            var res = HttpPost2(_urlImagenes, _Imagenes, "Imagenes");
            Console.WriteLine(res);
            Console.ReadKey();
            //Console.WriteLine("CARGAR IMAGEN");
        }
        // Carga los videos desde HTTPPOST 
        static void CaragrVideo()
        {
            // codigo para caragr videos
            var res = HttpPost2(_urlVideos, _Videos, "Videos");
            Console.WriteLine(res);
            Console.ReadKey();
            // Console.WriteLine("CARGAR Videos");
        }
        // Eliminar imagen
        static void EliminarImagen()
        {
            // codigo para caragr imagen
            Console.WriteLine("CARGAR IMAGEN");
        }
        // eliminar videos
        static void EliminarVideo()
        {
            // codigo para caragr imagen
            Console.WriteLine("CARGAR Videos");
        }
        // jsooooooooonnnnnn
        private static void ListarImagenJson()
        {
            var resu = HttpGet(_urlVideos);

            var resu2 = "{'img': " + resu + "}";

            var json = JObject.Parse(resu2);

            int max = json.Count;

            for (int i = 0; i <= max; i++)
            {
                Console.WriteLine($"ID: {(string)json["img"][i]["Id"]} - Nombre: {(string)json["img"][i]["Nombre"]} - Tamaño: {(string)json["img"][i]["Medida"]}");
            }

            Console.WriteLine("\n" + _lineaDoble + "\n");

            Console.ReadKey();
        }
        #endregion

        static int menu()
        {
            //Console.Clear();
            Bienvenido();
            CrearMenu();
            Console.Write(_MensajeOpcion);
            try
            {
                int valor = Convert.ToInt32(Console.ReadLine());
                return valor;
            }
            catch
            {
                return 0;
            }
        }
        /** Muestra mensaje del programa al usuario */
        static void mensaje(String texto)
        {
            if (texto.Length > 0)
            {
                Console.WriteLine(_MarcoSuperior);
                Console.WriteLine("{0}", texto);
                Console.WriteLine(_MarcoInferior);
                Console.WriteLine(_Continuar);
                Console.ReadKey();
            }
        }
        // Si la tabla no esta vacío la muestra en recuadro
        private static void ListarTablas(string url, string t)
        {
            var resu = HttpGet(url);
            if (resu.Length < 3)
            {
                mensaje(_TablaVacia + t + ".");
            }
            else
            {
                resu = resu.Replace("\"", "");
                resu = resu.Replace("]", "");
                resu = resu.Replace("[", "");
                string[] split = resu.Split(new Char[] { '{', '}' });
                // armo el list
                if (t == "Imagenes")
                {
                    var TextoN = "";
                    var Texto = "\n       * * * I M A G E N E S * * *\n";
                    Texto += "┌─────┬───────────┬─────────────────────┐\n";
                    Texto += "│  ID │  MEDIDA   │       NOMBRE        │\n";
                    Texto += "├─────┼───────────┼─────────────────────┤\n";
                    foreach (string s in split)
                    {
                        if (s.Length > 2)
                        {
                            string[] split2 = s.Split(new char[] { ',' });
                            // FormatoImagen:2
                            foreach (string s2 in split2)
                            {
                                string[] split3 = s2.Split(new char[] { ':' });
                                // Id -  Nombre - Medida
                                if (split3[0] == "Id") Texto += "│ " + split3[1];
                                if (split3[0] == "Nombre") TextoN = split3[1];
                                if (split3[0] == "Medida") Texto += " │ " + split3[1] + " │\t" + TextoN + "\t│\n";
                                // Console.WriteLine("Campo = {0}\t\t Valor = {1}.", split3[0], split3[1]);
                            }
                        }
                    }
                    Texto += "└─────┴───────────┴─────────────────────┘";
                    Console.WriteLine(Texto);
                    Console.ReadKey();
                }
                else
                {
                    var Texto = "\n       * * * V I D E O S * * *\n";
                    Texto += "┌───────────┬───────────────────┐\n";
                    Texto += "│  TAMAÑO   │      RUTA         │\n";
                    Texto += "├───────────┼───────────────────┤\n";
                    foreach (string s in split)
                    {
                        if (s.Length > 2)
                        {
                            string[] split2 = s.Split(new char[] { ',' });
                            // FormatoImagen:2
                            foreach (string s2 in split2)
                            {
                                string[] split3 = s2.Split(new char[] { ':' });
                                if (split3[0] == "Medida") Texto += "│ " + split3[1];
                                if (split3[0] == "Patch") Texto += " │\t" + split3[1] + "\t│\n";
                            }
                        }
                    }
                    Texto += "└───────────┴───────────────────┘";
                    Console.WriteLine(Texto);
                    Console.ReadKey();
                }
            }
        }
        private static void CrearMenu()
        {
            RecorroLoop(_Opciones);
            Console.WriteLine(_MarcoInferior);
        }
        private static void RecorroLoop(string[] arg)
        {
            foreach (string element in arg)
            {
                // recorro el loop
                Console.WriteLine(element);
            }
        }
        private static void Bienvenido()
        {
            Console.WriteLine(_MarcoSuperior);
            Console.WriteLine(_titulo);
            Console.WriteLine(_MarcoMedio);
        }
        // crear contenido en base de datos
        public static string CrearContenido(int[] a)
        {
            foreach (int element in a)
            {
                // recorro el loop
                Console.WriteLine(element);
            }

            return "";
        }
        // envío de los gets
        public static string HttpGet(string URI)
        {
            try
            {
                WebRequest req = WebRequest.Create(URI);
                WebResponse resp = req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                return sr.ReadToEnd(); // .Trim();
            }
            catch (Exception)
            {
                return "Error";
            }
        }
        // envío de los post
        public static string HttpPost2(string u, string[] a, string t)
        {
            string uri = u;  // url del httppost
            var i = 0;

            Console.WriteLine($"Creando listado de: {t}...");

            foreach (string item in a)
            {
                HttpWebRequest request = (HttpWebRequest)
                WebRequest.Create(uri); request.KeepAlive = false;
                request.ProtocolVersion = HttpVersion.Version10;
                request.Method = "POST";

                string post_data = item;  // listado a guardar

                byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
                Stream requestStream = request.GetRequestStream();

                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                // Console.WriteLine(new StreamReader(response.GetResponseStream()).ReadToEnd());
                // Console.WriteLine(response.StatusCode);
                i++;
            }

            return "Se crearon " + i + " Elementos.";
        }
        public static string leerTexto()
        {
            Console.WriteLine("Introduzca un texto");
            String texto;
            texto = Console.ReadLine();
            // Console.WriteLine("El texto introducido es: " + texto);
            return "El texto introducido es: " + texto;
        }
    }

}

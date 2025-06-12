using System;
using Gtk;
using Administrador;
using _usuario;
using _basedeDatos;

namespace Main
{
    public sealed class _principal
    {
        private static _principal? instancia = null;
        private static readonly object candado = new object();
        private _principal()
        {

        }

        private static _principal _Instancia;

        public static _principal GetInstance()
        {
            lock (candado)
                if (_Instancia == null)
                {
                    _Instancia = new _principal();
                }
            return _Instancia;
        }
        public static void Main(string[] args)
        {
            Application.Init();
            Window myWindow = new Window(WindowType.Toplevel);
            myWindow.SetDefaultSize(400, 400);
            myWindow.SetPosition(WindowPosition.Center);
            myWindow.DeleteEvent += (o, e) => Application.Quit();


            Box myBox = new Box(Orientation.Horizontal, 0);

            Gtk.Label userLabel = new Gtk.Label("Ingrese su nombre de usuario");
            Entry _user = new Entry();
            

            myBox.PackStart(userLabel, false, false, 0);
            _principal.GetInstance();


            //DatabaseManager dbManager = new DatabaseManager();


            // dbManager.AddUser("Juan", "Perez", "México", "juan.perez@example.com");
            //dbManager.GetAllUsers();

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
            myWindow.Add(myBox);
            myWindow.ShowAll();
            Application.Run();
        }
        
        }
    }



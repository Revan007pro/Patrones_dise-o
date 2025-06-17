using System;
using Gtk;
using Administrador;
using _usuario;
using _basedeDatos;
using System.Text.RegularExpressions;

namespace Main
{
    public sealed class _principal
    {
        private static _principal? instancia = null;
        private static readonly object candado = new object();

        private _principal() { }

        public static _principal GetInstance()
        {
            lock (candado)
            {
                if (instancia == null)
                {
                    instancia = new _principal();
                }
                return instancia;
            }
        }

        public static void Main(string[] args)
        {
            Application.Init();
            Window myWindow = new Window(WindowType.Toplevel);
            myWindow.SetDefaultSize(400, 400);
            myWindow.SetPosition(WindowPosition.Center);
            myWindow.DeleteEvent += (o, e) => Application.Quit();

            Box myBox = new Box(Orientation.Vertical, 10);

            Gtk.Label userLabel = new Gtk.Label("Ingrese su nombre de usuario");
            Entry _user = new Entry();

            Gtk.Label emailLabel = new Gtk.Label("Ingrese su Email");
            Entry emailEntry = new Entry();

            Gtk.Label passLabel = new Gtk.Label("Ingrese su contraseña");
            Entry passEntry = new Entry();
            passEntry.Visibility = false;  // Oculta caracteres

            Gtk.Label errorLabel = new Gtk.Label("");

            Button _boton1 = new Button("Ingresar");
            _boton1.Clicked += (sender, e) =>
            {
                string usuario = _user.Text;
                string email = emailEntry.Text;
                string contraseña = passEntry.Text;

                if (!Regex.IsMatch(usuario, @"^[a-zA-Z]+$"))
                {
                    errorLabel.Text = "Error: solo letras permitidas en el nombre";
                    return;
                }

                // Aquí podrías usar tu lógica para guardar o consultar en DB
                DataBaseManager dbManager = new DataBaseManager();
                dbManager._dataBase(usuario, email,contraseña); // Esta función necesita revisión también

                // Simula llamada al método del administrador
                var admin = new Administrador.Administrador();
                myWindow.Hide();
                admin.IniciarSeccion();
            };

            myBox.PackStart(userLabel, false, false, 0);
            myBox.PackStart(_user, false, false, 0);
            myBox.PackStart(emailLabel, false, false, 0);
            myBox.PackStart(emailEntry, false, false, 0);
            myBox.PackStart(passLabel, false, false, 0);
            myBox.PackStart(passEntry, false, false, 0);
            myBox.PackStart(errorLabel, false, false, 0);
            myBox.PackStart(_boton1, false, false, 0);

            myWindow.Add(myBox);
            myWindow.ShowAll();
            Application.Run();
        }
    }
}
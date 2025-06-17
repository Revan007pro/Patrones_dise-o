using Gtk;

namespace Administrador
{
    public class Administrador
    {
        public void IniciarSeccion()
        {
            Window adminWindow = new Window("Administrador");
            adminWindow.SetDefaultSize(400, 400);
            adminWindow.SetPosition(WindowPosition.Center);
            adminWindow.DeleteEvent += (o, args) => adminWindow.Hide(); // No cerrar toda la app

            Box myBox = new Box(Orientation.Vertical, 10);

            Label myLabel = new Label("Ingrese su nombre de usuario");
            Entry userEntry = new Entry();

            Label myLabel2 = new Label("Ingrese su número de identificación");
            Entry idEntry = new Entry();

            myBox.PackStart(myLabel, false, false, 0);
            myBox.PackStart(userEntry, false, false, 0);
            myBox.PackStart(myLabel2, false, false, 0);
            myBox.PackStart(idEntry, false, false, 0);

            adminWindow.Add(myBox);
            adminWindow.ShowAll();
        }
    }
}

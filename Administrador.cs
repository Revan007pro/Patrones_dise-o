using System;
using Gtk;

namespace Administrador
{
    public class Administrador1()
    {
        void _Iniciarseccion()
        {
            Application.Init();
            Window myWindow = new Window(WindowType.Toplevel);
            myWindow.SetDefaultSize(400, 400);
            myWindow.SetPosition(WindowPosition.Center);
            Box myBox = new Box(Orientation.Horizontal,0);
            Label myLabel = new Label("Ingrese su nombre de usuario");
            myBox.PackStart(myLabel, false, false, 0);
            Label myLabel2 = new Label("ingrese su numero de identificacion");
            myWindow.Add(myBox);
            myWindow.ShowAll();
        }
    }

}
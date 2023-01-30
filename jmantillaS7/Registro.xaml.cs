using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jmantillaS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var datosRegistro = new Estudiante { Nombre = Nombre.Text, Usuario = Usuario.Text, Contrasena = Contra.Text };
            _conn.InsertAsync(datosRegistro);
            limpiarFormulario();

        }

        void limpiarFormulario()
        {
            Nombre.Text = "";
            Usuario.Text = "";
            Contra.Text = "";
            DisplayAlert("Alerta", "Se agregó correctamente", "Ok");
            Navigation.PushAsync(new Login());
        }
    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jmantillaS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public SQLiteAsyncConnection _conn;
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnnection();

        }
        public IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<Estudiante>("Select * from Estudiante where Usuario = ? and Contrasena = ? ", usuario, contra);
        }
        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(dataPath);

                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique credenciales", "Ok");
                }
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }
    }
}
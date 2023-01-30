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
    public partial class Elemento: ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection conn;
        IEnumerable<Estudiante> resulDelete;
        IEnumerable<Estudiante> resulUpdate;
        public Elemento(int id)
        {
            InitializeComponent();
            conn = DependencyService.Get<Database>().GetConnnection();
            IdSeleccionado = id;
        }
        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Estudiante>("DELETE FROM estudiante where id = ?", id);
        }

        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string nombre, string usuario, string password, int id)
        {
            return db.Query<Estudiante>("UPDATE estudiante SET nombre = ?, usuario = ?, " +
                "password = ? where id = ?", nombre, usuario, password, id);
        }

        private void btnactualiza_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                resulUpdate = Update(db, lblnombre.Text, lblusuario.Text, lblpassword.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se Actualizo Correctamete", "cerrar");
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }

        private void btnelimina_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                resulDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se Elimino Correctamete", "cerrar");
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}
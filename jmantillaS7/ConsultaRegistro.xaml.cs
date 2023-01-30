using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jmantillaS7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<Estudiante> tableEstudiante;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<Database>().GetConnnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resulRegistros = await conn.Table<Estudiante>().ToListAsync();
            tableEstudiante = new ObservableCollection<Estudiante>(resulRegistros);
            ListaUsuarios.ItemsSource = tableEstudiante;
            base.OnAppearing();
        }

        void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Estudiante)e.SelectedItem;
            var item = obj.Id.ToString();
            int Id = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new Elemento(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
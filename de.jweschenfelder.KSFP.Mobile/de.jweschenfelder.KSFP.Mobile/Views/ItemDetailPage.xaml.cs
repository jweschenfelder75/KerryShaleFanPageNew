using de.jweschenfelder.KSFP.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace de.jweschenfelder.KSFP.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
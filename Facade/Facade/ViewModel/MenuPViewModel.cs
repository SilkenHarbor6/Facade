using Android.Widget;
using GalaSoft.MvvmLight.Command;
using Facade.Model;
using Facade.Pattern;
using Facade.Service;
using Facade.View;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Facade.ViewModel
{
    public class MenuPViewModel
    {
        #region Propiedades
        private Persona _persona;
        DialogService _dialogService;
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(Eliminar);
            }
        }
        public ICommand Update
        {
            get
            {
                return new RelayCommand(Actualizar);
            }
        }
        #endregion
        #region Constructor
        public MenuPViewModel(Persona item)
        {
            _persona = item;
            _dialogService = new DialogService();
        }
        #endregion
        #region Metodos
        public async void Eliminar()
        {
            if (await _dialogService.Message("Confirmacion", "¿Desea eliminar este registro?", "Aceptar", "Cancelar"))
            {
                if (SingletonRepository.Instancia.Repository.PersonOperation(_persona,Pattern.Facade.Operacion.Delete))
                {
                    await PopupNavigation.PopAllAsync();
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
            else
            {
                Toast.MakeText(Android.App.Application.Context,"Operacion Cancelada",ToastLength.Long).Show();
            }
        }
        public async void Actualizar()
        {
            await PopupNavigation.PopAsync();
            await PopupNavigation.PushAsync(new EditPage(_persona));
        }
        #endregion
    }
}

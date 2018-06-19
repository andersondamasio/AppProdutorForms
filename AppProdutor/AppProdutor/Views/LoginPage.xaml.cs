using AppProdutor.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProdutor.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();

         
        }

        bool AutenticarUsuario(UsuarioDto usuarioDto)
        {
            return usuarioDto.us_login == "datacoper" && usuarioDto.us_senha == "123";
        }

        private async Task Button_EntrarClicked(object sender, EventArgs e)
        {
            var usuarioDto = new UsuarioDto
            {
                us_login = entryUsuario.Text,
                us_senha = entrySenha.Text
            };

            var isValid = AutenticarUsuario(usuarioDto);
            if (isValid)
            {
                //App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                labelMensagem.Text = "Usuário ou Senha inválidos";
                entrySenha.Text = string.Empty;
            }
        }

        private void ToolbarItem_SairClicked(object sender, EventArgs e)
        {

        }
    }
}
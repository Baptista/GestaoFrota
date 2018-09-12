using Core_Gestao_Frotas.Business.Interfaces;
using Core_Gestao_Frotas.Business.Login;
using Core_Gestao_Frotas.Business.Models;
using Core_Gestao_Frotas.Persistence;
using System;

using UIKit;

namespace iOS_GestaoFrotas
{
    public partial class ViewController : UIViewController
    {

        private IBusinessLogin _businessLogin;
        User utilizador;
        //CodeDB DB = new CodeDB();
        public ViewController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _businessLogin = new BusinessLogin();
            PCircle.Hidden = true;
            txtPassword.SecureTextEntry = true;
            //DB.LoadDB();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void BttLogin_TouchUpInside(UIButton sender)
        {
            var user = txtUser.Text;
            var password = txtPassword.Text;
            Verificarlogin(user, password);
        }

        public async void Verificarlogin(string user, string password)
        {
            if (user != "" && password != "")
            {
                BttLogin.Hidden = true;
                PCircle.Hidden = false;
                PCircle.StartAnimating();
                var result = await _businessLogin.Login(user, password);
                if (result != "no")
                {
                    utilizador = await _businessLogin.LoginUtilizador(result);
                    if (!utilizador.Active)
                    {


                        var errorAlertController = UIAlertController.Create("Erro", "Este Utilizador Não esta Activo!", UIAlertControllerStyle.Alert);
                        errorAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Okay was clicked")));
                        PresentViewController(errorAlertController, true, null);
                    }
                    else
                    {
                        var successAlertController = UIAlertController.Create("Sucesso!", "Logado!", UIAlertControllerStyle.Alert);
                        successAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Okay was clicked")));
                        PresentViewController(successAlertController, true, null);
                    }
                }
                else
                {
                    var errorrAlertController = UIAlertController.Create("Erro", "Utilizador ou password errada!", UIAlertControllerStyle.Alert);
                    errorrAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Okay was clicked")));
                    PresentViewController(errorrAlertController, true, null);
                }
                BttLogin.Hidden = false;
                PCircle.Hidden = true;
                PCircle.StopAnimating();
            }
            else
            {
                var errorrrAlertController = UIAlertController.Create("Erro", "Campos Não Preenchidos!", UIAlertControllerStyle.Alert);
                errorrrAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Okay was clicked")));
                PresentViewController(errorrrAlertController, true, null);
            }
        }



    }
}
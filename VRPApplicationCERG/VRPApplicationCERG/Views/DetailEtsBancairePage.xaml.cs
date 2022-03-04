using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VRPApplicationCERG.ViewModels.ETS_BANCAIRE_VIEWMODEL;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VRPApplicationCERG.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailEtsBancairePage : ContentPage
    {
        public DetailEtsBancairePage()
        {
            InitializeComponent();

            BindingContext = new EtsBancaireViewModelDetail();
            payscodeChamps.Text = string.Empty;
            BanquenomChamps.Text = string.Empty;
            BanquecodeChamps.Text = string.Empty;
            BanquesigleChamps.Text = string.Empty;
            BanquedatesuspChamps.Text = string.Empty;
            BanqueclebceaoChamps.Text = string.Empty;
            BanquecoderemtChamps.Text = string.Empty;
            codeformuleChamps.Text = string.Empty;
            BanquesdevmtChamps.Text = string.Empty;
            BanquebfChamps.Text = string.Empty;
            BanqueetcivChamps.Text = string.Empty;
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonPayscode(object sender, EventArgs e)
        {
            payscode.IsVisible = !payscode.IsVisible;

            if (payscode.IsVisible == true)
            {
                payscodeImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                payscodeImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquecode(object sender, EventArgs e)
        {
            banquecode.IsVisible = !banquecode.IsVisible;

            if (banquecode.IsVisible == true)
            {
                banquecodeImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                banquecodeImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquenom(object sender, EventArgs e)
        {
            banquenom.IsVisible = !banquenom.IsVisible;

            if (banquenom.IsVisible == true)
            {
                banquenomImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                banquenomImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquensigle(object sender, EventArgs e)
        {
            banquesigle.IsVisible = !banquesigle.IsVisible;

            if (banquesigle.IsVisible == true)
            {
                banquesigleImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                banquesigleImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquendatesusp(object sender, EventArgs e)
        {
            banquedatesusp.IsVisible = !banquedatesusp.IsVisible;

            if (banquedatesusp.IsVisible == true)
            {
                banquedatesuspImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                banquedatesuspImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }

        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanqueclebceao(object sender, EventArgs e)
        {
            banqueclebceao.IsVisible = !banqueclebceao.IsVisible;

            if (banqueclebceao.IsVisible == true)
            {
                banqueclebceaoImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                banqueclebceaoImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquecoderemet(object sender, EventArgs e)
        {
            Banquecoderemet.IsVisible = !Banquecoderemet.IsVisible;

            if (Banquecoderemet.IsVisible == true)
            {
                BanquecoderemetImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                BanquecoderemetImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }

        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquecodeformule(object sender, EventArgs e)
        {
            codeformule.IsVisible = !codeformule.IsVisible;

            if (codeformule.IsVisible == true)
            {
                codeformuleImageButton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                codeformuleImageButton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquesdevmt(object sender, EventArgs e)
        {
            Banquesdevmt.IsVisible = !Banquesdevmt.IsVisible;

            if (Banquesdevmt.IsVisible == true)
            {
                BanquesdevmtImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                BanquesdevmtImagebutton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }


        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanquebf(object sender, EventArgs e)
        {
            Banquebf.IsVisible = !Banquebf.IsVisible;

            if (Banquebf.IsVisible == true)
            {
                BanquebfImageButton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                BanquebfImageButton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }



        /// <summary>
        /// fonction de visibilite sur les champs de saisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickSurImageButtonBanqueetciv(object sender, EventArgs e)
        {
            Banqueetciv.IsVisible = !Banqueetciv.IsVisible;

            if (Banqueetciv.IsVisible == true)
            {
                BanqueetcivImageButton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8collapsearrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
            else
            {
                BanqueetcivImageButton.Source = ImageSource.FromResource("VRPApplicationCERG.Images.icons8expandarrow48.png", typeof(DetailEtsBancairePage).GetTypeInfo().Assembly);
            }
        }

    }

}
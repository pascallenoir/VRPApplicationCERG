using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using VRPApplicationCERG.Models;
using VRPApplicationCERG.ViewModels.FRAMEWORKMVVM;
using Xamarin.Forms;

namespace VRPApplicationCERG.ViewModels
{
    public class ConferenceViewModelPage : BaseViewModel
    {
        public Command NouvelReunion { get; }
        public Command RejoindreReunion { get; }

        readonly IList<ImageInformative> source;
        public ObservableCollection<ImageInformative> Infos { get; private set; }

        public ConferenceViewModelPage()
        {
            Title = "Conference";


            source = new List<ImageInformative>();
            CreateMonkeyCollection();

            NouvelReunion = new Command(LancerNouvelleReunion);
            RejoindreReunion = new Command(RejoindreReunionEnCours);
        }


        /// <summary>
        /// Creation des elements du carouselView
        /// </summary>
        void CreateMonkeyCollection()
        {

            source.Add(new ImageInformative
            {
                Image = ImageSource.FromResource("VRPApplicationCERG.Images.Meetingamico.png", typeof(ConferenceViewModelPage).GetTypeInfo().Assembly),
                Titre = "Essayer la reunion en ligne",
                Detail = "Planifiez des réunions en ligne avec vos correspondants peu importe le lieu, le temps ou les circonstances"
            });

            source.Add(new ImageInformative
            {
                Image = ImageSource.FromResource("VRPApplicationCERG.Images.Groupvideoamico.png", typeof(ConferenceViewModelPage).GetTypeInfo().Assembly),
                Titre = "Obtenir un lien de partage",
                Detail = "Appuyez sur Nouvelle réunion pour obtenir le lien à envoyer aux personnes que vous souhaitez inviter à une réunion"
            });

            source.Add(new ImageInformative
            {
                Image = ImageSource.FromResource("VRPApplicationCERG.Images.Groupvideopana.png", typeof(ConferenceViewModelPage).GetTypeInfo().Assembly),
                Titre = "Rejoindre une réunion",
                Detail = "Personne ne peut rejoindre une réunion sans y avoir été invité par l'organisateur"
            });

            Infos = new ObservableCollection<ImageInformative>(source);

        }



        private void RejoindreReunionEnCours(object obj)
        {
            throw new NotImplementedException();
        }

        private void LancerNouvelleReunion(object obj)
        {
            throw new NotImplementedException();
        }
    }
}

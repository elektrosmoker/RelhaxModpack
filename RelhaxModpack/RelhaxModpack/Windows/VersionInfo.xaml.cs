﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;

namespace RelhaxModpack.Windows
{
    /// <summary>
    /// Interaction logic for VersionInfo.xaml
    /// </summary>
    public partial class VersionInfo : RelhaxWindow
    {
        public bool ConfirmUpdate { get; private set; } = false;

        public VersionInfo()
        {
            InitializeComponent();
        }



        private void OnHyperlinkClick(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            //https://stackoverflow.com/questions/10238694/example-using-hyperlink-in-wpf
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void OnYesButtonClick(object sender, RoutedEventArgs e)
        {
            ConfirmUpdate = true;
            Close();
        }

        private void OnNoButtonClick(object sender, RoutedEventArgs e)
        {
            ConfirmUpdate = false;
            Close();
        }

        private void RelhaxWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //update the textbox with the latest version
            ApplicationUpdateNotes.Text = Translations.GetTranslatedString("loadingApplicationUpdateNotes");
            using (WebClient client = new WebClient())
            {
                Uri temp = new Uri((ModpackSettings.ApplicationDistroVersion == ApplicationVersions.Stable) ?
                    Settings.ApplicationNotesStableUrl : Settings.ApplicationNotesBetaUrl);
                client.DownloadStringCompleted += (senderr, args) => { ApplicationUpdateNotes.Text = args.Result; };
                client.DownloadStringAsync(temp);
            }
        }
    }
}

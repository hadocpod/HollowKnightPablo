using Microsoft.UI;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.WindowManagement;
using WinRT.Interop;
using AppWindow = Microsoft.UI.Windowing.AppWindow;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AppPablo
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer;
        private MicaBackdrop micaBackdrop;
        private AppWindow appWindow;
        public MainWindow()
        {
            InitializeComponent();
            this.AppWindow.Resize(new Windows.Graphics.SizeInt32(400, 400));
            TrySetMicaBackdrop();
            ExtenderTituloWin11();
            mediaPlayer = new MediaPlayer();
        }
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            var filePath = "ms-appx:///Assets/pablo.mp3";
            mediaPlayer.Source = MediaSource.CreateFromUri(new System.Uri(filePath));
            mediaPlayer.Play();
        }
        private void TrySetMicaBackdrop()
        {
            micaBackdrop = new MicaBackdrop();

            if (micaBackdrop != null && this.SystemBackdrop == null)
            {
                this.SystemBackdrop = micaBackdrop;
            }
        }
        private void ExtenderTituloWin11()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            appWindow = AppWindow.GetFromWindowId(windowId);
            // Extiende el contenido al área de título
            var titleBar = appWindow.TitleBar;
            titleBar.ExtendsContentIntoTitleBar = true;

            // Hacemos botones (minimizar, cerrar, etc.) transparentes para que combinen con Mica
            titleBar.ButtonBackgroundColor = Microsoft.UI.Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Microsoft.UI.Colors.Transparent;
        }
    }
}

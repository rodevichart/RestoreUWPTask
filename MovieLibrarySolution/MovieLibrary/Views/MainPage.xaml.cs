﻿using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MovieLibrary.ViewModels;
using MovieLibrary.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MovieLibrary.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage
	{
		public MainPageViewModel MainPageViewModel { get; set; }

		public MainPage()
		{
			this.InitializeComponent();
			MainPageViewModel = DataContext as MainPageViewModel;

			//FilmCollection.NavigationService.Navigate(typeof(MovieCollection));
			MainFrame.Navigate(typeof(MovieCollection));
			IconsListBox.SelectedIndex = 0;
			RelativePnlTitle.Text = Share.Text;

			MainFrame.Navigated += OnNavigated;

				// Register a handler for BackRequested events and set the
				// visibility of the Back button
				SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
				SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
					MainFrame.CanGoBack ?
					AppViewBackButtonVisibility.Visible :
					AppViewBackButtonVisibility.Collapsed;
			
			//SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
		}

		private void OnBackRequested(object sender, BackRequestedEventArgs e)
		{
	
			if (MainFrame.CanGoBack)
			{
				e.Handled = true;
				MainFrame.GoBack();
			}
		}

		private void HamburgerButton_OnClick(object sender, RoutedEventArgs e)
		{
			SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
		}


		private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var sendFrom = sender as ListBox;

			if(sendFrom.Name == "IconsListBox")
			{
				BottomIconsListBox.SelectionChanged -= IconsListBox_SelectionChanged;
				BottomIconsListBox.SelectedIndex = -1;

				if (MenuButton1.IsSelected)
				{
					MainPageViewModel.NavigationService.GoToSearchMovieByDirectorPage();
					//MainFrame.Navigate(typeof(MovieCollection));
					RelativePnlTitle.Text = Share.Text;
				}
				else if (MenuButton2.IsSelected)
				{
					MainFrame.Navigate(typeof(SearchMovieByDirector));
					RelativePnlTitle.Text = Movie.Text;
				}
				else if (MenuButton3.IsSelected)
				{
					MainFrame.Navigate(typeof(MovieDetails));
					RelativePnlTitle.Text = Cortana.Text;
				}
				BottomIconsListBox.SelectionChanged += IconsListBox_SelectionChanged;
			}
			else
			{
				IconsListBox.SelectionChanged -= IconsListBox_SelectionChanged;
				IconsListBox.SelectedIndex = -1;

				if (SettingsBtn.IsSelected)
				{
					MainFrame.Navigate(typeof(MovieDetails));
					RelativePnlTitle.Text = Settings.Text;
				}
				else if (SignInBtn.IsSelected)
				{
					MainFrame.Navigate(typeof(MovieDetails));
					RelativePnlTitle.Text = SignIn.Text;
				}
				IconsListBox.SelectionChanged += IconsListBox_SelectionChanged;
			}

			
			
		}


		private void OnNavigated(object sender, NavigationEventArgs e)
		{
			SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
				((Frame)sender).CanGoBack ?
				AppViewBackButtonVisibility.Visible :
				AppViewBackButtonVisibility.Collapsed;
		}

	}

}

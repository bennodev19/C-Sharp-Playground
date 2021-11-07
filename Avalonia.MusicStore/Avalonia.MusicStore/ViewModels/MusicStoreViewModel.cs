using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.MusicStore.Models;
using ReactiveUI;

namespace Avalonia.MusicStore.ViewModels
{
    public class MusicStoreViewModel : ViewModelBase
    {
        private bool _isBusy;
        private string? _searchText;
        private AlbumViewModel? _selectedAlbum;
        
        public string? SearchText
        {
            get => _searchText;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the SearchText changes due to it is called in the setter method.
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }
        
        public bool IsBusy
        {
            get => _isBusy;
            set => this.RaiseAndSetIfChanged(ref _isBusy, value);
        }

        public ObservableCollection<AlbumViewModel> SearchResults { get; } = new();
        public AlbumViewModel? SelectedAlbum
        {
            get => _selectedAlbum;
            set => this.RaiseAndSetIfChanged(ref _selectedAlbum, value);
        }
        
        public ReactiveCommand<Unit, AlbumViewModel?> BuyMusicCommand { get; }
        
        public MusicStoreViewModel()
        {
            // 'BuyMusicCommand' button callback
            BuyMusicCommand = ReactiveCommand.Create(() =>
            {
                return SelectedAlbum;
            });
            
            // Query albums
            this.WhenAnyValue(x => x.SearchText)
                .Throttle(TimeSpan.FromMilliseconds(400)) // to not query on every key stroke.. query the results if the user stopped typing for 400ms
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(DoSearch!);
        }

        private CancellationTokenSource? _cancellationTokenSource;
        
        private async void DoSearch(string s)
        {
                        
            IsBusy = true;
            SearchResults.Clear();
            
            // If existing request still loading, cancel the loading request
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;
            
            if (!string.IsNullOrWhiteSpace(s))
            {
                var albums = await Album.SearchAsync(s);
                foreach (var album in albums)
                {
                    var vm = new AlbumViewModel(album);
                    SearchResults.Add(vm);
                }
                
                if (!cancellationToken.IsCancellationRequested)
                {
                    LoadCovers(cancellationToken);
                }
            }
            IsBusy = false;
        }
        
        private async void LoadCovers(CancellationToken cancellationToken)
        {
            foreach (var album in SearchResults.ToList())
            {
                await album.LoadCover();
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
            }
        }
    }
}
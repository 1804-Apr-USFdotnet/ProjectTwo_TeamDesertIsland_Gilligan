import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
import { FormsModule, NgForm } from '@angular/forms';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

  @Component({
      templateUrl: './addsong.component.html'
  })

  export class AddSongComponent {
        public client: HttpClient;
        public albums: AlbumViewModel[];
        public artists: ArtistViewModel[];
        public songs: SongViewModel[];
        public baseUrlAlbum: string;
        public baseUrlArtist: string;
        public baseUrlSong: string;

        constructor(http: HttpClient) {
            this.client = http;
            this.baseUrlAlbum = 'http://localhost:55562/api/inventory/album';
            this.baseUrlArtist = 'http://localhost:55562/api/inventory/artist';
            this.baseUrlSong = 'http://localhost:55562/api/inventory/song';

            this.Start();
        }

        public Start() {
            this.client.get(this.baseUrlAlbum).subscribe(result => {
                this.albums = result as AlbumViewModel[];
            });

            this.client.get(this.baseUrlArtist).subscribe(result => {
                this.artists = result as ArtistViewModel[];
            });

            this.client.get(this.baseUrlSong).subscribe(result => {
                this.songs = result as SongViewModel[];
            });
        }

        public onSubmit(f: NgForm) {
                const artistIds: string[] = [];

                const name = f.form.value.songName;
                const albumId = f.form.value.songAlbumId;
                artistIds.push(f.form.value.songArtistOne);

                if (f.form.value.songArtistTwo !== '') {
                    artistIds.push(f.form.value.songArtistTwo);
                }

                if (f.form.value.songArtistThree !== '') {
                    artistIds.push(f.form.value.songArtistThree);
                }

                const viewModel = new AddSongViewModel(name, albumId, artistIds);

                console.log(viewModel);

                this.client.post<AddSongViewModel>(this.baseUrlSong, viewModel, httpOptions).subscribe();
        }
  }


  class AddSongViewModel {
        Name: string;
        ArtistIds: string[];
        AlbumId: string;

        constructor(name: string, albumId: string, artistIds: string[]) {
            this.Name = name;
            this.AlbumId = albumId;
            this.ArtistIds = artistIds;
        }
  }

  interface SongViewModel {
        SongId: string;
        Name: string;
        IsAttached: boolean;
        AverageRating: number;
  }

  interface ArtistViewModel {
        ArtistId: string;
        Name: string;
}

interface AlbumViewModel {
        AlbumId: string;
        Name: string;
        ReleaseDate: Date;
}

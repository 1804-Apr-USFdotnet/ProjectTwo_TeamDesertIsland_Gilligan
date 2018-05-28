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
      templateUrl: './addartist.component.html'
  })

  export class AddArtistComponent {
        public client: HttpClient;
        public baseUrlGenre: string;
        public baseUrlArtist: string;
        public genres: GenreViewModel[];
        public artists: ArtistViewModel[];

        constructor(http: HttpClient) {
            this.client = http;
            this.baseUrlGenre = 'http://23.101.154.131/api/inventory/genre';
            this.baseUrlArtist = 'http://23.101.154.131/api/inventory/artist';

            this.Start();
        }

        public Start() {
            this.client.get(this.baseUrlGenre).subscribe(result => {
                this.genres = result as GenreViewModel[];
            });

            this.client.get(this.baseUrlArtist).subscribe(result => {
                this.artists = result as ArtistViewModel[];
            });
        }

        public onSubmit(f: NgForm) {
            const genreIds: string[] = [];

            console.log(f.value);

            genreIds.push(f.value.artistGenreOne);

            if (f.form.value.artistGenreTwo !== '') {
                genreIds.push(f.form.value.artistGenreTwo);
            }

            if (f.form.value.artistGenreThree !== '') {
                genreIds.push(f.form.value.artistGenreThree);
            }

            const viewModel = new AddArtistViewModel(f.form.value.artistName, genreIds);

            console.log(viewModel);

            this.client.post<AddArtistViewModel>(this.baseUrlArtist, viewModel, httpOptions).subscribe();
        }
  }

  class AddArtistViewModel {
        Name: string;
        GenreIds: string[];

        constructor(name: string, genreIds: string[]) {
            this.Name = name;
            this.GenreIds = genreIds;
        }
  }

  interface ArtistViewModel {
        ArtistId: string;
        Name: string;
  }

  interface GenreViewModel {
        GenreId: string;
        Name: string;
  }


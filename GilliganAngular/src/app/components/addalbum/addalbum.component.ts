import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
import { FormsModule } from '@angular/forms';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };

@Component({
    templateUrl: './addalbum.component.html'
})

export class AddAlbumComponent {
    public client: HttpClient;
    public baseUrl: string;
    public albums: AlbumViewModel[];
    public albumName: string;
    public releaseDate: Date;

    constructor(http: HttpClient) {
        this.client = http;
        this.baseUrl = 'http://localhost:55562/api/inventory/album';
        this.Start();
    }

    public Start() {
        this.client.get(this.baseUrl).subscribe(result => {
            this.albums = result as AlbumViewModel[];
        });
    }


    public AddAlbum() {
        const viewModel = new AddAlbumViewModel(this.albumName, this.releaseDate);
        this.client.post<AddAlbumViewModel>(this.baseUrl, viewModel, httpOptions).subscribe();
    }
}


class AddAlbumViewModel {
    public Name: string;
    public releaseDate: Date;

    constructor(name: string, date: Date) {
        this.Name = name;
        this.releaseDate = date;
    }
}

interface AlbumViewModel {
    AlbumId: string;
    ReleaseDate: Date;
    Name: string;
}

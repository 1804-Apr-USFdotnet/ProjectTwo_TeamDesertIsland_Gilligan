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
    selector: 'app-addgenre',
    templateUrl: './addgenre.component.html'
})

export class AddGenreComponent {
    private client: HttpClient;
    private baseUrl: string;
    public genres: GenreViewModel[];
    public genreName: string;

    constructor(http: HttpClient) {
        this.client = http;
        this.baseUrl = 'http://localhost:55562/api/inventory/genre';
        this.Start();
    }

    public Start() {
        this.client.get(this.baseUrl).subscribe(result => {
            this.genres = result as GenreViewModel[];
        });
    }


    public AddGenre() {
        const viewModel = new AddGenreViewModel(this.genreName);
        this.client.post<AddGenreViewModel>(this.baseUrl, viewModel, httpOptions).subscribe();
    }
}

class AddGenreViewModel {
    public Name: string;

    constructor(name: string) {
        this.Name = name;
    }
}

interface GenreViewModel {
    GenreId: string;
    Name: string;
}

// class GenreViewModel {
//     public GenreId: string;
//     public Name: string;

//     constructor(genreid: string, name: string) {
//         this.GenreId = genreid;
//         this.Name = name;
//     }
// }

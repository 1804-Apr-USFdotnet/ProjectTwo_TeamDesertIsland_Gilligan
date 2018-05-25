import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'app-addgenre',
    templateUrl: './addgenre.component.html'
})

export class AddGenreComponent {
    private client: Http;
    private baseUrl: string;
    private addGenreUrl: string;

    constructor(http: Http) {
        this.client = http;
        this.baseUrl = 'http://localhost:55562/api/';
        this.addGenreUrl = 'inventory/genre';
    }

    AddGenre(viewModel: AddGenreViewModel) {
        this.client.post(this.baseUrl + this.addGenreUrl, viewModel);
    }
}

interface AddGenreViewModel {
    Name: string;
}

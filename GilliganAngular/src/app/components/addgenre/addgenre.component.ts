import { Component } from "@angular/core";
import { Http } from "@angular/http";

@Component({
    selector: 'addgenre',
    templateUrl: './addgenre.component.html'
})

export class AddGenreComponent{
    private client : Http;
    private baseUrl : string;

    constructor(http : Http){
        this.client = http;
        this.baseUrl = "http://localhost:8080/api";
    }

    AddGenre(viewModel : AddGenreViewModel){
        this.client.post(this.baseUrl, viewModel);
    }
}

interface AddGenreViewModel{
    Name : string;
}

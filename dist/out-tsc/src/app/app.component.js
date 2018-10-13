"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
//import { Headers, RequestOptions } from '@angular/http';
//import { HttpHeaders } from '@angular/common/http';
var http_1 = require("@angular/common/http");
var AppComponent = /** @class */ (function () {
    function AppComponent(http) {
        var _this = this;
        this.http = http;
        this.title = 'app';
        this.http.get('/api/Account').subscribe(function (result) {
            _this.values = result;
        }, function (error) { return console.error(error); });
        //this.http.post<string>('/api/Account', { "value": "Ramakant" }).subscribe(result => {
        //  this.postRes = result.json();
        //});
    }
    AppComponent.prototype.create = function () {
        var _this = this;
        debugger;
        var body = {
            value: "Ramakant"
        };
        return this.http.post('/api/Account', body).subscribe(function (result) {
            _this.postRes = result;
        }, function (error) { return console.error(error); });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'app-root',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css']
        })
        //const httpOptions = {
        //  headers: new HttpHeaders({
        //    'Content-Type': 'application/json',
        //    'Authorization': 'my-auth-token'
        //  })
        //};
        ,
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map
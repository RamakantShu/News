import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import {Observable} from 'rxjs';
//import { Property1 } from '../model/Property';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpc:HttpClient) { 

  }

  public getdata():Observable<any[]>
  {
    var url= "http://localhost:57348/api/admin/PropertyDDL/NewsCategory";
      return this.httpc.get<any[]>(url);
  }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpRequest, HttpEventType} from '@angular/common/http';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import {DpDatePickerModule} from 'ng2-date-picker';
//import { NgDatepickerModule } from 'ng2-datepicker';
// import { Observable } from 'rxjs';
// import { debug } from 'util';

import {AdminService} from '../services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {
  angForm: FormGroup;
  title="";
  title2="";
  title3="";
  title4="";
  secquence="";
  newsContent="";
  category="";
  newsDate="";
  newsReportedBy="";
  comment="";
  contentLinks="";

  newsProfileImage:string [] = [];
  contentImages:string [] = [];
  contentVideos:string [] = [];
  public categoryList:Array<any>=[];
  public show:boolean;
  public showasync:boolean;

  public progress: number;
  public message: string;

  constructor(
    private router: Router, 
    private fb: FormBuilder,
    private http:HttpClient,
    private adminService:AdminService,
    private adminDateTimePicker:DpDatePickerModule
  ) 
  { 
    this.angForm=this.fb.group({
      title:['', Validators.required],
      title2:['', Validators.required],
      title3:['',''],
      title4:['',''],
      secquence:['',''],
      category:['',Validators.required],
      newsDate:['',Validators.required],
      newsReportedBy:['',Validators.required],
      comment:['',''],
      contentLinks:['',''],
      newsContent:['', Validators.required],
      contentImages:['',''],
      contentVideos:['',''],
      newsProfileImage:['', Validators.required]
    });

  }

  ngOnInit() {
    this.adminService.getdata().subscribe(result=>{
      this.categoryList=result;
       this.show=true;
        this.showasync=false;
    })
  }

  onImageSelected(e, imageFor) {
    if(imageFor == 'NewProfileImage')
    {
      for (var i = 0; i < e.target.files.length; i++) { 
        this.newsProfileImage.push(e.target.files[i]);
      }
    }
    else if(imageFor == 'ContentImage')
    {
      for (var i = 0; i < e.target.files.length; i++) { 
        this.contentImages.push(e.target.files[i]);
      }
    }
    else if(imageFor == 'ContentVideo')
    {
      for (var i = 0; i < e.target.files.length; i++) { 
        this.contentVideos.push(e.target.files[i]);
      }
    }
}

  SaveNewsContent(e)
  {
    debugger;
      const formData = new FormData();

      for (var i = 0; i < this.newsProfileImage.length; i++) { 
        formData.append("NewsProfileImage", this.newsProfileImage[i]);
      }

      for (var i = 0; i < this.contentImages.length; i++) { 
        formData.append("ContentImages", this.contentImages[i]);
      }

      for (var i = 0; i < this.contentVideos.length; i++) { 
        formData.append("ContentVideos", this.contentVideos[i]);
      }
      
      formData.append("title", this.title);      
      formData.append("title2", this.title2);
      formData.append("title3", this.title3);
      formData.append("title4", this.title4);
      formData.append("secquence", this.secquence);
      formData.append("category", this.category);
      formData.append("newsDate", this.newsDate);
      formData.append("newsReportedBy", this.newsReportedBy);
      formData.append("comment", this.comment);
      formData.append("contentLinks", this.contentLinks);
      formData.append("newsContent", this.newsContent);
  
      const uploadReq = new HttpRequest('POST', 'api/admin', formData, {
        reportProgress: true,
      });
  
      this.http.request(uploadReq).subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded / event.total);
        else if (event.type === HttpEventType.Response)
          this.message = event.body.toString();
      });    
  }

  //Text editor code
  editorConfig: AngularEditorConfig = {
    editable: true,
    spellcheck: true,
    height: '25rem',
    minHeight: '5rem',
    placeholder: 'Enter text here...',
    translate: 'no',
    uploadUrl: 'v1/images', // if needed
    customClasses: [ // optional
      {
        name: "quote",
        class: "quote",
      },
      {
        name: 'redText',
        class: 'redText'
      },
      {
        name: "titleText",
        class: "titleText",
        tag: "h1",
      },
    ]
  };
}

using System;
using System.IO;

namespace webapi.ViewModel
{
    public class PropertyModel
    {
        public int id{get;set;}
        public int parent_id{get;set;}
        public string code {get;set;}
        public string name {get;set;}
        public string comment {get;set;}
        public bool is_active {get;set;}
        public int created_by {get;set;}   
        public string created_by_name {get;set;}
        public string created_on {get;set;}       
    }
}
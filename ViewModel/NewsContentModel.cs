using System.IO;

namespace webapi.ViewModel
{
    public class NewsContentModels
    {
        public int id{get;set;}
        public string title {get;set;}
        public string title2 {get;set;}
        public string title3 {get;set;}
        public string title4 {get;set;}
        public string secquence {get;set;}
        public string category {get;set;}
        public string newsDate {get;set;}
        public string newsReportedBy {get;set;}
        public string comment {get;set;}
        public string contentLinks {get;set;}
        public string newsContent {get;set;}
        public byte[] newsProfileImage {get;set;}
        public byte[] contentImages {get;set;}
        public byte[] contentVideos {get;set;}
    }
}

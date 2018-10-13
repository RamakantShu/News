using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Microsoft.AspNetCore.Http;
using webapi.IRepository;
using webapi.ViewModel;
using DL.DbClients;
using Microsoft.Extensions.Configuration;

namespace webapi.Repository
{
    public class AdminRepository : IAdminRepository
	{
        IConfiguration _configuration;
        public AdminRepository(IConfiguration configuration)    
        {
            this._configuration = configuration;
        }
        #region Public Methods
        public async Task<int> SaveNewsContent(NewsContentModels mdl, IFormFileCollection files=null)
        {
            int result=0;      

            var data=DbClientFactory<PropertyDbClient>.Instance.GetAllProperty(_configuration["ConnectionStrings:DefaultConnection"]);

            return await Task.Run(() => result);
        }

        // public async Task<Dictionary<string,string>> GetPropertyByParentPropertyCode(string parentPropertyCode)
        // {
        //     Dictionary<string,string> PropertyDDL=new Dictionary<string, string>();
        //     var data = DbClientFactory<PropertyDbClient>.Instance.GetPropertyByParentPropertyCode("Server=DESKTOP-JLGDO90;Database=News_DB;Trusted_Connection=True;MultipleActiveResultSets=true");
           
        //     return await Task.Run(() => PropertyDDL);
        // }

        public async Task<List<PropertyModel>> GetPropertyListByParentPropertyCode(string parentPropertyCode)
        {            
            var data = DbClientFactory<PropertyDbClient>.Instance.GetPropertyListByParentPropertyCode(_configuration["ConnectionStrings:DefaultConnection"], parentPropertyCode);
            
            var PropertyList=data.OrderByDescending(x=>x.name).ToList();
            //.ToDictionary(x=> x.id.ToString(), x=>x.name.ToString());

            return await Task.Run(() => PropertyList);
        }
        #endregion
    }
}
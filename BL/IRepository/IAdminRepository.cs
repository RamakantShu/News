using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Microsoft.AspNetCore.Http;
using webapi.ViewModel;

namespace webapi.IRepository
{
    public interface IAdminRepository
	{
        #region Public Methods
        Task<int> SaveNewsContent(NewsContentModels mdl, IFormFileCollection files=null);
        //Task<Dictionary<string,string>> GetPropertyByParentPropertyCode(string parentPropertyCode);
        Task<List<PropertyModel>> GetPropertyListByParentPropertyCode(string propertyCode);
        #endregion
    }
}
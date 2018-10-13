using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DL.Helper;
using webapi.ViewModel;

namespace DL.DbClients
{
    public class PropertyDbClient
    {        
        public List<PropertyModel> GetAllProperty(string conStr)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<PropertyModel>>(conStr, 
            "GetProperties", 
            r => r.MapAsPropertyList()
            );
        }

        public PropertyModel GetPropertyByParentPropertyCode(string conStr, string propertyCode)
        {
            SqlParameter[] sqlParams = {
                            new SqlParameter("@PropertyCode", SqlDbType.VarChar, 100)
                            };
            
            sqlParams[0].Value=propertyCode;
            
            return SqlHelper.ExtecuteProcedureReturnData<PropertyModel>(conStr, 
            "GetPropertyByParentPropertyCode",            
            r => r.MapAsProperty(),
            sqlParams
            );
        }

        public List<PropertyModel> GetPropertyListByParentPropertyCode(string conStr, string propertyCode)
        {
            SqlParameter[] sqlParams = {
                            new SqlParameter("@PropertyCode", SqlDbType.VarChar, 100)
                            };
            
            sqlParams[0].Value=propertyCode;
            
            return SqlHelper.ExtecuteProcedureReturnData<List<PropertyModel>>(conStr, 
            "GetPropertyByParentPropertyCode",            
            r => r.MapAsPropertyList(),
            sqlParams
            );
        }
    }
}
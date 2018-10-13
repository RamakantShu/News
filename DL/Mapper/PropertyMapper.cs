using System.Collections.Generic;
using System.Data.SqlClient;
using DL.Helper;
using webapi.ViewModel;

// namespace DL.Mapper
// {
    public static class PropertyMapper
    {  
        public static PropertyModel MapAsProperty(this SqlDataReader reader,bool isList = false)  
        {  
            if(!isList)  
            {  
                if (!reader.HasRows)  
                    return null;  
                reader.Read();  
            }  
            var item = new PropertyModel();  
            if (reader.IsColumnExists("id"))  
                item.id = SqlHelper.GetNullableInt32(reader, "id");  

            if (reader.IsColumnExists("parent_id"))  
                item.parent_id = SqlHelper.GetNullableInt32(reader, "parent_id");  
  
            if (reader.IsColumnExists("name"))  
                item.name = SqlHelper.GetNullableString(reader, "name");  
  
            if (reader.IsColumnExists("code"))  
                item.code = SqlHelper.GetNullableString(reader, "code");  
  
            if (reader.IsColumnExists("comment"))  
                item.comment = SqlHelper.GetNullableString(reader, "comment");  
  
            if (reader.IsColumnExists("is_active"))  
                item.is_active = SqlHelper.GetBoolean(reader, "is_active");  
  
            if (reader.IsColumnExists("created_by_name"))  
                item.created_by_name = SqlHelper.GetNullableString(reader, "created_on");  

            if (reader.IsColumnExists("created_by_name"))  
                item.created_on = SqlHelper.GetNullableString(reader, "created_on");  
  
            return item;  
        }  
  
        public static List<PropertyModel> MapAsPropertyList(this SqlDataReader reader)  
        {  
            var list = new List<PropertyModel>();  
            while(reader.Read())  
            {  
                list.Add(MapAsProperty(reader, true));  
            }  
            return list;   
        }  
    }  
//}
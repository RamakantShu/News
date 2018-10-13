using System;
using System.Threading;

namespace DL.DbClients
{
    public class DbClientFactory<T>  
    {  
        private static Lazy<T> _factoryLazy = new Lazy<T>(  
            () => (T)Activator.CreateInstance(typeof(T)),  
            LazyThreadSafetyMode.ExecutionAndPublication);  
  
        public static T Instance  
        {  
            get  
            {  
                return _factoryLazy.Value;  
            }  
        }  
    } 
}
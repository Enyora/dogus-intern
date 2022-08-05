using System;
using System.Collections.Generic;

namespace ClientsApp.Models
{
    public static class Repository
    {
        private static List<Clients> _client = null;
        static Repository()
        {
            _client = new List<Clients>()
            {

            };
        }

    }

    public static List<Clients> Clients
    {
        get
        {
            return _client;
        }
        
    } 

    public static void AddClient (Clients entity)
    {
        _client.Add(entity);
    }


    public static Clients GetByID(int id)  
    {
        return _client.FisrtOrDefault(i => i.ID == id);
    }//dışarıdan gönderilen her bir client idsi ile içerideki clientı karşılaştırır.

}
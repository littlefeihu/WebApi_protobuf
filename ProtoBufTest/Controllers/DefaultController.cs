using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace ProtoBufTest.Controllers
{
    public class DefaultController : ApiController
    {
        public List<Item> GetItem()
        {
            return new List<Item> { 
               new  Item{  Name="1"},
               new  Item{  Name="2"},
               new  Item{  Name="3"}
            };
        }
        public int PostItem(List<Item> items)
        {
            return items.Count;
        }
    }

    [DataContract]
    public class Item
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public long Value { get; set; }
    }
}

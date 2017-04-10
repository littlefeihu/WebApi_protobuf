using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;

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


        public AwesomeMessage GetMessages()
        {
            return new AwesomeMessage { awesomeField = "中华人名共和国" };
        }

        public AwesomeMessage PostMessage(AwesomeMessage message)
        {
            return new AwesomeMessage { awesomeField = "HK" };
        }
    }

    [DataContract]
    public class AwesomeMessage
    {
        [DataMember(Order = 1)]
        public string awesomeField { get; set; }
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

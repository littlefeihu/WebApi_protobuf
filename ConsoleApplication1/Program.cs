using ProtoBuf.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WebApiContrib.Formatting;

namespace ConsoleApplication1
{
    class Program
    {
        static  void Main(string[] args)
        {
      
            var httpClient = new HttpClient();
         
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-protobuf"));

            var response = httpClient.GetAsync("http://localhost:60339/api/Default/GetItem").Result;
            //把 ProtoBuf Stream 反序列化成 集合
            var  obj = (RuntimeTypeModel.Default).Deserialize(response.Content.ReadAsStreamAsync().Result, null, typeof(List<Item>)) as List<Item>;
            
            Console.WriteLine(obj.Count);

            //设置请求头
            var content = new ObjectContent<List<Item>>(obj, new ProtoBufFormatter());
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");

            var postResponse1=  httpClient.PostAsync("http://localhost:60339/api/Default/PostItem", content).Result;
            var postResult = postResponse1.Content.ReadAsStreamAsync().Result;
            var intValue = (RuntimeTypeModel.Default).Deserialize(postResult, null, typeof(int));

            Console.WriteLine(intValue);
            Console.ReadKey();
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
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace mogodb
{
    public class mongo
    {
        static mongo _Instance;

        public static mongo GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new mongo();
            }
            return _Instance;
        }

        public void GetServer()
        {
            /// <summary>
            /// 数据库连接
            /// </summary>
            string conn = "mongodb://127.0.0.1:27017";
            /// <summary>
            /// 指定的数据库
            /// </summary>
            string dbName = "zhbdb";
            /// <summary>
            /// 指定的表
            /// </summary>
            string tbName = "mycol";
            MongoServer ms = MongoServer.Create(conn); // 服务器
            MongoDatabase db1 = ms.GetDatabase("NewCol");// db
            MongoCollection col1 = db1.GetCollection("NewCol");
            MongoUser user = new MongoUser("zhb","123456",false);// 用户
            var o = new { Uid = 123, Name = "xixiNormal", Password = "111111" };
            col1.Insert(o);
            BsonDocument b = new BsonDocument();
            b.Add("xx", "oo");
            b.Add("中国", "美国");
            b.Add("kg", "加内特");
            col1.Insert(b);

           

        }
    }
}

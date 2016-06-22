using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
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



            string conn1 = "mongodb://192.168.0.4:27017";
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

            #region  使用zhubdb

            MongoServer ms1 = MongoServer.Create(conn);
            MongoDatabase db = ms1.GetDatabase("zhbdb");
            MongoCollection cl1 = db.GetCollection("zhbdb");

            IMongoQuery query = Query.EQ("name", "zhuangzhuang");
            IMongoUpdate update=Update.AddToSet("myname","这个是我在C#中修改的值");
       
            MongoUpdateOptions option=new MongoUpdateOptions();
            option.CheckElementNames=true;
            cl1.Update(query, update);
            #endregion

            #region mongoclient
            MongoClient client = new MongoClient(conn1);
             MongoServer nmos= client.GetServer();
              MongoDatabase ndb=   nmos.GetDatabase("zhbdb");
              MongoCollection ncol = ndb.GetCollection("zhbdb");
            #endregion




        }
    }
}

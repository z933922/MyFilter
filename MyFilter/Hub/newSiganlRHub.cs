using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace MyFilter
{
    public class newSiganlRHub:Hub
    {
        //声明静态变量存储当前在线用户
        public static class UserHandler
        {
            /// <summary>
            ///   string 用户的contenctid  string 用户的sysno string 用户的name
            /// </summary>
            public static Dictionary<string, Dictionary<string, string>> ConnectedIds = new Dictionary<string, Dictionary<string, string>>();

        }

        //用户进入页面时执行的（连接操作）
        public void UserConnected(string sysno, string name)
        {

            //新增目前使用者上线清单

            //进行编码，防止XSS攻击
            name = HttpUtility.HtmlEncode(name);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // sysno 用戶的  name用戶的暱稱
            dic.Add(sysno, name);

            string message = "用户<font color='red'> " + name + " </font>登录";

            //发送信息给自己，并显示上线清单
            int count = UserHandler.ConnectedIds.Count();

            // 找到 当用登录用户 的所有ConnectionId 是一個集合
            var contentids = UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key == sysno).Select(p => p.Key);
            count = contentids.ToList().Count;

            // 要發送給的connectonid
            var sendconnectids = UserHandler.ConnectedIds.Where(p => !contentids.Contains(p.Key)).Select(p => p.Key);

            List<string> sendlist = new List<string>();
            try
            {
                sendlist = sendconnectids.ToList();
            }
            catch (Exception ex)
            {


            }

            // 添加 其他用戶的下拉框

            Clients.Clients(sendlist).addList(Context.ConnectionId, sysno, name);

            // 发送消息
            Clients.Clients(sendlist).sendMessage(message);

            // 自己的下拉款
            Groups.Add(Context.ConnectionId, sysno);



            Clients.Caller.getList(UserHandler.ConnectedIds.Where(p => !contentids.Contains(p.Key)).Select(p => new { id = p.Key, sysno = p.Value.FirstOrDefault().Key, name = p.Value.FirstOrDefault().Value }).ToList());
            UserHandler.ConnectedIds.Add(Context.ConnectionId, dic);
            count = UserHandler.ConnectedIds.Count();

        }


        //发送信息给特定人
        /// <summary>
        ///  
        /// </summary>
        /// <param name="ToId">发送给对方的toid</param>
        /// <param name="message">信息内容</param>
        /// <param name="sysnoid">对方的sysno</param>
        public void sendMessage(string ToId, string message, string sysnoid)
        {
            message = HttpUtility.HtmlEncode(message);
            string fromName = "";
            string ConnectionId = "";
            int count = UserHandler.ConnectedIds.Count();
            if (UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).Count() > 0)
            {
                fromName = UserHandler.ConnectedIds.Where(p => p.Key == Context.ConnectionId).FirstOrDefault().Value.FirstOrDefault().Value;
                ConnectionId = Context.ConnectionId;
            }
            else
            {
                fromName = UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key == sysnoid).FirstOrDefault().Value.FirstOrDefault().Value;
                ConnectionId = UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key == sysnoid).FirstOrDefault().Key;
            }
            count = UserHandler.ConnectedIds.Count();
            if (ToId == "all")
            {
                #region 群聊功能
                message = "<font color='red'>" + fromName + "说：</font>" + message;
                // 相同 sysno 是同一个的
                // 当前用户的sysno
                var sysno = UserHandler.ConnectedIds.FirstOrDefault(p => p.Key == Context.ConnectionId).Value.FirstOrDefault().Key;

                // 当前用户的所有的 contentid
                var mycontentids = UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key == sysno).Select(p => p.Key).ToList();

                //   其他用户的contentid
                var othercontentids = UserHandler.ConnectedIds.Where(p => !mycontentids.Contains(p.Key)).Select(p => p.Key).ToList();

                //Clients.Others.sendMessage(message); // 发给别人的
                Clients.Clients(othercontentids).sendMessage(message);

                // 发给自己的
                Clients.Clients(mycontentids).mymessage(message);
                #endregion
            }
            else
            {
                message = " <font style='color:red'>" + fromName + "{谜}说</font>：" + message;

                // 当前用户的sysno
                var sysno = UserHandler.ConnectedIds.FirstOrDefault(p => p.Key == Context.ConnectionId).Value.FirstOrDefault().Key;

                // 当前用户的所有的 contentid
                var mycontentids = UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key == sysno).Select(p => p.Key).ToList();

                //  发送给某用户的sysno
                var tosysno = UserHandler.ConnectedIds.FirstOrDefault(p => p.Key == ToId).Value.FirstOrDefault().Key;

                // 发送给莫用户的 contentid
                var other1 = UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key == tosysno).Select(p => p.Key).ToList();

                // 给其他人的消息
                Clients.Clients(other1).sendMessage(message);

                // 给自己的自己
                Clients.Clients(mycontentids).mymessage(message);

                // 其他人的
                Clients.Group(sysnoid).sendMessage("group:" + message);

                //本人的
                Clients.Group(Context.ConnectionId).mymessage("group:" + message);
            }
        }


        //当使用者断线时执行
        public override Task OnDisconnected(bool stopCalled)
        {

            //  var sysno = UserHandler.ConnectedIds.FirstOrDefault(p => p.Key == Context.ConnectionId).Value.FirstOrDefault().Key;// 当前用户的sysno

            // Clients.Others.getList(UserHandler.ConnectedIds.Where(p => p.Value.FirstOrDefault().Key != sysno).Select(p => new { id = p.Key, sysno = p.Value.FirstOrDefault().Key, name = p.Value.FirstOrDefault().Value }).ToList());

            //当使用者离开时，移除在清单内的ConnectionId
            Clients.All.removeList(Context.ConnectionId);
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            // 得到当前connectionid对应的 用户的sysno
            var sysno = UserHandler.ConnectedIds.Where(s => s.Key == Context.ConnectionId).FirstOrDefault().Key;
            // 如果sysno 不为空 该用户还在线 至少 退出其中的某一个页面

            //如果为空 该用户已经下线了 该用户下线了 要告知其他用户 并通知该用户已经下线了


            return base.OnDisconnected(stopCalled);
        }
    }
}
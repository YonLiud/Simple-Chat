using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Server
{
    public class Server : BaseScript
    {
        public Server()
        {
            EventHandlers["serverTweet"] += new Action<string, string>(serverTweet);
            EventHandlers["serverAction"] += new Action<string, string>(serverAction);
        }
        private void serverTweet(string name, string args)
        {
            TriggerClientEvent("clientTweet", name, args);
        }
        private void serverAction(string name, string args)
        {
            TriggerClientEvent("clientAction", name, args);
        }
    }
}

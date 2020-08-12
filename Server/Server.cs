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
            EventHandlers["serverTweet"] += new Action<string, string>(ServerTweet);
            EventHandlers["serverAction"] += new Action<string, string>(ServerAction);
            EventHandlers["serverOOC"] += new Action<string, string>(ServerOOC);
        }
        private void ServerTweet(string name, string args)
        {
            TriggerClientEvent("clientTweet", name, args);
        }
        private void ServerAction(string name, string args)
        {
            TriggerClientEvent("clientAction", name, args);
        }
        private void ServerOOC(string name, string args)
        {
            TriggerClientEvent("clientOOC", name, args);
        }
    }
}

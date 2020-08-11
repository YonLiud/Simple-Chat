using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Client
{
    public class Client : BaseScript
    {
        public Client()
        {
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
            EventHandlers["clientTweet"] += new Action<string, string>(clientTweet);
            EventHandlers["clientAction"] += new Action<string, string>(clientAction);
        }
        private void OnClientResourceStart(string resourceName)
        {
            RegisterCommand("twt", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count < 1)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        multiline = true,
                        args = new[] { "Oops", $"Did you mean to type your message too?" }
                    });
                    return;
                }
                string text = "";
                text = string.Join(" ", args.ToArray());
                string playername = Game.Player.Name;
                TriggerServerEvent("serverTweet", playername, text);
            }), false);
            RegisterCommand("me", new Action<int, List<object>, string>((source, args, raw) =>
            {
                if (args.Count < 1)
                {
                    TriggerEvent("chat:addMessage", new
                    {
                        color = new[] { 255, 0, 0 },
                        multiline = true,
                        args = new[] { "Oops", $"Did you mean to type your message too?" }
                    });
                    return;
                }
                string text = "";
                text = string.Join(" ", args.ToArray());
                string playername = Game.Player.Name;
                TriggerServerEvent("serverAction", playername, text);
            }), false);

        }
        private void clientTweet(string name, string args)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 0, 204, 204 },
                multiline = true,
                args = new[] { "Tweeter🐦 "/*<< BIRB <<*/, $" {name} > {args}" }
            });
            return;
        }
        private void clientAction(string name, string args)
        {
            TriggerEvent("chat:addMessage", new
            {
                color = new[] { 255, 87, 87 },
                multiline = true,
                args = new[] { "Action", $" ^*{name}:  {args}" }
            });
            return;
        }
    }
}

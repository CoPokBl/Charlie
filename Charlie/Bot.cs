using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Charlie {
    public class Bot {
        
        public static DiscordSocketClient Client;

        public static int Main(string[] args) {
            new Bot().MainAsync().GetAwaiter().GetResult();
            return 0;
        }

        public async Task MainAsync() {
            Client = new DiscordSocketClient();

            Client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            var token = "token";

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }
        
        private Task Log(LogMessage msg) {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
        
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using KonataCSharp.SDK.Core;
using KonataCSharp.SDK.EventArgs.Enums;

namespace KonataCSharp.SDK.EventArgs.BaseModel
{
    public class KonataApi
    {
        public async Task<GroupGrantSpecialTitleReturnType> GroupGrantSpecialTitle(uint bot, uint group, uint member,
            string title, uint second = uint.MaxValue)
        {
            return (GroupGrantSpecialTitleReturnType) await SocketClient.Send("GroupGrantSpecialTitle",
                new Dictionary<string, object>
                {
                    {"Bot", bot},
                    {"Group", group},
                    {"Member", member},
                    {"Seconds", second},
                    {"Title", title}
                });
        }

        public async Task<GroupKickReturnType> GroupKick(uint bot, uint group, uint member,
            bool toggle)
        {
            return (GroupKickReturnType) await SocketClient.Send("GroupKick",
                new Dictionary<string, object>
                {
                    {"Bot", bot},
                    {"Group", group},
                    {"Member", member},
                    {"Toggle", toggle}
                });
        }

        public async Task<PokeReturnType> GroupPoke(uint bot, uint group, uint member)
        {
            return (PokeReturnType) await SocketClient.Send("GroupPoke",
                new Dictionary<string, object>
                {
                    {"Bot", bot},
                    {"Group", group},
                    {"Member", member}
                });
        }

        public async Task<PokeReturnType> PrivatePoke(uint bot, uint friend)
        {
            return (PokeReturnType) await SocketClient.Send("PrivatePoke",
                new Dictionary<string, object>
                {
                    {"Bot", bot},
                    {"Friend", friend}
                });
        }


        /// <returns>Return a new message identifier if no error occurred else</returns>
        /// <returns>return -1 when Operation failed.</returns>
        public async Task<uint> SendGroupMessage(uint bot, uint group, string message,
            uint messageId = 0)
        {
            return await SocketClient.Send("GroupSendMessage",
                new Dictionary<string, object>
                {
                    {"Bot", bot},
                    {"Group", group},
                    {"Message", message},
                    {"MessageId", messageId}
                });
        }

        /// <returns>Return a new message identifier if no error occurred else</returns>
        /// <returns>return -1 when Operation failed.</returns>
        public async Task<uint> SendPrivateMessage(uint bot, uint friend, string message,
            uint messageId = 0)
        {
            return await SocketClient.Send("PrivateSendMessage",
                new Dictionary<string, object>
                {
                    {"Bot", bot},
                    {"Friend", friend},
                    {"Message", message},
                    {"MessageId", messageId}
                });
        }
    }
}
using BlazorForum.Data;
using BlazorForum.Database;

namespace BlazorForum.Libraries
{
    public class LibModerator(IDatabaseCalls DatabaseCalls, LibExternal LibExternal)        
    {
        private const string moderatorIpKey = "ModeratorIp";

        public async Task<bool> IsModeratorAsync(IpInfo ipInfo)
        {
            try
            {
                List<Setting> settings = await DatabaseCalls.GetSettingAsync(moderatorIpKey);

                if (settings.Count != 1)
                    return false;

                return (settings.First().Value.Trim() == ipInfo.Ip.Trim()) && (DateTime.Now - settings.First().ModifiedOn).TotalDays < 3;
            }
            catch (Exception ex)
            {
                await LibExternal.SendEmailAsync(nameof(IsModeratorAsync), ex);
            }
            return false;
        }

        public async Task ModeratorLogInAsync(IpInfo ipInfo)
        {
            try
            {
                await DatabaseCalls.SaveSettingAsync(moderatorIpKey, ipInfo.Ip);
            }
            catch (Exception ex)
            {
                await LibExternal.SendEmailAsync(nameof(ModeratorLogInAsync), ex);
            }
        }

        public async Task ModeratorLogOutAsync()
        {
            try
            {
                await DatabaseCalls.SaveSettingAsync(moderatorIpKey, string.Empty);
            }
            catch (Exception ex)
            {
                await LibExternal.SendEmailAsync(nameof(ModeratorLogOutAsync), ex);
            }
        }
    }
}

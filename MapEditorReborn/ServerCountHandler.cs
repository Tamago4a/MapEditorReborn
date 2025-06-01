namespace MapEditorReborn
{
    using Exiled.API.Features;
    using System;
    using System.Threading;

    internal static class ServerCountHandler
    {
        internal static void Loop()
        {
            Thread.Sleep(10000);

            while (true)
            {
                try
                {
                    HttpQuery.Get($"https://mer.scpsecretlab.pl/?address={Server.IpAddress}:{Server.Port}");
                }
                catch (Exception)
                {
                    // ignored
                }

                Thread.Sleep(1800000);
            }
        }
    }
}
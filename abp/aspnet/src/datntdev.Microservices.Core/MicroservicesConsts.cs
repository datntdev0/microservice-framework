using datntdev.Microservices.Debugging;

namespace datntdev.Microservices;

public class MicroservicesConsts
{
    public const string LocalizationSourceName = "Microservices";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ebbe9bddc764417cb8f0649d8d8fa5ab";
}

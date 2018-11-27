using DiscordRPCSharp;
using UnityEngine;

/// <summary>
/// Discorrd RPC Unity managers namespace
/// </summary>
namespace DiscordRPCUnity.Managers
{
    /// <summary>
    /// Discord Rich Presence Manager script class
    /// </summary>
    public class DiscordRichPresenceManagerScript : MonoBehaviour
    {
        /// <summary>
        /// Application ID
        /// </summary>
        [SerializeField]
        private string applicationID;

        /// <summary>
        /// Auto register
        /// </summary>
        [SerializeField]
        private bool autoRegister = true;

        /// <summary>
        /// Optional Steam ID
        /// </summary>
        [SerializeField]
        private string optionalSteamID;

        /// <summary>
        /// Instance
        /// </summary>
        private static DiscordRichPresenceManagerScript instance;

        /// <summary>
        /// Application ID
        /// </summary>
        public string ApplicationID
        {
            get
            {
                if (applicationID == null)
                {
                    applicationID = "";
                }
                return applicationID;
            }
        }

        /// <summary>
        /// Optional Steam ID
        /// </summary>
        public string OptionalSteamID
        {
            get
            {
                if (optionalSteamID == null)
                {
                    optionalSteamID = "";
                }
                return optionalSteamID;
            }
        }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                if (OptionalSteamID.Trim().Length > 0)
                {
                    DiscordRichPresence.Initialize(ApplicationID, autoRegister, OptionalSteamID);
                }
                else
                {
                    DiscordRichPresence.Initialize(ApplicationID, autoRegister);
                }
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// On destroy
        /// </summary>
        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
                DiscordRichPresence.Shutdown();
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        private void Update()
        {
            DiscordRichPresence.RunCallbacks();
        }
    }
}

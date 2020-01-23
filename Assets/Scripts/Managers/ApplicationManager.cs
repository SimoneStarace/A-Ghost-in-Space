using UnityEngine;
namespace Managers
{
    public static class ApplicationManager
    {
        #region METHODS
        /// <summary>
        /// Opens a webpage by url.
        /// </summary>
        /// <param name="url">The url of the webpage</param>
        public static void OpenWebPage(string url)
        {
            if (!string.IsNullOrEmpty(url) && url.Contains("https://"))
            {
                Application.OpenURL(url);
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogWarning("THE URL IS EMPTY OR NULL!");
            }
#endif
        }
        /// <summary>
        /// Get the company name of the Game.
        /// </summary>
        /// <returns>The company name of the game.</returns>
        public static string GetCompanyName() => Application.companyName;

        /// <summary>
        /// Get the version of the Game.
        /// </summary>
        /// <returns>The version of the game.</returns>
        public static string GetVersion() => Application.version;
        /// <summary>
        /// Sets the target framerate of the game.
        /// </summary>
        /// <param name="framerate">The framerate to set.</param>
        public static void SetFramerate(int framerate = 60) => Application.targetFrameRate = framerate;
        /// <summary>
        /// Method for close the application.
        /// </summary>
        public static void CloseApplication() => Application.Quit();
        #endregion
    } 
}
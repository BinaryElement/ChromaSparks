using Chroma;
using Chroma.Settings;
using Harmony;
using IllusionPlugin;
using UnityEngine.SceneManagement;

namespace ChromaSparks {

    public class Plugin : IPlugin, IChromaExtension {

        public string Name => "ChromaSparks";
        public string Version => "1.0.2";

        public void OnApplicationStart() {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1) {
        }

        private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1) {
        }

        public void OnApplicationQuit() {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level) {

        }

        public void OnLevelWasInitialized(int level) {
        }

        public void OnUpdate() {
        }

        public void OnFixedUpdate() {
        }

        public void ChromaApplicationStarted(ChromaPlugin chromaPlugin) {
            ChromaSparksConfig.RegisterListeners();
            ChromaSparksSettingsUI.RegisterListeners();
        }

        HarmonyInstance harmonyInstance = HarmonyInstance.Create("net.binaryelement.chromasparks");
        public HarmonyInstance PatchHarmony() {
            harmonyInstance.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
            return harmonyInstance;
        }

    }

}

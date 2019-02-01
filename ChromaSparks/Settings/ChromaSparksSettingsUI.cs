using CustomUI.GameplaySettings;
using CustomUI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chroma.Settings {

    class ChromaSparksSettingsUI {

        internal static void RegisterListeners() {
            ChromaSettingsUI.ExtensionSubMenusEvent += SetupChromaSparksMenu;
            ChromaSettingsUI.GameplaySubMenuCreatedEvent += TechnicolourSubMenuCreated;
        }

        private static void SetupChromaSparksMenu(float[] presets, List<NamedColor> colourPresets) {

            /*
             * PARTICLES
             */
            SubMenu ctParticles = SettingsUI.CreateSubMenu("Chroma Sparks");

            float[] particleMults = new float[] { 0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1f, 1.1f, 1.2f, 1.3f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2f,
                2.25f, 2.5f, 2.75f, 3f, 3.25f, 3.5f, 3.75f, 4f, 4.25f, 4.5f, 4.75f, 5f,
                5.5f, 6f, 6.5f, 7f, 7.5f, 8f, 8.5f, 9f, 9.5f, 10f,
                11f, 12f, 13f, 14f, 15f, 16f, 17f, 18f, 19f, 20f,
                22.5f, 25f, 27.5f, 30f, 32.5f, 35f, 37.5f, 40f, 42.5f, 45f, 47.5f, 50f,
                55f, 60f, 65f, 70f, 75f, 80f, 85f, 90f, 100f,
                110f, 120f, 130f, 140f, 150f, 160f, 170f, 180f, 190f, 200f
            };

            //Completely disable particle affecting
            BoolViewController ctParticlesEnabled = ctParticles.AddBool("Override Particles");
            ctParticlesEnabled.GetValue += delegate { return ChromaSparksConfig.ParticleManipulationEnabled; };
            ctParticlesEnabled.SetValue += delegate (bool value) { ChromaSparksConfig.ParticleManipulationEnabled = value; };

            //global Particles Mult
            ListViewController ctParticlesMax = ctParticles.AddList("Global Particle Max", particleMults);
            ctParticlesMax.GetValue += delegate { return ChromaSparksConfig.ParticlesGlobalMaxMult; };
            ctParticlesMax.SetValue += delegate (float value) { ChromaSparksConfig.ParticlesGlobalMaxMult = value; };
            ctParticlesMax.FormatValue += delegate (float value) { return value * 100 + "%"; };

            //slash Particles Mult
            ListViewController ctSlashAmt = ctParticles.AddList("Slash Part. Amount", particleMults);
            ctSlashAmt.GetValue += delegate { return ChromaSparksConfig.SlashParticlesMult; };
            ctSlashAmt.SetValue += delegate (float value) { ChromaSparksConfig.SlashParticlesMult = value; };
            ctSlashAmt.FormatValue += delegate (float value) { return value * 100 + "%"; };

            /*//slash Particles Life
            ListViewController ctSlashLife = ctParticles.AddList("Slash Part. Lifetime", particleMults);
            ctSlashLife.GetValue += delegate { return Plugin.slashParticlesLifeMult; };
            ctSlashLife.SetValue += delegate (float value) { Plugin.slashParticlesLifeMult = value; Plugin.didChangeSettings = true; };
            ctSlashLife.FormatValue += delegate (float value) { return value * 100 + "%"; };*/

            //slash Particles Life
            ListViewController ctSlashSpeed = ctParticles.AddList("Slash Part. Speed", particleMults);
            ctSlashSpeed.GetValue += delegate { return ChromaSparksConfig.SlashParticlesSpeedMult; };
            ctSlashSpeed.SetValue += delegate (float value) { ChromaSparksConfig.SlashParticlesSpeedMult = value; };
            ctSlashSpeed.FormatValue += delegate (float value) { return value * 100 + "%"; };

            ListViewController ctSlashTimeScale = ctParticles.AddList("Slash Part. TimeScale", particleMults);
            ctSlashTimeScale.GetValue += delegate { return ChromaSparksConfig.SlashParticlesTimeScale; };
            ctSlashTimeScale.SetValue += delegate (float value) { ChromaSparksConfig.SlashParticlesTimeScale = value; };
            ctSlashTimeScale.FormatValue += delegate (float value) {
                if (value == 1) return "Unchanged";
                return value + "/s";
            };


            //explosions Particles Mult
            ListViewController ctExplosionsAmt = ctParticles.AddList("Explosion Part. Amount", particleMults);
            ctExplosionsAmt.GetValue += delegate { return ChromaSparksConfig.ExplosionParticlesMult; };
            ctExplosionsAmt.SetValue += delegate (float value) { ChromaSparksConfig.ExplosionParticlesMult = value; };
            ctExplosionsAmt.FormatValue += delegate (float value) { return value * 100 + "%"; };

            /*//explosions Particles Life
            ListViewController ctExplosionsLife = ctParticles.AddList("Explosion Part. Lifetime", particleMults);
            ctExplosionsLife.GetValue += delegate { return Plugin.explosionParticlesLifeMult; };
            ctExplosionsLife.SetValue += delegate (float value) { Plugin.explosionParticlesLifeMult = value; Plugin.didChangeSettings = true; };
            ctExplosionsLife.FormatValue += delegate (float value) { return value * 100 + "%"; };*/

            //explosions Particles Life
            ListViewController ctExplosionsSpeed = ctParticles.AddList("Explosion Part. Speed", particleMults);
            ctExplosionsSpeed.GetValue += delegate { return ChromaSparksConfig.ExplosionParticlesSpeedMult; };
            ctExplosionsSpeed.SetValue += delegate (float value) { ChromaSparksConfig.ExplosionParticlesSpeedMult = value; };
            ctExplosionsSpeed.FormatValue += delegate (float value) { return value * 100 + "%"; };

            ListViewController ctExplosionsTimeScale = ctParticles.AddList("Explosion Part. TimeScale", particleMults);
            ctExplosionsTimeScale.GetValue += delegate { return ChromaSparksConfig.ExplosionParticlesTimeScale; };
            ctExplosionsTimeScale.SetValue += delegate (float value) { ChromaSparksConfig.ExplosionParticlesTimeScale = value; };
            ctExplosionsTimeScale.FormatValue += delegate (float value) {
                if (value == 1) return "Unchanged";
                return value + "/s";
            };


        }

        private static void TechnicolourSubMenuCreated(string name) {
            if (name == "CTT") {
                //We have technicolour

                List<Tuple<float, string>> technicolourOptions = new List<Tuple<float, string>> {
                    { 0f, "OFF" },
                    { 1f, "WARM/COLD" },
                    { 2f, "EITHER" },
                    { 3f, "TRUE RANDOM" }
                };

                MultiSelectOption techniParticles = GameplaySettingsUI.CreateListOption(GameplaySettingsPanels.PlayerSettingsRight, "Tech. Particles", "CTT", "Technicolour style of the particles.");
                for (int i = 0; i < technicolourOptions.Count; i++) techniParticles.AddOption(i, technicolourOptions[i].Item2);
                techniParticles.GetValue += delegate {
                    return (int)ChromaSparksConfig.TechnicolourSparksStyle;
                };
                techniParticles.OnChange += delegate (float value) {
                    ColourManager.TechnicolourStyle style = ColourManager.GetTechnicolourStyleFromFloat(value);
                    ChromaSparksConfig.TechnicolourSparksStyle = style;
                };

            }
        }

    }

}

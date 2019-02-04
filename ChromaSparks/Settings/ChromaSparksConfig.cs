using BS_Utils.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Chroma.ColourManager;
using static Chroma.Settings.ChromaConfig;

namespace Chroma.Settings {

    class ChromaSparksConfig {
        
        internal static void RegisterListeners() {
            ChromaConfig.LoadSettingsEvent += OnLoadSettingsEvent;
        }

        private static void OnLoadSettingsEvent(Config iniProfile, LoadSettingsType type) {


            if (type == LoadSettingsType.INITIAL) {
                technicolourSparksStyle = (TechnicolourStyle)ChromaConfig.GetInt("Technicolour", "technicolourSparksStyle", 0);
            }

            /*
             * PARTICLES
             */

            particleManipulationEnabled = ChromaConfig.GetBool("Particles", "particleManipulationEnabled", false);
            particlesGlobalMaxMult = ChromaConfig.GetFloat("Particles", "particlesGlobalMaxMult", 1f);

            slashParticlesMult = ChromaConfig.GetFloat("Particles", "slashParticlesMult", 1f);
            slashParticlesLifeMult = ChromaConfig.GetFloat("Particles", "slashParticlesLifeMult", 1f);
            slashParticlesSpeedMult = ChromaConfig.GetFloat("Particles", "slashParticlesSpeedMult", 1f);
            slashParticlesTimeScale = ChromaConfig.GetFloat("Particles", "slashParticlesTimeScale", 1f);

            explosionParticlesMult = ChromaConfig.GetFloat("Particles", "explosionParticlesMult", 1f);
            explosionParticlesLifeMult = ChromaConfig.GetFloat("Particles", "explosionParticlesLifeMult", 1f);
            explosionParticlesSpeedMult = ChromaConfig.GetFloat("Particles", "explosionParticlesSpeedMult", 1f);
            explosionParticlesTimeScale = ChromaConfig.GetFloat("Particles", "explosionParticlesTimeScale", 1f);

        }



        /*
         * GLOBAL RULES
         */
        public static bool ParticleManipulationEnabled {
            get { return particleManipulationEnabled; }
            set {
                particleManipulationEnabled = value;
                ChromaConfig.SetBool("Particles", "particleManipulationEnabled", particleManipulationEnabled);
            }
        }
        private static bool particleManipulationEnabled = false;

        public static float ParticlesGlobalMaxMult {
            get { return particlesGlobalMaxMult; }
            set {
                particlesGlobalMaxMult = value;
                ChromaConfig.SetFloat("Particles", "particlesGlobalMaxMult", particlesGlobalMaxMult);
            }
        }
        private static float particlesGlobalMaxMult = 1f;



        /*
         * SLASH PARTICLES
         */

        public static float SlashParticlesMult {
            get { return slashParticlesMult; }
            set {
                slashParticlesMult = value;
                ChromaConfig.SetFloat("Particles", "slashParticlesMult", slashParticlesMult);
            }
        }
        private static float slashParticlesMult = 1f;

        public static float SlashParticlesLifeMult {
            get { return slashParticlesLifeMult; }
            set {
                slashParticlesLifeMult = value;
                ChromaConfig.SetFloat("Particles", "slashParticlesLifeMult", slashParticlesLifeMult);
            }
        }
        private static float slashParticlesLifeMult = 1f;

        public static float SlashParticlesSpeedMult {
            get { return slashParticlesSpeedMult; }
            set {
                slashParticlesSpeedMult = value;
                ChromaConfig.SetFloat("Particles", "slashParticlesSpeedMult", slashParticlesSpeedMult);
            }
        }
        private static float slashParticlesSpeedMult = 1f;

        public static float SlashParticlesTimeScale {
            get { return slashParticlesTimeScale; }
            set {
                slashParticlesTimeScale = value;
                ChromaConfig.SetFloat("Particles", "slashParticlesTimeScale", slashParticlesTimeScale);
            }
        }
        private static float slashParticlesTimeScale = 1f;



        /*
         * EXPLOSION PARTICLES
         */
        public static float ExplosionParticlesMult {
            get { return explosionParticlesMult; }
            set {
                explosionParticlesMult = value;
                ChromaConfig.SetFloat("Particles", "explosionParticlesMult", explosionParticlesMult);
            }
        }
        private static float explosionParticlesMult = 1f;

        public static float ExplosionParticlesLifeMult {
            get { return explosionParticlesLifeMult; }
            set {
                explosionParticlesLifeMult = value;
                ChromaConfig.SetFloat("Particles", "explosionParticlesLifeMult", explosionParticlesLifeMult);
            }
        }
        private static float explosionParticlesLifeMult = 1f;

        public static float ExplosionParticlesSpeedMult {
            get { return explosionParticlesSpeedMult; }
            set {
                explosionParticlesSpeedMult = value;
                ChromaConfig.SetFloat("Particles", "explosionParticlesSpeedMult", explosionParticlesSpeedMult);
            }
        }
        private static float explosionParticlesSpeedMult = 1f;

        public static float ExplosionParticlesTimeScale {
            get { return explosionParticlesTimeScale; }
            set {
                explosionParticlesTimeScale = value;
                ChromaConfig.SetFloat("Particles", "explosionParticlesTimeScale", explosionParticlesTimeScale);
            }
        }
        private static float explosionParticlesTimeScale = 1f;


        public static TechnicolourStyle TechnicolourSparksStyle {
            get {
                return technicolourSparksStyle;
            }
            set {
                technicolourSparksStyle = value;
                ChromaConfig.SetInt("Technicolour", "technicolourSparksStyle", (int)technicolourSparksStyle);
            }
        }
        private static TechnicolourStyle technicolourSparksStyle = TechnicolourStyle.OFF;

    }

}

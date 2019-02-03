using Chroma.Settings;
using Chroma.Utils;
using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Chroma.HarmonyPatches {

    [HarmonyPatch(typeof(NoteCutParticlesEffect))]
    [HarmonyPatch("SpawnParticles")]
    class NoteCutParticlesEffectSpawnParticles {

        static void Prefix(ref NoteCutParticlesEffect __instance, ref int sparkleParticlesCount, ref int explosionParticlesCount) {

            if (!ChromaSparksConfig.ParticleManipulationEnabled) return;

            sparkleParticlesCount = Mathf.FloorToInt(150 * ChromaSparksConfig.SlashParticlesMult);
            explosionParticlesCount = Mathf.FloorToInt(150 * ChromaSparksConfig.ExplosionParticlesMult);

            ParticleSystem[] sparklesPS = __instance.GetField<ParticleSystem[]>("_sparklesPS");

            foreach (ParticleSystem sparklesSubPS in sparklesPS) {
                ParticleSystem.MainModule sparkles = sparklesSubPS.main;
                if (ChromaSparksConfig.SlashParticlesMult != 1) sparkles.maxParticles = Mathf.FloorToInt(150 * Mathf.Max(ChromaSparksConfig.ParticlesGlobalMaxMult, ChromaSparksConfig.SlashParticlesMult));
                if (ChromaSparksConfig.SlashParticlesTimeScale != 1) sparkles.simulationSpeed = ChromaSparksConfig.SlashParticlesTimeScale;
                if (ChromaSparksConfig.SlashParticlesLifeMult != 1) {
                    sparkles.duration = 2f * ChromaSparksConfig.SlashParticlesLifeMult;
                    sparkles.startLifetimeMultiplier = 0.99f * ChromaSparksConfig.SlashParticlesLifeMult;
                }
                if (ChromaSparksConfig.SlashParticlesSpeedMult != 1) sparkles.startSpeedMultiplier = 20 * ChromaSparksConfig.SlashParticlesSpeedMult;
            }

            /*for (int i = 0; i < sparklesPS.Length; i++) {
                ParticleSystem sparklesSubPS = sparklesPS[i];
                ChromaLogger.Log(sparklesSubPS.name);
                ChromaLogger.Log("sparklesPS Amt : " + sparkleParticlesCount); // 150
                ChromaLogger.Log("sparklesPS max : " + sparklesSubPS.main.maxParticles); //1000
                ChromaLogger.Log("sparklesPS life : " + sparklesSubPS.main.duration); //2
                ChromaLogger.Log("sparklesPS lifetimeMult : " + sparklesSubPS.main.startLifetimeMultiplier); //0.99
                ChromaLogger.Log("sparklesPS speedMult : " + sparklesSubPS.main.startSpeedMultiplier); //20
            }*/

            /*ParticleSystem sparklesPS = __instance.GetField<ParticleSystem>("_sparklesPS");
            
            ParticleSystem.MainModule sparkles = sparklesPS.main;
            if (ChromaConfig.slashParticlesMult != 1) sparkles.maxParticles = 150 * Mathf.FloorToInt(Mathf.Max(ChromaConfig.particlesGlobalMaxMult, ChromaConfig.slashParticlesMult));
            if (ChromaConfig.slashParticlesTimeScale != 1) sparkles.simulationSpeed = ChromaConfig.slashParticlesTimeScale;
            if (ChromaConfig.slashParticlesLifeMult != 1) {
                sparkles.duration = 2f * ChromaConfig.slashParticlesLifeMult;
                sparkles.startLifetimeMultiplier = 1.2f * ChromaConfig.slashParticlesLifeMult;
            }
            if (ChromaConfig.slashParticlesSpeedMult != 1) sparkles.startSpeedMultiplier = 20 * ChromaConfig.slashParticlesSpeedMult;
            */

            ParticleSystem explosionPS = __instance.GetField<ParticleSystem>("_explosionPS");

            ParticleSystem.MainModule explosions = explosionPS.main;
            if (ChromaSparksConfig.ExplosionParticlesMult != 1) explosions.maxParticles = Mathf.FloorToInt(150 * Mathf.Max(ChromaSparksConfig.ParticlesGlobalMaxMult, ChromaSparksConfig.ExplosionParticlesMult));
            if (ChromaSparksConfig.ExplosionParticlesTimeScale != 1) explosions.simulationSpeed = ChromaSparksConfig.ExplosionParticlesTimeScale;
            if (ChromaSparksConfig.ExplosionParticlesLifeMult != 1) {
                explosions.duration = 2f * ChromaSparksConfig.ExplosionParticlesLifeMult;
                explosions.startLifetimeMultiplier = 0.8f * ChromaSparksConfig.ExplosionParticlesLifeMult;
            }
            if (ChromaSparksConfig.ExplosionParticlesSpeedMult != 1) explosions.startSpeedMultiplier = 12 * ChromaSparksConfig.ExplosionParticlesSpeedMult;


            //ChromaLogger.Log("sparklesPS Amt : " + sparkleParticlesCount); // 150
            //ChromaLogger.Log("sparklesPS max : " + sparklesPS.main.maxParticles); //1000
            //ChromaLogger.Log("sparklesPS life : " + sparklesPS.main.duration); //2
            //ChromaLogger.Log("sparklesPS lifetimeMult : " + sparklesPS.main.startLifetimeMultiplier); //1.2
            //ChromaLogger.Log("sparklesPS speedMult : " + sparklesPS.main.startSpeedMultiplier); //20

            //ChromaLogger.Log("explosionPS Amt : " + sparkleParticlesCount); // 150
            //ChromaLogger.Log("explosionPS max : " + explosionPS.main.maxParticles); //1000
            //ChromaLogger.Log("explosionPS life : " + explosionPS.main.duration); //2
            //ChromaLogger.Log("explosionPS lifetimeMult : " + explosionPS.main.startLifetimeMultiplier); //0.8
            //ChromaLogger.Log("explosionPS speedMult : " + explosionPS.main.startSpeedMultiplier); //12

            return;

        }

    }

}

using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chroma.HarmonyPatches {
    
    [HarmonyPatch(typeof(NoteCutEffectSpawner))]
    [HarmonyPatch("SpawnNoteCutEffect")]
    class NoteCutEffectSpawnerSpawnNoteCutEffect {

        [HarmonyAfter("net.binaryelement.chroma")]
        static void Prefix(ref NoteController noteController) {
            if (SparksColourManager.TechnicolourSparks) {
                ColourManager.SetNoteTypeColourOverride(noteController.noteData.noteType, SparksColourManager.GetTechnicolour(noteController.noteData));
            }
        }

        /*static void Postfix(ref NoteController noteController) {
            if (SparksColourManager.TechnicolourSparks) ColourManager.RemoveNoteTypeColourOverride(noteController.noteData.noteType);
        }*/

    }

}
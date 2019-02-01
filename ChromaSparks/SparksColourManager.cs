using Chroma.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Chroma {

    public static class SparksColourManager {

        public static bool TechnicolourSparks {
            get { return ChromaConfig.TechnicolourEnabled && ChromaSparksConfig.TechnicolourSparksStyle != ColourManager.TechnicolourStyle.OFF; }
        }

        public static Color GetTechnicolour(NoteData note) {
            return ColourManager.GetTechnicolour(note, ChromaSparksConfig.TechnicolourSparksStyle);
        }

    }

}

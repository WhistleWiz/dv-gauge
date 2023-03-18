using Gauge.MeshModifiers;
using Gauge.Utils;
using HarmonyLib;
using UnityEngine;

namespace Gauge.Patches
{
    [HarmonyPatch(typeof(PitStopStation), "OnEnable")]
    public static class PitStopStationPatch
    {
        public static void Postfix(PitStopStation __instance)
        {
            __instance.transform.parent.ModifyMeshes(HandleMesh);
        }

        private static void HandleMesh(string name, Mesh mesh, Component component)
        {
            switch (name)
            {
                // Service station markers
                case "ServiceStationMarker01":
                case "ServiceStationMarker01_LOD1":
                case "ServiceStationMarker02":
                case "ServiceStationMarker02_LOD1":
                    Symmetrical.ScaleToGauge(mesh);
                    mesh.SetModified();
                    break;
            }
        }
    }
}

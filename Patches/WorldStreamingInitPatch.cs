using DV.Utils;
using Gauge.MeshModifiers;
using Gauge.Utils;
using HarmonyLib;
using UnityEngine;

namespace Gauge.Patches
{
    [HarmonyPatch(typeof(WorldStreamingInit), "Awake")]
    public static class WorldStreamingInit_Awake_Patch
    {
        private static readonly ushort[] SLEEPER_SKIP_VERTS = { 498, 499, 500, 501, 503, 506 };

        private static void Postfix()
        {
            if (Main.Settings.gauge.IsStandard())
                return;
            WorldStreamingInit.LoadingFinished += OnLoadingFinished;
        }

        private static void OnLoadingFinished()
        {
            Main.Logger.Log("Modifying static meshes");
            SingletonBehaviour<WorldStreamingInit>.Instance.originShiftParent.ModifyMeshes(HandleMesh);
        }

        private static void HandleMesh(string name, Mesh mesh, Component component)
        {
            switch (name)
            {
                // Switches
                case "rails_static":
                    StaticSwitch.ModifyMesh(mesh);
                    mesh.SetModified();
                    break;
                case "rails_moving":
                    MovingSwitch.ModifyMesh(mesh);
                    mesh.SetModified();
                    break;
                // Switch anchors
                case "anchors":
                    SwitchAnchors.ModifyMesh(mesh);
                    mesh.SetModified();
                    break;
                // Switch sleepers
                case "sleepers":
                case "sleepers-outersign":
                    Symmetrical.ScaleToGauge(mesh, skipVerts: SLEEPER_SKIP_VERTS);
                    mesh.SetModified();
                    break;
                // Roundhouse rails
                case "TurntableRail.002":
                    Symmetrical.ScaleToGauge(mesh);
                    mesh.AdjustY(-0.06f); // The rails are visually a bit too high in vanilla, so might as well fix that while we're here
                    mesh.SetModified();
                    break;
                // Switch ballast
                case "ballast" when Main.Settings.adjustBallastWidth:
                case "ballast-outersign" when Main.Settings.adjustBallastWidth:
                // Turntable rails
                case "TurntableRail":
                case "TurntableRail_ShadowCaster":
                // Buffer stops
                case "buffer_stop_sleeper_n_1":
                case "buffer_stop_rails":
                case "buffer_stop_rails_LOD1":
                case "buffer_stop_holders":
                    Symmetrical.ScaleToGauge(mesh);
                    mesh.SetModified();
                    break;
            }
        }
    }
}

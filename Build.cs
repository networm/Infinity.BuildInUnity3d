﻿using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace Infinity
{
    public class Build
    {
        private const string buildRoot = "Build/";

        public static void BuildPlayerDevelop()
        {
            BuildPlayer(true);
        }

        public static void BuildPlayerRelease()
        {
            BuildPlayer(false);
        }


        private static void BuildPlayer(bool development)
        {
            var config = new BuildConfig();

            // Platform
            switch (EditorUserBuildSettings.activeBuildTarget)
            {
                case BuildTarget.StandaloneWindows64:
                    SetWindows(ref config);
                    break;
                case BuildTarget.StandaloneOSXIntel:
                case BuildTarget.StandaloneOSXIntel64:
                case BuildTarget.StandaloneOSXUniversal:
                    SetOSX(ref config);
                    break;
                case BuildTarget.iOS:
                    SetiOS(ref config);
                    break;
                case BuildTarget.Android:
                    SetAndroid(ref config);
                    break;
                default:
                    break;
            }

            if (development)
            {
                SetDevelopment(ref config);
            }
            else
            {
                SetRelease(ref config);
            }

            // Check
            if (!System.IO.Directory.Exists (config.path)) {
                System.IO.Directory.CreateDirectory (config.path);
            }

            // Build
            var levels = GetBuildLevels();
            BuildPipeline.BuildPlayer(levels, config.path, config.target, config.options);
        }

        // Platform
        private static void SetWindows(ref BuildConfig config)
        {
            config.path = buildRoot + "Windows/" + PlayerSettings.productName + ".exe";
            config.target = BuildTarget.StandaloneWindows64;
            config.options = BuildOptions.None;
        }

        private static void SetOSX(ref BuildConfig config)
        {
            config.path = buildRoot + "OSX/" + PlayerSettings.productName + ".app";
            config.target = BuildTarget.StandaloneOSXUniversal;
            config.options = BuildOptions.None;
        }

        private static void SetiOS(ref BuildConfig config)
        {
            config.path = buildRoot + "iOS/";
            config.target = BuildTarget.iOS;
            config.options = BuildOptions.Il2CPP;
        }

        private static void SetAndroid(ref BuildConfig config)
        {
            config.path = buildRoot + "Android/" + PlayerSettings.productName + ".apk";
            config.target = BuildTarget.Android;
            config.options = BuildOptions.None;
        }

        // Environment
        private static void SetRelease(ref BuildConfig config)
        {
            // nothing
        }

        private static void SetDevelopment(ref BuildConfig config)
        {
            config.options |= BuildOptions.Development | BuildOptions.AllowDebugging;
        }

        private static string[] GetBuildLevels()
        {
            return EditorBuildSettings.scenes
                .Where(s => s.enabled)
                .Select(s => s.path)
                .ToArray();
        }
    }
}

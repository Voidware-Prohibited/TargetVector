// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;
using System.IO;

public class TargetVector : ModuleRules
{
	public TargetVector(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
		
		// Add include paths for all Game Feature plugins
		string GameFeatureDirectory = Path.Combine(ModuleDirectory, "../../Plugins/GameFeatures"); // Adjust path if your .Build.cs is not in Source/YourProjectName
		string[] GameFeaturePluginDirectories = Directory.GetDirectories(GameFeatureDirectory, "*", SearchOption.TopDirectoryOnly);

		foreach (string PluginDir in GameFeaturePluginDirectories)
		{
			// Check if it's a Game Feature plugin (for simplicity, assumes any plugin in the Plugins folder might contain relevant public headers)
			// Add checks for specific file patterns or plugin descriptors if needed.
			string PublicPath = Path.Combine(PluginDir, "Source", "Public");
			if (Directory.Exists(PublicPath))
			{
				PublicIncludePaths.Add(PublicPath);
			}
		}

		PublicDependencyModuleNames.AddRange(["Core",
			"CoreUObject",
			"GameplayCameras",
			"AnimGraphRuntime",
			"GameplayAbilities",
			"GameplayTasks",
			"GameFeatures",
			"ModularGameplay",
			"ModularGameplayActors",
			"AbilitySystemGameFeatureActions",
			"TargetingSystem",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"ALS",
			"ALSEditor",
			"ALSExtras",
			"ALSXT",
			"ALSXTEditor",
			"ALSXTExtras",
			"HeadMountedDisplay",
			"OnlineSubsystem",
			"OnlineSubsystemEOS",
			"DaySequence",
			"DaySequenceEditor",
			"Chooser",
			"ContextualAnimation",
			"PhysicsControl",
			"DataRegistry",
		]);
		PrivateDependencyModuleNames.AddRange(["HTTP", "NetworkPrediction"]);
		
		// Add the GameplayDebugger module for debug builds only
		if (Target.bBuildDeveloperTools || Target.bBuildEditor)
		{
			PrivateDependencyModuleNames.Add("GameplayDebugger");
			PrivateDependencyModuleNames.Add("NetworkPredictionInsights");
			
		}
	}
}

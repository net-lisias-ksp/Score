# Score!

A Utility to automate computing Scores for Challenges.


## Installation Instructions

To install, place the GameData folder inside your Kerbal Space Program folder. Optionally, you can also do the same for the PluginData (be careful to do not overwrite your custom settings):

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**, including any other fork:
	+ Delete `<KSP_ROOT>/GameData/Score`
* Extract the package's `GameData` folder into your KSP's root:
	+ \<PACKAGE>/GameData/* --> \<KSP_ROOT>/GameData
* Extract the package's `PluginData` folder (if available) into your KSP's root, taking precautions to do not overwrite your custom settings if this is not what you want to.
	+ \<PACKAGE>/PluginData/* --> \<KSP_ROOT>/PluginData
	+ You can safely ignore this step if you already had installed it previously and didn't deleted your custom configurable files.


### Dependencies

* Hard
	+ [KSPe](https://github.com/net-lisias-ksp/KSPAPIExtensions), a component of KSPAPIExtensions /L
	+ [Toolbar Controller](https://forum.kerbalspaceprogram.com/index.php?/topic/169509-18x-toolbar-controller-for-modders/)
* Optional
	+ [Toolbar Continued](https://forum.kerbalspaceprogram.com/index.php?/topic/161857-18x-toolbar-continued-common-api-for-draggableresizable-buttons-toolbar/)
		- If the Blizzy's Toolbar is wanted.
* Indirect
	+ [Click Through Blocker](https://forum.kerbalspaceprogram.com/index.php?/topic/170747-151-click-through-blocker/)
		- Needed by KSPe.UI , used by this Add'On.
		- Needed by Toolbar Controller
		- Needed by Toolbar Continued

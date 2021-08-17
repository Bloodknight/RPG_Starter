
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

// setup the effects data path
if (afxGetEngine() $= "T3D")
{
  $afxEffectsDataPath = expandFilename("data/Cogflicts/art/afx/effects");
  $afxEffectsScriptsPath = expandFilename("data/Cogflicts/scripts/server/afx/effects");
}
else
{
  $afxEffectsDataPath = expandFilename("~/data/effects");
  $afxEffectsScriptsPath = expandFilename("~/server/afx/effects");
}

$afxSpellDataPath = $afxEffectsDataPath;
$afxSpellScriptsPath = $afxEffectsScriptsPath;

// reset the selectron styles
resetDemoSelectronStyles();

// init shared effects datablocks
exec("./afxSharedFX.cs");

// setup spellbook placeholders
exec("./afxPlaceholders.cs"); // disable for AFX Lite Template

// autoload spells and other effects modules
echo("Autoloading AFX Modules...");
autoloadAFXModules();

// create spellbook (do this before exec-ing afxPlaceholders.cs)
datablock afxSpellBookData(afxDemoSpellBookData)
{
  spellBookName = "AFX Demo Spellbook";
};

// load autoloaded spells and placeholders
// into spellbook.
loadDemoSpellbook(afxDemoSpellBookData);

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

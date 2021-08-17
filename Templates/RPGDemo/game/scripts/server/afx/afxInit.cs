//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

//UAISK+AFX Interop Changes: Start
$UAISK_Is_Available = isFile("data/Cogflicts/scripts/server/UAISK/aiExecutes.cs") || isFile("data/Cogflicts/scripts/server/UAISK/aiExecutes.dso");
if ($UAISK_Is_Available)
  echo("UAISK Interop is AVAILABLE");
//UAISK+AFX Interop Changes: End

exec("./afxCommands.cs");
exec("./afxSpawn.cs");
exec("./afxAutoloading.cs");
exec("./afxDemo.cs");
exec("./afxSpellCasting.cs");
exec("./afxScreenMessages.cs");

//UAISK+AFX Interop Changes: Start
if (!$UAISK_Is_Available)
{
  exec("./afxNonPlayer.cs");
  exec("./afxNonPlayerWrangler.cs");
}
//UAISK+AFX Interop Changes: End

function onMissionEndedAFX()
{
  if (isObject(AFX_PlayGui))
    AFX_PlayGui.setSpellBook("");

  // DATABLOCK CACHE CODE <<
  if ($Pref::Server::EnableDatablockCache)
    resetDatablockCache();
   DatablockFilesList.empty();
  // DATABLOCK CACHE CODE >>

  afxEndMissionNotify();
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
// Arcane-FX
//
// Some AFX related script commands.
//
// Copyright (C) Faust Logic, Inc.
//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

// AFX-OVERRIDE -- This function overrides the stock version in commands.cs
function serverCmdToggleCamera(%client)
{
  if (!isObject(%client.camera))
  {
    error("Server command 'ToggleCamera': client camera is undefined.");
    return;
  }

  if (!isObject(%client.player))
  {
    error("Server command 'ToggleCamera': client player is undefined.");
    return;
  }

  if (%client.getControlObject() == %client.player)
  {
    %client.camera.setFlyMode();
    %control = %client.camera;
  }
  else
  {
    %client.camera.setCameraSubject(%client.player); 
    %client.camera.setThirdPersonMode();
    %control = %client.player;
  }
  %client.setControlObject(%control); 

  clientCmdSyncEditorGui();
}

// AFX-OVERRIDE -- This function overrides the stock version in commands.cs
function serverCmdDropPlayerAtCamera(%client)
{
  if (!isObject(%client.camera))
  {
    error("Server command 'DropPlayerAtCamera': client camera is undefined.");
    return;
  }

  if (!isObject(%client.player))
  {
    error("Server command 'DropPlayerAtCamera': client player is undefined.");
    return;
  }

  if (%client.getControlObject() == %client.player)
  {
    %client.camera.setFlyMode();
    %client.player.setTransform(%client.camera.getTransform());
    %client.player.setVelocity("0 0 0");
    %client.camera.setThirdPersonMode();
  }
  else
  {
    %client.player.setTransform(%client.camera.getTransform());
    %client.player.setVelocity("0 0 0");
    %client.setControlObject(%client.player);
    %client.camera.setThirdPersonMode();
  }

  clientCmdSyncEditorGui();
}

// AFX-OVERRIDE -- This function overrides the stock version in commands.cs
function serverCmdDropCameraAtPlayer(%client)
{
  if (!isObject(%client.camera))
  {
    error("Server command 'DropCameraAtPlayer': client camera is undefined.");
    return;
  }

  if (!isObject(%client.player))
  {
    error("Server command 'DropCameraAtPlayer': client player is undefined.");
    return;
  }

  if (%client.getControlObject() == %client.player)
  {
    %client.camera.setFlyMode();
    %client.camera.setTransform(%client.player.getEyeTransform());
    %client.camera.setVelocity("0 0 0");
    %client.setControlObject(%client.camera);
  }
  else
  {
    %client.camera.setTransform(%client.player.getEyeTransform());
    %client.camera.setVelocity("0 0 0");
  }

  clientCmdSyncEditorGui();
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// MAIN SPELLCASTING COMMAND FROM CLIENT

function serverCmdCastSpellbookSpell(%client, %book_slot, %target_ghost)
{
  if (%target_ghost != -1)
    %target = %client.ResolveGhost(%target_ghost);
  else
    %target = -1;

  afxPerformSpellbookCast(%client.player, %book_slot, %target, %client);
}

function serverCmdCastFreeTargetingSpellbookSpell(%client, %book_slot, %free_target)
{
  afxPerformFreeTargetingSpellbookCast(%client.player, %book_slot, %free_target, %client);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// RESPAWN PLAYER COMMAND
//   called by jump key when dead.

function serverCmdRespawnPlayerAfterDeath(%client)
{
  // clear out old linkages between player and client
  if (isObject(%client.player))
  {
    %client.player.client = "";
    %client.player = "";
  }

  // Find a spawn point for the player
  %playerSpawnPoint = pickPlayerSpawnPoint($Game::DefaultPlayerSpawnGroups);
  // Spawn a player for this client using the found %playerSpawnPoint
  %client.spawnPlayer(%playerSpawnPoint);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// CASTING GBoF by KEY

function serverCmdDoGreatBallCast(%client, %target_ghost)
{
  if (%target_ghost != -1)
    %target = %client.ResolveGhost(%target_ghost);
  else
    %target = -1;

  %spell_desc = "";
  if (isObject(GreatBallSpell_RPG))
  {
    %spell_desc = GreatBallSpell_RPG;
  }
  else if (isObject(FlameBroilSpell_RPG))
  {
    %spell_desc = FlameBroilSpell_RPG;
  }
  else
  {
    DisplayScreenMessage(%client, "Spell assigned to this action is not currently loaded.");
    return;
  }
  
  DisplayScreenMessage(%client, "Casting" SPC "\"" @ %spell_desc.spellName @  "\" spell.");
  afxPerformSpellCast(%client.player, %spell_desc, %target, %client);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// SPECIAL PHRASE-TESTER KEY COMMANDS

function serverCmdDoPhraseTesterPush(%client)
{
  performPhraseTesterPush(%client.player);
}

function serverCmdDoPhraseTesterHalt(%client)
{
  performPhraseTesterHalt(%client.player);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// SPELL INTERRUPTION BY KEY
//   only interrupts during casting stage

function serverCmdInterruptSpellcasting(%client)
{
  performSpellCastingInterrupt(%client);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// DIRECT DAMAGE INFLICTED BY KEY
//   for testing spellcasting interrupts
//   due to taking damage

function serverCmdInflictDamage(%client)
{
  if (isObject(%client.player))
    %client.player.damage(0, 0, 10, "User");
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// AFX CAMERA DOLLY 
//   usually by MouseWheel or Home/End keys

function dollyCamAwayFromPlayer(%client)
{ 
  %distance = %client.camera.getThirdPersonDistance();
  %distance += 0.5;
  %client.camera.setThirdPersonDistance(%distance);
}

function dollyCamTowardPlayer(%client)
{   
  %distance = %client.camera.getThirdPersonDistance();
  %distance -= 0.5;
  %client.camera.setThirdPersonDistance(%distance);
}

function serverCmdDollyThirdPersonCam(%client, %toward)
{
  if (%toward)
    dollyCamTowardPlayer(%client);
  else
    dollyCamAwayFromPlayer(%client); 
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// AFX CAMERA LOOK 

function serverCmdLookThirdPersonCam(%client, %left)
{
  %angle = %client.camera.getThirdPersonAngle();
  if (%left)
    %angle -= 5;
  else
    %angle += 5;
  %client.camera.setThirdPersonAngle(%angle);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//
// AFX CAMERA FIRST-PERSON TOGGLE

// Note - the third-person camera auto-switches to and from
// first person mode based on the value of the third-person
// distance. The threshold is 1.0. Values less than the threshold
// force a switch to first-person-mode, values greater than
// or equal to 1.0, force a switch to third-person mode.

function serverCmdToggleFirstPersonPOV(%client)
{
  // get 3rd-person camera offset 
  %cam_dist = %client.camera.getThirdPersonDistance();

  // save 3rd-person distance, force first-person on
  if (%cam_dist >= 1.0)
  {
    %client.save_3rdperson_dist = %cam_dist;
    %cam_dist = 0.1;
  }
  // restore 3rd-person distance, force first-person off
  else if (%client.save_3rdperson_dist !$= "")
  {
    %cam_dist = (%client.save_3rdperson_dist !$= "") ? %client.save_3rdperson_dist : 3;
  }

  // set new 3rd-person distance
  %client.camera.setThirdPersonDistance(%cam_dist);
  %client.camera.setThirdPersonSnap();
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//

function sendPlayerSpellBookToClient(%client, %spellbook)
{
  %ghost_idx = %client.GetGhostIndex(%spellbook);
  if (%ghost_idx == -1)
    schedule(100, 0, "sendPlayerSpellBookToClient", %client, %spellbook);
  else
    commandToClient(%client, 'SetPlayerSpellBook', %ghost_idx);
}

function sendClientPlayerToClient(%client, %player)
{
  %ghost_idx = %client.GetGhostIndex(%player);
  if (%ghost_idx == -1)
    schedule(100, 0, "sendClientPlayerToClient", %client, %player);
  else
    commandToClient(%client, 'SetClientPlayer', %ghost_idx);
}

//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~//~~~~~~~~~~~~~~~~~~~~~//
